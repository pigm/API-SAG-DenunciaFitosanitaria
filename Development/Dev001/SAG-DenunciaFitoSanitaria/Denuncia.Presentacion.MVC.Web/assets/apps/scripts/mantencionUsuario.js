if (typeof (MantencionUsuario) == "undefined")
    MantencionUsuario = {};

MantencionUsuario.IndexURL = DenunciaFitoSanitaria.RootURL + "MantencionUsuario/Index";
MantencionUsuario.GuardarURL = DenunciaFitoSanitaria.RootURL + "MantencionUsuario/Guardar";
MantencionUsuario.EliminarURL = DenunciaFitoSanitaria.RootURL + "MantencionUsuario/Eliminar";

MantencionUsuario.Init = function () {
    $.ajaxSetup({ cache: false });
    MantencionUsuario.DataTableInit();
    MantencionUsuario.Eliminar();
    MantencionUsuario.Guardar();
}

MantencionUsuario.DataTableInit = function () {
    MantencionUsuario.DataTable = $('#datatable_Usuario').DataTable({
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sSearch": "Buscar:",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
        },
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "Todos"]
        ],
        "pageLength": 15,
        "columnDefs": [
                { "targets": [0], "visible": false },
                { "targets": [1] },
                { "targets": [2] },
                { "targets": [3], "sortable": false, "searchable": false },
        ],
        "order": [[0, "asc"]]
    });
}

MantencionUsuario.Guardar = function () {
    $(document).on('click', '#btnGuardar', function (e) {
        var form = $('#formUsuario');
        e.preventDefault();
        var formElement = document.getElementById("formUsuario");
        var formdata = new FormData(formElement);
        waitingDialog.show();
        $.ajax({
            url: form[0].action,
            type: form[0].method,
            data: formdata,
            cache: false,
            processData: false,
            contentType: false,
            success: function (dataResult) {
                if (dataResult.success)
                    location.href = MantencionUsuario.IndexURL;
                else
                    $("#ModalUsuario").find(".modal-content").html(dataResult);
                waitingDialog.hide();
            }
        });
    });
}

MantencionUsuario.Eliminar = function () {
    MantencionUsuario.DataTable.on('click', '#Eliminar', function () {
        var dato = MantencionUsuario.DataTable.row($(this).parents('tr')).data();
        bootbox.confirm("¿ Está seguro de eliminar ?", function (result) {
            if (result == false) {
                return;
            }
            else {
                waitingDialog.show();
                var idUsuario = dato[0];
                $.post(MantencionUsuario.EliminarURL, { idUsuario: idUsuario }, function (result) {
                    if (result.success)
                        location.href = MantencionUsuario.IndexURL;
                });
            }
        });
    });
}
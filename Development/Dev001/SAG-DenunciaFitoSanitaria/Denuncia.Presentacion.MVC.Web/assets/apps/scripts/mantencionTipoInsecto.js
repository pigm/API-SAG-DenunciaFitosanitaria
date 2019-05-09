if (typeof (MantencionTipoInsecto) == "undefined")
    MantencionTipoInsecto = {};

MantencionTipoInsecto.IndexURL = DenunciaFitoSanitaria.RootURL + "MantencionTipoInsecto/Index";
MantencionTipoInsecto.GuardarURL = DenunciaFitoSanitaria.RootURL + "MantencionTipoInsecto/Guardar";
MantencionTipoInsecto.EliminarURL = DenunciaFitoSanitaria.RootURL + "MantencionTipoInsecto/Eliminar";

MantencionTipoInsecto.Init = function () {
    $.ajaxSetup({ cache: false });
    MantencionTipoInsecto.DataTableInit();
    MantencionTipoInsecto.Eliminar();
    MantencionTipoInsecto.MostrarPopup();
    MantencionTipoInsecto.Guardar();
}

MantencionTipoInsecto.DataTableInit = function () {
    MantencionTipoInsecto.DataTable = $('#datatable_TipoInsecto').DataTable({
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
                { "targets": [1], "sortable": false },
                { "targets": [2], "sortable": false },
                { "targets": [3] },
                { "targets": [4], "sortable": false, "searchable": false },
        ],
        "order": [[0, "asc"]]
    });
}

MantencionTipoInsecto.MostrarPopup = function () {
    $('#ModalTipoInsecto').on('loaded.bs.modal', function () {
        $('#switchEstado').bootstrapSwitch('state');
    });
}

MantencionTipoInsecto.Eliminar = function () {
    MantencionTipoInsecto.DataTable.on('click', '#Eliminar', function () {
        var dato = MantencionTipoInsecto.DataTable.row($(this).parents('tr')).data();
        bootbox.confirm("¿ Está seguro de eliminar ?", function (result) {
            if (result == false) {
                return;
            }
            else {
                waitingDialog.show();
                var idTipoInsecto = dato[0];
                $.post(MantencionTipoInsecto.EliminarURL, { idTipoInsecto: idTipoInsecto }, function (result) {
                    if (result.success)
                        location.href = MantencionTipoInsecto.IndexURL;
                    else {
                        waitingDialog.hide();
                        toastr["warning"]("Tipo recall no se puede eliminar.", "RecallV2");
                    }
                });
            }
        });
    });
}

MantencionTipoInsecto.Guardar = function () {
    $(document).on('click', '#btnGuardar', function (e) {
        var form = $('#formTipoInsecto');
        //jQuery.validator.unobtrusive.parse(form);
        //if (form.valid()) {
        e.preventDefault();
        var formElement = document.getElementById("formTipoInsecto");
        var formdata = new FormData(formElement);
        formdata.append("FotoImagen", document.getElementById('file').files[0]);
        //formdata.append("Estado", $("#switchEstado").bootstrapSwitch('state'));
        //waitingDialog.show();
        $.ajax({
            url: form[0].action,
            type: form[0].method,
            data: formdata,
            cache: false,
            processData: false,
            contentType: false,
            success: function (dataResult) {
                if (dataResult.success)
                    location.href = MantencionTipoInsecto.IndexURL;
                else {
                    $("#ModalTipoInsecto").find(".modal-content").html(dataResult);
                }
            }
        });
        //}
    });
}
if (typeof (MantencionCategoria) == "undefined")
    MantencionCategoria = {};

MantencionCategoria.IndexURL = DenunciaFitoSanitaria.RootURL + "MantencionCategoria/Index";
MantencionCategoria.GuardarURL = DenunciaFitoSanitaria.RootURL + "MantencionCategoria/Guardar";
MantencionCategoria.EliminarURL = DenunciaFitoSanitaria.RootURL + "MantencionCategoria/Eliminar";

MantencionCategoria.Init = function () {
    $.ajaxSetup({ cache: false });
    MantencionCategoria.DataTableInit();
    MantencionCategoria.Eliminar();
    MantencionCategoria.MostrarPopup();
    MantencionCategoria.Guardar();
}

MantencionCategoria.DataTableInit = function () {
    MantencionCategoria.DataTable = $('#datatable_Categoria').DataTable({
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
                { "targets": [1], "sortable": true },
                { "targets": [2] },
                { "targets": [3] },
                { "targets": [4], "sortable": false, "searchable": false },
        ],
        "order": [[0, "asc"]]
    });
}

MantencionCategoria.MostrarPopup = function () {
    $('#ModalCategoria').on('loaded.bs.modal', function () {
        $('#switchEstado').bootstrapSwitch('state');
    });
}

MantencionCategoria.Eliminar = function () {
    MantencionCategoria.DataTable.on('click', '#Eliminar', function () {
        var dato = MantencionCategoria.DataTable.row($(this).parents('tr')).data();
        bootbox.confirm("¿ Está seguro de eliminar ?", function (result) {
            if (result == false) {
                return;
            }
            else {
                waitingDialog.show();
                var idCategoria = dato[0];
                $.post(MantencionCategoria.EliminarURL, { idCategoria: idCategoria }, function (result) {
                    if (result.success)
                        location.href = MantencionCategoria.IndexURL;
                    else {
                        waitingDialog.hide();
                        toastr["warning"]("Categoría no se puede eliminar, tiene sub-categoría asociada.", "SAG-Denuncia FitoSanitaria");
                    }
                });
            }
        });
    });
}

MantencionCategoria.Guardar = function () {
    $(document).on('click', '#btnGuardar', function (e) {
        var form = $('#formCategoria');
        e.preventDefault();
        var formElement = document.getElementById("formCategoria");
        var formdata = new FormData(formElement);
        formdata.append("FotoImagen", document.getElementById('file').files[0]);
        formdata.append("Estado", $("#switchEstado").bootstrapSwitch('state'));
        formdata.append("Anonimo", $("#switchAnonimo").bootstrapSwitch('state'));
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
                    location.href = MantencionCategoria.IndexURL;
                else {
                    $("#ModalCategoria").find(".modal-content").html(dataResult);
                    $('#switchEstado').bootstrapSwitch('state');
                    $('#switchAnonimo').bootstrapSwitch('state');
                }
                waitingDialog.hide();
            }
        });
    });
}
if (typeof (MantencionSubCategoria) == "undefined")
    MantencionSubCategoria = {};

MantencionSubCategoria.IndexURL = DenunciaFitoSanitaria.RootURL + "MantencionSubCategoria/Index";
MantencionSubCategoria.GuardarURL = DenunciaFitoSanitaria.RootURL + "MantencionSubCategoria/Guardar";
MantencionSubCategoria.EliminarURL = DenunciaFitoSanitaria.RootURL + "MantencionSubCategoria/Eliminar";

MantencionSubCategoria.Init = function () {
    $.ajaxSetup({ cache: false });
    MantencionSubCategoria.DataTableInit();
    MantencionSubCategoria.MostrarPopup();
    MantencionSubCategoria.Guardar();
}

MantencionSubCategoria.DataTableInit = function () {
    MantencionSubCategoria.DataTable = $('#datatable_SubCategoria').DataTable({
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

MantencionSubCategoria.MostrarPopup = function () {
    $('#ModalSubCategoria').on('loaded.bs.modal', function () {
        $('#switchAnonimo').bootstrapSwitch('state');
        $('#switchEstado').bootstrapSwitch('state');
    });
}

MantencionSubCategoria.Guardar = function () {
    $(document).on('click', '#btnGuardar', function (e) {
        var form = $('#formSubCategoria');
        e.preventDefault();
        var formElement = document.getElementById("formSubCategoria");
        var formdata = new FormData(formElement);
        formdata.append("FotoImagen", document.getElementById('fileSubCategoria').files[0]);
        formdata.append("SubCategoria_Imagenes.FotoImagen1", document.getElementById('fileImagen1').files[0]);
        formdata.append("SubCategoria_Imagenes.FotoImagen2", document.getElementById('fileImagen2').files[0]);
        formdata.append("SubCategoria_Imagenes.FotoImagen3", document.getElementById('fileImagen3').files[0]);
        formdata.append("SubCategoria_Imagenes.FotoImagen4", document.getElementById('fileImagen4').files[0]);
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
                    location.href = MantencionSubCategoria.IndexURL;
                else {
                    $("#ModalSubCategoria").find(".modal-content").html(dataResult);
                    $('#switchAnonimo').bootstrapSwitch('state')
                    $('#switchEstado').bootstrapSwitch('state')
                }
                waitingDialog.hide();
            }
        });
    });
}
if (typeof (MantencionTipoDenuncia) == "undefined")
    MantencionTipoDenuncia = {};

MantencionTipoDenuncia.IndexURL = DenunciaFitoSanitaria.RootURL + "MantencionTipoDenuncia/Index";
MantencionTipoDenuncia.GuardarURL = DenunciaFitoSanitaria.RootURL + "MantencionTipoDenuncia/Guardar";

MantencionTipoDenuncia.Init = function () {
    $.ajaxSetup({ cache: false });
    MantencionTipoDenuncia.DataTableInit();
    MantencionTipoDenuncia.MostrarPopup();
    MantencionTipoDenuncia.Guardar();
}

MantencionTipoDenuncia.DataTableInit = function () {
    MantencionTipoDenuncia.DataTable = $('#datatable_TipoDenuncia').DataTable({
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
                { "targets": [1], "searchable": true, "sortable": true },
                { "targets": [2] },
                { "targets": [3], "sortable": false, "searchable": false },
        ],
        "order": [[0, "asc"]]
    });
}

MantencionTipoDenuncia.MostrarPopup = function () {
    $('#ModalTipoDenuncia').on('loaded.bs.modal', function () {
        $('#switchEstado').bootstrapSwitch('state');
        $('#switchAnonimo').bootstrapSwitch('state');
    });
}

MantencionTipoDenuncia.Guardar = function () {
    $(document).on('click', '#btnGuardar', function (e) {
        var form = $('#formTipoDenuncia');
        e.preventDefault();
        var formElement = document.getElementById("formTipoDenuncia");
        var formdata = new FormData(formElement);
        formdata.append("Estado", $("#switchEstado").bootstrapSwitch('state'));
        formdata.append("Incognito", $("#switchAnonimo").bootstrapSwitch('state'));
        if (form.valid()) {
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
                        location.href = MantencionTipoDenuncia.IndexURL;
                    else {
                        $("#ModalTipoDenuncia").find(".modal-content").html(dataResult);
                        $('#switchEstado').bootstrapSwitch('state');
                        $('#switchAnonimo').bootstrapSwitch('state');
                    }
                    waitingDialog.hide();
                }
            });
        }
    });
}
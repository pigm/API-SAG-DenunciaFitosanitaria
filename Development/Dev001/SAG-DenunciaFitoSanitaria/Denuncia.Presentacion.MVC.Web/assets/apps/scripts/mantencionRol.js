if (typeof (MantencionRol) == "undefined")
    MantencionRol = {};

MantencionRol.IndexURL = DenunciaFitoSanitaria.RootURL + "MantencionRol/Index";
MantencionRol.GuardarURL = DenunciaFitoSanitaria.RootURL + "MantencionRol/Crear";
MantencionRol.EliminarURL = DenunciaFitoSanitaria.RootURL + "MantencionRol/Eliminar";
MantencionRol.Menu = {}


MantencionRol.Init = function () {
    $.ajaxSetup({ cache: false });
    MantencionRol.DataTableInit();
    MantencionRol.Eliminar();
    MantencionRol.MostrarPopup();
    MantencionRol.Guardar();
}

MantencionRol.DataTableInit = function () {
    MantencionRol.DataTable = $('#datatable_Rol').DataTable({
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
                { "targets": [0] },
                { "targets": [1], "sortable": false, "searchable": false },
        ],
        "order": [[0, "asc"]]
    });
}

MantencionRol.MostrarPopup = function () {
    $('#ModalRol').on('loaded.bs.modal', function () {
        
    });
}

MantencionRol.Eliminar = function () {
    MantencionRol.DataTable.on('click', '#Eliminar', function () {
        var dato = MantencionRol.DataTable.row($(this).parents('tr')).data();
        bootbox.confirm("¿ Está seguro de eliminar ?", function (result) {
            if (result == false) {
                return;
            }
            else {
                waitingDialog.show();
                var rol = dato[0];
                $.post(MantencionRol.EliminarURL, { rol: rol }, function (result) {
                    if (result.success)
                        location.href = MantencionRol.IndexURL;
                    else {
                        waitingDialog.hide();
                        toastr["warning"]("Rol no se puede eliminar, tiene usuarios asociados.", "SAG-Denuncia FitoSanitaria");
                    }
                });
            }
        });
    });
}

MantencionRol.Guardar = function () {
    $(document).on('click', '#btnGuardar', function (e) {
        var form = $('#formRol');
        e.preventDefault();
        var formElement = document.getElementById("formRol");
        var formdata = new FormData(formElement);
        formdata.append("Nombre", $('#Nombre').val());
        var idMenu = $('#tree_2').jstree(true).get_bottom_selected(false);
        formdata.append("Acceso", idMenu.join());
        waitingDialog.show();
        $.ajax({
            url: form[0].action,
            type: form[0].method,
            data: formdata,
            cache: false,
            processData: false,
            contentType: false,
            success: function (dataResult) {
                //waitingDialog.hide();
                if (dataResult.success)
                    location.href = MantencionRol.IndexURL;
                else {
                    $("#ModalRol").find(".modal-content").html(dataResult);
                }
                waitingDialog.hide();
            }
        });
    });
}
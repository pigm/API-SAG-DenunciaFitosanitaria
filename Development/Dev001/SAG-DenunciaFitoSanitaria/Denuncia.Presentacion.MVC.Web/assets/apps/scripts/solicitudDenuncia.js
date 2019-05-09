if (typeof (SolicitudDenuncia) == "undefined")
    SolicitudDenuncia = {};

SolicitudDenuncia.DataTable = "";
SolicitudDenuncia.URLBuscar = DenunciaFitoSanitaria.RootURL + "SolicitudDenuncia/Busqueda";
SolicitudDenuncia.URLDescarga = DenunciaFitoSanitaria.RootURL + "SolicitudDenuncia/Descarga";
SolicitudDenuncia.ModificarDenuncia = DenunciaFitoSanitaria.RootURL + "SolicitudDenuncia/ModificarDenuncia";
SolicitudDenuncia.IndexURL = DenunciaFitoSanitaria.RootURL + "SolicitudDenuncia/Index";

SolicitudDenuncia.Init = function () {
    $.ajaxSetup({ cache: false });
    SolicitudDenuncia.DataTableInit();
    SolicitudDenuncia.Busqueda();
    SolicitudDenuncia.Descarga();
    SolicitudDenuncia.IndexInit();
    SolicitudDenuncia.Modificar();
}

SolicitudDenuncia.IndexInit = function () {

    $(".number").inputmask({
        "mask": "9",
        "repeat": 10,
        "greedy": false
    });

    $('.date-picker').datepicker({
        autoclose: true,
        language: "es-CL",
        format: "dd-mm-yyyy",
        weekStart: 1,
        clearBtn: true
    });
}

SolicitudDenuncia.Busqueda = function () {
    $(document).on("click", "#btnBuscar", function () {
        filtro = {
            IdTipoDenuncia: $("#IdTipoDenuncia").val(),
            FechaSolicitudDesde: $("#FechaSolicitudDesde").val(),
            FechaSolicitudHasta: $("#FechaSolicitudHasta").val(),
            IdCategoria: $("#IdCategoria").val(),
            IdSubCategoria: $("#IdSubCategoria").val(),
            IdRegion: $("#IdRegion").val(),
            IdComuna: $("#IdComuna").val()
        };
        waitingDialog.show();
        $.post(SolicitudDenuncia.URLBuscar, filtro, function (dataResult) {
            var $html = $(dataResult);
            $("#divBusqueda").html($html);
            SolicitudDenuncia.DataTableInit();
            waitingDialog.hide();
        });
    });
}

SolicitudDenuncia.Descarga = function () {
    $(document).on("click", "#btnDescargar", function () {
        var filtrosArray = new Array();
        filtrosArray.push({ "key": "IdTipoDenuncia", "data": $("#IdTipoDenuncia").val() });
        filtrosArray.push({ "key": "FechaSolicitudDesde", "data": $("#FechaSolicitudDesde").val() });
        filtrosArray.push({ "key": "FechaSolicitudHasta", "data": $("#FechaSolicitudHasta").val() });
        filtrosArray.push({ "key": "IdCategoria", "data": $("#IdCategoria").val() });
        filtrosArray.push({ "key": "IdSubCategoria", "data": $("#IdSubCategoria").val() });
        filtrosArray.push({ "key": "IdRegion", "data": $("#IdRegion").val() });
        filtrosArray.push({ "key": "IdComuna", "data": $("#IdComuna").val() });
        $.downloadArr(SolicitudDenuncia.URLDescarga, filtrosArray);
    });
}


SolicitudDenuncia.Modificar = function () {
    $(document).on("click", "#btnGuardar", function () {
        waitingDialog.show();
        filtro = {
            IdDenuncia: $("#IdDenuncia").val(),
            IdEstadoDenuncia: $("#IdEstadoDenuncia").val(),
            IdSubCategoriaNueva: $("#IdSubCategoriaNueva").val(),
            IdTipoDenuncia: $("#IdTipoDenuncia").val(),
            Comentario: $("#Comentario").val(),
            Descripcion: $("#DescripcionCortada").val(),
            Referencia: $("#Referencia").val()
        };
        if ($("#IdEstadoDenuncia").val() == "3" || $("#IdEstadoDenuncia").val() == "4") {
            if ($("#Comentario").val() != "") {
                $.post(SolicitudDenuncia.ModificarDenuncia, filtro, function (dataResult) {
                    $("#btnGuardar").attr("disabled", true);
                    location.href = SolicitudDenuncia.IndexURL;
                });
            }
            else {
                waitingDialog.hide();
                $("#validacionComentario").html("Ingrese Comentario");
            }
        }
        else {
            $.post(SolicitudDenuncia.ModificarDenuncia, filtro, function (dataResult) {
                $("#btnGuardar").attr("disabled", true);
                location.href = SolicitudDenuncia.IndexURL;
            });
        }
    });
}

SolicitudDenuncia.Mapa = function (latitud, longitud) {

    google.maps.visualRefresh = true;
    var Chile = new google.maps.LatLng(-33.4632834, -70.7088405, 12.5);

    var mapOptions = {
        zoom: 4,
        center: Chile,
        mapTypeId: 'hybrid'
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    var myLatlng = new google.maps.LatLng(latitud, longitud);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Denuncia'
    });
}

SolicitudDenuncia.DataTableInit = function () {
    SolicitudDenuncia.dataTable = $('#datatable_Denuncias').dataTable({
        "buttons": {
            "extend": "print"
        },
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
        "searching": true,
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "Todos"]
        ],
        "pageLength": 15,
        "columnDefs": [
                { "targets": [0] },
                { "targets": [1] },
                { "targets": [2] },
                { "targets": [3] },
                { "targets": [4] },
                { "type": "date-uk", targets: 5 },
                { "targets": [6], "sortable": false, "searchable": false },
                { "targets": [7], "visible": false, "searchable": true },
                { "targets": [8], "visible": false, "searchable": true },
                { "targets": [9], "visible": false, "searchable": true }

        ],
        "order": [[9, "desc"]]
    });
}
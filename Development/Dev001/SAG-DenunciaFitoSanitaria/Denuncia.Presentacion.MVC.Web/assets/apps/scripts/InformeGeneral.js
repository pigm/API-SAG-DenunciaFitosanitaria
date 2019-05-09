if (typeof (InformeGeneral) == "undefined")
    InformeGeneral = {};

InformeGeneral.DataTable = "";
InformeGeneral.BusquedaURL = DenunciaFitoSanitaria.RootURL + "InformeGeneral/Busqueda";
InformeGeneral.URLDescargaDenuncia = DenunciaFitoSanitaria.RootURL + "InformeGeneral/Descarga";

InformeGeneral.Init = function () {
    $.ajaxSetup({ cache: false });
    InformeGeneral.DataTableInit();
    InformeGeneral.IndexInit();
    InformeGeneral.Busqueda();
    InformeGeneral.Descarga();

}

InformeGeneral.DataTableInit = function () {
    InformeGeneral.DataTable = $('#datatable_DenunciasInforme').DataTable({
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
                { "targets": [1] },
                { "targets": [2] },
                { "targets": [3] },
                { "targets": [4] },
                { "targets": [5] },
                { "type": "date-uk", targets: 6 },
                { "targets": [7], "sortable": false, "searchable": false },
                { "targets": [8], "visible": false, "searchable": true },
                { "targets": [9], "visible": false, "searchable": true }
        ],
        "order": [[0, "asc"]]
    });
}

InformeGeneral.IndexInit = function () {

    $("#Fecha").val('');

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

InformeGeneral.Busqueda = function () {
    $(document).on("click", "#btnBuscar", function () {
        filtro = {
            IdTipoDenuncia: $("#IdTipoDenuncia").val(),
            IdEstado: $("#IdEstado").val(),
            FechaSolicitudDesde: $("#FechaSolicitudDesde").val(),
            FechaSolicitudHasta: $("#FechaSolicitudHasta").val(),
            IdCategoria: $("#IdCategoria").val(),
            IdSubCategoria: $("#IdSubCategoria").val(),
            IdRegion: $("#IdRegion").val(),
            IdComuna: $("#IdComuna").val()
        };
        waitingDialog.show();
        $.post(InformeGeneral.BusquedaURL, filtro, function (dataResult) {
            var $html = $(dataResult);
            $("#divBusqueda").html($html);
            InformeGeneral.DataTableInit();
            waitingDialog.hide();
        });
    });
}

InformeGeneral.Descarga = function () {
    $(document).on("click", "#btnDescargar", function () {
        var filtrosArray = new Array();
        filtrosArray.push({ "key": "IdTipoDenuncia", "data": $("#IdTipoDenuncia").val() });
        filtrosArray.push({ "key": "IdEstado", "data": $("#IdEstado").val() });
        filtrosArray.push({ "key": "FechaSolicitudDesde", "data": $("#FechaSolicitudDesde").val() });
        filtrosArray.push({ "key": "FechaSolicitudHasta", "data": $("#FechaSolicitudHasta").val() });
        filtrosArray.push({ "key": "IdCategoria", "data": $("#IdCategoria").val() });
        filtrosArray.push({ "key": "IdSubCategoria", "data": $("#IdSubCategoria").val() });
        filtrosArray.push({ "key": "IdRegion", "data": $("#IdRegion").val() });
        filtrosArray.push({ "key": "IdComuna", "data": $("#IdComuna").val() });
        $.downloadArr(InformeGeneral.URLDescargaDenuncia, filtrosArray);
    });
}

InformeGeneral.Mapa = function (latitud, longitud) {

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



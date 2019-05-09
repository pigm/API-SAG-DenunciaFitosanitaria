if (typeof (InformeEspacial) == "undefined")
    InformeEspacial = {};

InformeEspacial.BusquedaURL = DenunciaFitoSanitaria.RootURL + "InformeEspacial/Busquedajson";


InformeEspacial.Init = function () {
    $.ajaxSetup({ cache: false });
    InformeEspacial.SeteoInicial();
    InformeEspacial.Buscar();
    InformeEspacial.Busqueda();

}

InformeEspacial.SeteoInicial = function () {
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
    InformeEspacial.Buscar();
}

InformeEspacial.Buscar = function () {
    filtro = {
        IdTipoDenuncia: $("#IdTipoDenuncia").val(),
        FechaSolicitudDesde: $("#FechaSolicitudDesde").val(),
        FechaSolicitudHasta: $("#FechaSolicitudHasta").val(),
        IdCategoria: $("#IdCategoria").val(),
        IdSubCategoria: $("#IdSubCategoria").val(),
        IdRegion: $("#IdRegion").val(),
        IdComuna: $("#IdComuna").val(),
        IdEstado: $("#IdEstado").val()
    };
    $.post(InformeEspacial.BusquedaURL, filtro, function (dataResult) {
        InformeEspacial.RecorreTabla(dataResult);
    });
}


InformeEspacial.Busqueda = function () {
    $(document).on("click", "#btnBuscar", function () {
        InformeEspacial.Buscar();
    });
}


InformeEspacial.RecorreTabla = function (dataResult) {
    google.maps.visualRefresh = true;
    var Chile = new google.maps.LatLng(-33.4632834, -70.7088405, 12.5);

    var mapOptions = {
        zoom: 4,
        center: Chile,
        mapTypeId: 'hybrid'
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

    for (var i in dataResult.Data) {
        var row = dataResult.Data[i];
        var latidud = row[2];
        var longitud = row[3];
        var marker = new google.maps.Marker({
            'position': new google.maps.LatLng(latidud, longitud),
            'map': map,
            'title': row[4]
        });
        var idEstadoDenuncia = row[1];
        if (idEstadoDenuncia == 3) {
            marker.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png')
        } else {
            marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')
        }
    };
}


if (typeof (DenunciaFitoSanitaria) == "undefined") {
    DenunciaFitoSanitaria = {};
}

DenunciaFitoSanitaria.RootURL = "";

DenunciaFitoSanitaria.Init = function () {
    Globalize.culture("es-CL");
    DenunciaFitoSanitaria.AjaxCustom();
    DenunciaFitoSanitaria.ValidatorCustom();
    DenunciaFitoSanitaria.ToastrCustom();

    $('#myCarousel').carousel({
        pause: 'none'
    });
}

DenunciaFitoSanitaria.ToastrCustom = function () {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-bottom-right",
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

DenunciaFitoSanitaria.AjaxCustom = function () {
    $.ajaxSetup({ cache: false });
    $(document).ajaxError(function (e, xhr, options, error) {
        waitingDialog.hide();
        toastr["error"]("No fue posible procesar la solicitud requerida.", "SAG-Denuncia FitoSanitaria");
    });
}

DenunciaFitoSanitaria.ValidatorCustom = function () {
    $('.input-validation-error').parents('.form-group').addClass('has-error');
    $('.field-validation-error').addClass('text-danger');
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest(".form-group").addClass("has-error");
        },
        unhighlight: function (element) {
            $(element).closest(".form-group").removeClass("has-error");
        }
    });
}

Object.size = function (obj) {
    var size = 0, key;
    for (key in obj) {
        if (obj.hasOwnProperty(key)) size++;
    }
    return size;
};

$(document).ready(function () {
    DenunciaFitoSanitaria.Init();
});
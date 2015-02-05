(function ($) {


    var registrationFaild = function () {
        var _private = {};
        var _public = {};

        _private.btnTryAgainRegister = function () {
            window.location.href = '/Register';
        }


        _public.init = function () {
            console.log("RegistrationFailed.js module initialization");
            $("#btnTryAgainRegister").on('click', _private.btnTryAgainRegister);

        }
        return _public;
    }();

    $(function () {
        registrationFaild.init();
    });
})(jQuery);
(function ($) {


    var successfullRegistration = (function () {

        var _private = {};
        var _public = {};

        _public.init = function () {
            console.log("SuccessfullRegistration.js module initialization");
            window.setTimeout(function () {
                window.location.href = '/home';
            }, 2000);

        };

        return _public;

    })();



    $(function () {
        successfullRegistration.init();

    });

})(jQuery);
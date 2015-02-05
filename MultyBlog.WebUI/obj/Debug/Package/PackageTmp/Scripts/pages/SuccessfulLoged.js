(function () {
    var successfulLoged = function () {

        var _private = {};
        var _public = {};

        _private.btnGoToMainPage_Click = function () {
            window.location.href = "/home";
        }


        _public.init = function () {
            $("#btnGoToMainPage").on("click", _private.btnGoToMainPage_Click);
        }

        return _public;

    }();

    $(function () {
        successfulLoged.init();

    });
})(jQuery);
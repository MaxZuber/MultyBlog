(function () {
    var home = function () {

        var _private = {};
        var _public = {};



        _public.init = function () {

            $("#navLiHome").toggleClass("active");
        }


        return _public
    }();


    $(function () {

        home.init();
    });
})(jQuery);
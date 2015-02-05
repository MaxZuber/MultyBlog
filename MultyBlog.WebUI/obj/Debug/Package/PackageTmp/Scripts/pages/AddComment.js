(function ($) {


    var addComment = (function () {

        var _private = {};
        var _public = {};

        _private.btnAddComment_Click = function () {

        };

        _private.aButton_Click = function () {
            var aID = $("#h_articleId").val();
            var commentText = $("#taUserComment").val();
            var comment = {
                ArticleID: aID,
                Text: commentText,
                UserName: "max",
                Date: $.now(),
            };

            $.ajax({
                url: "AddComment/" + aID,
                data: comment,
                type: "post",
                success: function (data) {
                    //var comments = $(".comments");
                    $(".comments")[0].innerHTML = data;
                    $("#taUserComment").val("");
                },
                error : function(){
                    alert("Error");
                }
            });
        }

        _public.init = function () {
            console.log("AddComment.js module initialization");
            $("#taUserComment").val("");
            $("#aButton").on("click", _private.aButton_Click);
        };

        return _public;

    })();



    $(function () {
        addComment.init();
    });

})(jQuery);
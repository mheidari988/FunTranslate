$(document).ready(function () {
    $("#targetContainer").hide();
    $("#errorContainer").hide();

    $("#btnTranslate").click(function () {
        $("#errorContainer").hide();
        $("#targetContainer").show(500);
        $("#targetTranslate").html("");
        $("#targetText").html("Translating...");
        $("#targetTranslated").html("");
        $.ajax({
            type: "POST",
            url: "https://localhost:7177/api/translations",
            data: {
                "text": $("#textToTranslate").val(),
                "type": "yoda"
            },
            success: function (response) {

                $("#targetTranslate").html(response.translation);
                $("#targetText").html(response.text);
                $("#targetTranslated").html(response.translated);
            },
            error: function () {
                showError();
            }
        });
    });

    $("#btnLucky").click(function () {
        $("#errorContainer").hide();
        $("#targetContainer").show(500);
        $("#targetTranslate").html("");
        $("#targetText").html("Translating...");
        $("#targetTranslated").html("");
        $.ajax({
            type: "POST",
            url: "https://localhost:7177/api/translations",
            data: {
                "text": $("#textToTranslate").val(),
            },
            success: function (response) {

                $("#targetTranslate").html(response.translation);
                $("#targetText").html(response.text);
                $("#targetTranslated").html(response.translated);
            },
            error: function () {
                showError();
            }
        });
    });

    function showError() {
        $("#targetContainer").hide();
        $("#errorContainer").show(100);
    }
});
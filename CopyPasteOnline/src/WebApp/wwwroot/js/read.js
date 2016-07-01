$(document).ready(function () {
    $("#input").focus(function (e) {
        $("#error").text("");
    });
});

function selectAll() {
    $("#textarea").select();
}

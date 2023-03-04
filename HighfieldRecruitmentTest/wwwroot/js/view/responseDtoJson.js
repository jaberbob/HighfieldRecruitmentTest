$(function () {
    $.get("/api/testResponse", function (data) {
        $("#responseJson").html(JSON.stringify(data, null, 2));        
        hljs.highlightAll();
    });
});

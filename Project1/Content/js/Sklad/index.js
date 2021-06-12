//cklad
function clear() {
    document.querySelector("#data").innerHTML = "";
}

$(function () {
    $("#linkZp").click(function (e) {
        e.preventDefault();
        var zp = $("#intZp").val();
        var url = $(this).attr("href");
        url = url + "?zp=" + zp;
        $.get(url, function (response) {
            $("#data").html(response);
        });
    });
});


function clear() {
    console.log("2");
    alert("Привет2");
    window.onload = function () {
        document.querySelector("#data").innerHTML = "";
    }
}


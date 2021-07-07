
    $('#credit').click(function () {
        if ($("#content").is(":hidden"))
        {
        $("#table").hide("slow");
    $("#DoYuoWont").hide("slow");
    $("#content").show("slow");
        } else {
        $("#content").hide("slow");
    $("#table").show("slow");

}
});

    function test(txt) {
        $("#content").hide("slow");
        $("#getCredit").show("slow");
        var cash = document.getElementById("cash+" + txt.value).innerText;
        var day = document.getElementById("day+" + txt.value).innerText;
        $('#cash').replaceWith(cash);
        $('#day').replaceWith(day);
        document.getElementById('btnYes').value = cash + " " + day;
    }



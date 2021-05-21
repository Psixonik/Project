
$("#tabs1").hide("slow");
$("#tabs2").hide("slow");
$("#tabs3").hide("slow");
$("#tabs4").hide("slow");
$("#tabs5").hide("slow");
$("#tabs6").hide("slow");
$("#tabs7").hide("slow");

function test(txt) {
    $("#tabs1").hide("slow");
    $("#tabs2").hide("slow");
    $("#tabs3").hide("slow");
    $("#tabs4").hide("slow");
    $("#tabs5").hide("slow");
    $("#tabs6").hide("slow");
    $("#tabs7").hide("slow");


    var el = txt.value;
    switch (el) {
        case 1:
            $("#tabs1").show("slow");
            break;
        case 2:
            $("#tabs2").show("slow");
            break;
        case 3:
            $("#tabs3").show("slow");
            break;
        case 4:
            $("#tabs4").show("slow");
            break;
        case 5:
            $("#tabs5").show("slow");
            break;
        case 6:
            $("#tabs6").show("slow");
            break;
        case 7:
            $("#tabs7").show("slow");
            break;

        default:
            break;
    }
}




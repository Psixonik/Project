
var ul = document.getElementById('test'); // Parent

ul.addEventListener('click', function (e)
{
    var target = e.target; // Clicked element
    switch (target.id) {
        case 'work':
            $("#workShow").show("slow");
            $("#maniShow").hide("slow");
            $("#helpShow").hide("slow");
            break;
        case 'mani':
            $("#workShow").hide("slow");
            $("#maniShow").show("slow");
            $("#helpShow").hide("slow");
            break;
        case 'help':
            $("#workShow").hide("slow");
            $("#maniShow").hide("slow");
            $("#helpShow").show("slow");
            break;
        default:
            break;
    }
});




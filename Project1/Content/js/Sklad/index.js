//sklad
function clear() {
    console.log("2");
    document.querySelector("#data").innerHTML = "";
}
function SelectedIndexChanged(txt) {
    /*var axez = document.querySelector('#EditLink');
    alert(axez);
    var axez1 = document.querySelector("#DropDown");
    document.querySelector("#EditLink").value = axez1.value;
    axez.dropdowntipo = axez1.value;*/
    var axez1 = document.querySelector("#DropDown");
    $("#EditLink").attr("href", "/Sklad/SkladPartial");
    $("#EditLink").attr("href", $("#EditLink").attr("href") + "?dropdowntipo="+txt.value);

}


function RunAction() {
    var action = '<%= Url.Action("SkladPartial", "Sklad") %>';
    var data = $("#t").serialize();
    $.get(action, data);
}



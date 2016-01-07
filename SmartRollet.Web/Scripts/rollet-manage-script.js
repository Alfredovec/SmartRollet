$(document).ready(function() {
    var openedPart = $("#OpenedPart").val();
    var blinds = $(".blinds").first();
    blinds.css("top", -openedPart);
});

$("#full-open").on("click", function (event) {
    var blinds = $(".blinds").first();
    if (blinds.position().top > -169) {
        var delta = 169 + blinds.position().top;
        UpdateOpened(Number(blinds.position().top) - Number(delta));
        blinds.animate({ top: "-=" + delta }, 1500);
    }
});

$("#full-close").on("click", function (event) {
    var blinds = $(".blinds").first();
    if (blinds.position().top < 0) {
        var delta = -blinds.position().top;
        UpdateOpened(Number(blinds.position().top) + Number(delta));
        blinds.animate({ top: "+=" + delta }, 1500);
    }
});

$("#close").on("click", function (event) {
    var step = $(".open-closing-step").first().val();
    var blinds = $(".blinds").first();
    if (blinds.position().top < 0) {
        UpdateOpened(Number(blinds.position().top) + Number(step));
        blinds.animate({ top: "+=" + step }, 750);
    }
});

$("#open").on("click", function (event) {
    var step = $(".open-closing-step").first().val();
    var blinds = $(".blinds").first();
    if (blinds.position().top > -169) {
        UpdateOpened(Number(blinds.position().top) - Number(step));
        blinds.animate({ top: "-=" + step }, 750);
    }

});

function UpdateOpened(position) {
    $("#OpenedPart").first().val(-position);
    var form = document.forms[0];
}
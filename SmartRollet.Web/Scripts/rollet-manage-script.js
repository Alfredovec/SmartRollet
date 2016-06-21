$(document).ready(function () {
    SetupRolletsPosition();
});

function SetupRolletsPosition() {
    var rolletStates = $("[name=RolletState]");
    rolletStates.each(function () {
        var $this = $(this);
        var blinds = $this.closest("form").find(".blinds");
        blinds.css("top", -$this.val());
    });
}

function SetupRolletsPositionAuto() {
    var neededStates = $(".min-light");
    neededStates.each(function () {
        var $this = $(this);
        var blinds = $this.closest("form").find(".blinds");
        var rolletId = $this.closest("form").find("[name=Id]").val();
        var currentOpenedPart = $this.closest("form").find("[name=RolletState]").val();

        var actualValue = +$this.closest("form").find(".state-value").text();
        var neededValue = +$this.val();
        var blindHeight = +blinds.css('height').split('px')[0];

        var openedPart = neededValue * blindHeight / actualValue;

        openedPart = openedPart < 0 ? 0 : openedPart;
        openedPart = openedPart > blindHeight ? blindHeight : openedPart;

        var partToMove = Math.round(currentOpenedPart - openedPart);
        $.ajax({
            type: "PUT",
            url: "/api/rollet/" + rolletId + '?change=' + partToMove,
            success: function () {
                var timeToAnimate = 1000;
                blinds.animate({ top: "+=" + partToMove }, timeToAnimate);
                $this.closest("form").find("[name=RolletState]").val(openedPart);

                var $buttons = $this.closest("form").find("#open, #close, #up, #down");
                lockButtons($buttons);
                setTimeout(releaseButtons, timeToAnimate, $buttons);
            }
        });
    });
}

$(".automode").on('change', function () {
    var $buttons = $("#open, #close, #up, #down");
    if ($(this).is(":checked")) {
        lockButtons($buttons);
        SetupRolletsPositionAuto();
    } else {
        releaseButtons($buttons);
    }
});

$("#open, #close, #up, #down").on("click", function (event) {
    var $this = $(this);
    var action = $this.attr('id');
    var blinds = $this.closest("form").find(".blinds");
    var height = +blinds.css('height').split('px')[0];
    var currentOpenedPart = -blinds.position().top;
    var rolletId = $this.closest("form").find("[name=Id]").val();

    var delta;
    switch (action) {
        case "open":
        case "close":
            delta = height;
            break;
        case "up":
        case "down":
            delta = $this.closest("form").find(".open-closing-step").val();
            break;
        default:
            throw "Unknown action";
    }

    var partToMove = 0;
    switch (action) {
        case "open":
        case "up":
            var canBeOpened = height - currentOpenedPart;
            partToMove = Math.round(-Math.min(canBeOpened, delta));
            break;
        case "close":
        case "down":
            var canBeClosed = currentOpenedPart;
            partToMove = Math.round(Math.min(canBeClosed, delta));
            break;
        default:
            throw "Unknown action";
    }

    $.ajax({
        type: "PUT",
        url: "/api/rollet/" + rolletId + '?change=' + partToMove,
        success: function () {
            var timeToAnimate = 1000;
            blinds.animate({ top: "+=" + partToMove }, timeToAnimate);
            $this.closest("form").find("[name=RolletState]").val(currentOpenedPart - partToMove);

            var $buttons = $this.closest("form").find("#open, #close, #up, #down");
            lockButtons($buttons);
            setTimeout(releaseButtons, timeToAnimate, $buttons);
        }
    });
});

function lockButtons($buttons) {
    $buttons.attr('disabled', 'disabled');
}

function releaseButtons($buttons) {
    $buttons.removeAttr('disabled');
}
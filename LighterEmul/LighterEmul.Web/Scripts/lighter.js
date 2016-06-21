$(document).on("ready", function() {
    var $input = $("#lighter-input");
    $input.change(function() {
        $.ajax({
            type: 'PUT',
            data: {
                id: $('#lighterId').val(),
                value: $input.val()
            },
            url: '/api/lighter'
        });
    });
});
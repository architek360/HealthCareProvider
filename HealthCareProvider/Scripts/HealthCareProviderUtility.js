/// <reference path="jquery-1.9.1.js" />
var ajaxFormsubmit = function () {
    var $form = $(this);
    var option = {
        url: $form.attr('action'),
        type: $form.attr('method'),
        data: $form.serialize()
    };

    var spinnerID = $form.attr('data-hcp-loadingID');
    $(spinnerID).fadeIn();

    $.ajax(option).done(function (data) {
        var targetElement = $($form).attr('data-hcp-target');
        $(targetElement).replaceWith(data);
        $(spinnerID).fadeOut();
    });
    return false;
};

var createAutoComplete = function () {
    var $input = $(this);
    $input.autocomplete({
        source: function (request, response) {
            $.getJSON($input.data('hcp-autocomplete-source') + "?term=" + request.term, function (data) {
                var parsedResult = JSON.parse(data);
                response( $.map(parsedResult.response.data, function (index, item) {
                    return {
                        label: index.category,
                        value: index.category
                    };
                }));
            });
        },
        select: submitAutoCompleteForm,
        minLength: 2
    });
};

function submitAutoCompleteForm(event, ui) {
    var $input = $(this); //input text
    $input.val(ui.item.label);
    var $form = $('form:first');
    if ($form) {
        $form.submit(ajaxFormsubmit);
        $form.submit();
    }
 }
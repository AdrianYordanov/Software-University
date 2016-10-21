"use strict";

function attachEvents() {
    $('#items').on('click', 'li', function () {
        let current = $(this);

        if (current.attr('data-selected') == undefined) {
            current.attr('data-selected', 'true');
            current.css('background', '#DDD');
        } else {
            current.removeAttr('data-selected');
            current.css('background', '');
        }
    });

    $('#showTownsButton').on('click', function () {
        let selectedTowns = Array.from($('#items li[data-selected]'));
        let result = selectedTowns
            .map(item => item.textContent)
            .join(', ');
        $('#selectedTowns').text(`Selected towns: ${result}`);
    });
}
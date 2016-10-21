"use strict";

function search() {
    let inputText = $('#searchText').val();
    let counter = 0;

    $('#towns li').each(function () {
        let currentTown = $(this);

        if (currentTown.text().indexOf(inputText) != -1) {
            ++counter;
            currentTown.css('font-weight', 'bold');
        } else {
            currentTown.css('font-weight', '');
        }
    });

    $('#result').text(`${counter} matches found.`);
}
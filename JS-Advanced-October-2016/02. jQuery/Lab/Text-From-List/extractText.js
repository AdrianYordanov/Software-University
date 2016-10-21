"use strict";

function extractText() {
    let listItems = Array.from($('#items li'));
    let result = listItems
        .map(item => item.textContent)
        .join(', ');

    $('#result').text(result);
}
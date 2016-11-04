"use strict";

function summary(selector) {
    $(selector).on('click', function () {
        let highlighted = Array.from($('#content strong'))
            .map(element => element.innerHTML)
            .join('');

        let result = $("<div id='summary'></div>")
            .append($("<h2>Summary</h2>"))
            .append($("<p></p>")
                .text(highlighted));
        $('#content').after(result);
    })
}
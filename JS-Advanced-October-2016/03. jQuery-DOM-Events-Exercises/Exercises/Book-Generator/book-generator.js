"use strict";

let createBook = (function () {
    let counter = 1;

    return function (selector, bookTitle, bookAuthor, bookISBN) {
        let mainDiv = $(`<div id="book${counter}"></div>`)
            .append($('<p class="title"></p>').text(bookTitle))
            .append($('<p class="author"></p>').text(bookAuthor))
            .append($('<p class="isbn"></p>').text(bookISBN))
            .append($('<button>Select</button>').on('click', function () {
                $(this).parent().css('border', '2px solid blue')
            }))
            .append($('<button>Deselect</button>').on('click', function () {
                $(this).parent().css('border', '')
            }));

        ++counter;
        $(selector).append(mainDiv);
    }
})();
"use strict";

function domSearch(content, isCaseSensitive) {
    let addControlDiv = $('<div class="add-controls"></div>')
        .append($('<label>Enter text:</label>')
            .append($('<input>'))
        )
        .append($('<a class="button">Add</a>')
            .on('click', addNewItem)
        );
    let searchControlDiv = $('<div class="search-controls"></div>')
        .append($('<label>Search:</label>')
            .append($('<input>')
                .on('input', searchItem))
        );
    let resultControlDiv = $('<div class="result-controls"></div>')
        .append($('<ul class="items-list"></ul>'));

    $(content)
        .append(addControlDiv)
        .append(searchControlDiv)
        .append(resultControlDiv);

    function addNewItem() {
        let inputText = $(this).parent().find('input').val();
        let newListItem = $('<li class="list-item"></li>')
            .append($('<a class="button">X</a>').on('click', deleteItem))
            .append($('<strong>').text(inputText));

        $('.items-list').append(newListItem);
    }

    function deleteItem() {
        let currentListItem = $(this).parent();
        currentListItem.remove();
    }

    function searchItem() {
        let searchText = $(this).val();
        $('.items-list li').each(function (index, element) {
            let firstElementCompare = $(element).text();
            let secondElementCompare = searchText;

            if (!isCaseSensitive) {
                firstElementCompare = firstElementCompare.toLowerCase();
                secondElementCompare = secondElementCompare.toLowerCase();
            }

            if (firstElementCompare.indexOf(secondElementCompare) == -1) {
                $(element).css('display', 'none');
            } else {
                $(element).show();
            }
        })
    }
}
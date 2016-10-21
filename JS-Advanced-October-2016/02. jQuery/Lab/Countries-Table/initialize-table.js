"use strict";

function initializeTable() {
    $('#createLink').click(function () {
        let country = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();

        createItem(country, capital);
    });

    createItem('Bulgaria', 'Sofia');
    createItem('Germany', 'Berlin');
    createItem('Russia', 'Moscow');

    function createItem(country, capital) {
        let newRow = $('<tr>');
        newRow.append($('<td>').text(country));
        newRow.append($('<td>').text(capital));

        let functionalityColumn = $('<td>');
        functionalityColumn.append($('<a href="#">[Up]</a>').click(moveUp));
        functionalityColumn.append(' ');
        functionalityColumn.append($('<a href="#">[Down]</a>').click(moveDown));
        functionalityColumn.append(' ');
        functionalityColumn.append($('<a href="#">[Delete]</a>').click(deleteItem));

        newRow.append(functionalityColumn);
        newRow.css('display', 'none').appendTo($('#countriesTable')).fadeIn();

        correctLinks();
    }

    function deleteItem() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            this.remove();
            correctLinks();
        });
    }

    function moveUp() {
        let row = $(this).parent().parent();
        let rowBeforeThePrevious = row.prev().prev();

        row.fadeOut(function () {
            rowBeforeThePrevious.after(row);
            row.css('display', 'inline');
            correctLinks();
        });
    }

    function moveDown() {
        let row = $(this).parent().parent();
        let nextRow = row.next();

        row.fadeOut(function () {
            nextRow.after(row);
            row.css('display', 'inline');
            correctLinks();
        });
    }

    function correctLinks() {
        let allLink = $('#countriesTable a');
        let firstUpLink = $('#countriesTable tr:nth-child(3) a:contains("Up")');
        let lastDownLink = $('#countriesTable tr:last-child a:contains("Down")');

        allLink.css('display', 'inline');
        firstUpLink.css('display', 'none');
        lastDownLink.css('display', 'none');
    }
}
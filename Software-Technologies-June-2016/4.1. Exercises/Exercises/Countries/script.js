function addCountryToTable(country, capital) {
    let row = $("<tr>")
        .append($("<td>").text(country))
        .append($("<td>").text(capital))
        .append($("<td>")
            .append($("<a href='#' onclick='moveRowUp(this)'>[Up]</a>"))
            .append(" ")
            .append($("<a href='#' onclick='moveRowDown(this)'>[Down]</a>"))
            .append(" ")
            .append($("<a href='#' onclick='deleteRow(this)'>[Delete]</a>"))
        );
    $("#countriesTable").append(row);
    return row;
}

function addCountry() {
    let country = $("#newCountryText");
    let capital = $("#newCapitalText");
    let row = addCountryToTable(country.val(), capital.val());
    row.hide();
    row.fadeIn();
    country.val('');
    capital.val('');
    fixRowLinks();
}

function deleteRow(link) {
    let row = $(link).parent().parent();
    row.fadeOut(function () {
        row.remove();
        row.fadeIn();
        fixRowLinks();
    });
}

function moveRowUp(link) {
    let row = $(link).parent().parent();
    row.fadeOut(function () {
        row.insertBefore(row.prev());
        row.fadeIn();
        fixRowLinks();
    });
}

function moveRowDown(link) {
    let row = $(link).parent().parent();
    row.fadeOut(function () {
        row.insertAfter(row.next());
        row.fadeIn();
        fixRowLinks();
    });
}

function fixRowLinks() {
    // Show all links in the table.
    $("#countriesTable a").show();

    // Hide [Up] link in first table row after.
    let tableRow = $("#countriesTable tr");
    $(tableRow[1]).find("a:contains('Up')").hide();

    // Hide the [Down] link in the last table row.
    $(tableRow[tableRow.length - 1]).find("a:contains('Down')").hide();
}

// Tests input.
(function () {
    addCountryToTable("Bulgaria", "Sofia");
    addCountryToTable("Germany", "Berlin");
    addCountryToTable("Russia", "Moscow");
    addCountryToTable("France", "Paris");
    addCountryToTable("India", "Delhi");
    fixRowLinks();
})();
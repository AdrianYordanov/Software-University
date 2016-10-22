"use strict";

function calendar([day, month, year]) {
    let initDate = new Date(year, month - 1, day);
    let lastDay = new Date(year, month, 0).getDate();
    let firstDayOfWeekNumber = new Date(year, month - 1, 1).getDay() || 7;

    let readyTable = getTable(initDate, lastDay, firstDayOfWeekNumber);
    $('#content').append(readyTable);

    function getTable(date, lastDayOfMonth, firstDayWeekNumber) {
        let monthsName = ["January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"];

        let year = date.getFullYear();
        let currentMonthName = monthsName[date.getMonth()];

        let table = $('<table>')
            .append($('<caption>').text(`${currentMonthName} ${year}`));
        let tableBody = $('<tbody>');
        let tableRowHeaders = $('<tr>');

        ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
            .forEach(day => tableRowHeaders.append($(`<th>${day}</th>`)));

        tableBody.append(tableRowHeaders);

        for (let daysIterator = 1, numberOfWeek = 1; daysIterator <= lastDayOfMonth; ++numberOfWeek) {
            let tableRow = $('<tr>');

            for(let weekDay = 1; weekDay <= 7; ++weekDay) {
                let tableData = $('<td>');

                if ((numberOfWeek == 1 && weekDay < firstDayWeekNumber) || (daysIterator > lastDayOfMonth)) {
                    tableRow.append(tableData);
                    continue;
                }

                if (daysIterator == date.getDate()) {
                    tableData.addClass('today');
                }

                tableData.text(daysIterator);
                tableRow.append(tableData);
                ++daysIterator;
            }

            tableBody.append(tableRow);
        }

        table.append(tableBody);
        return table;
    }
}
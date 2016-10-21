"use strict";

function calendar([day, month, year]) {
    let currentMonth = {};
    currentMonth.date = new Date(year, month - 1, day);
    currentMonth.lastDay = new Date(currentMonth.date.getFullYear(), currentMonth.date.getMonth() + 1, 0).getDate();
    currentMonth.firstDayNumberInTheWeek = new Date(currentMonth.date.getFullYear(), currentMonth.date.getMonth(), 1).getDay();
    currentMonth.lastDayNumberInTheWeek = new Date(currentMonth.date.getFullYear(), currentMonth.date.getMonth() + 1, 0).getDay();

    let previousMonth = {};
    previousMonth.date = new Date(currentMonth.date.getFullYear(), currentMonth.date.getMonth() - 1, 1);
    previousMonth.lastDay = new Date(previousMonth.date.getFullYear(), previousMonth.date.getMonth() + 1, 0).getDate();

    // Print the calendar header.
    let html = '<table>\n  <tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n';


    // Print the days of the previous month (if it has).
    if (currentMonth.firstDayNumberInTheWeek > 0) {
        html += '  <tr>';
        for (let previousMonthDayIterator = previousMonth.lastDay - currentMonth.firstDayNumberInTheWeek + 1;
             previousMonthDayIterator <= previousMonth.lastDay; ++previousMonthDayIterator) {
            html += `<td class="prev-month">${previousMonthDayIterator}</td>`;
        }
    }

    // Print the days of the current month.
    let currentMonthDayIterator = 1;
    // If-statement to finish the firs line.
    if (currentMonth.firstDayNumberInTheWeek > 0) {
        for (let column = currentMonth.firstDayNumberInTheWeek; column <= 6; ++column, ++currentMonthDayIterator) {
            if (currentMonthDayIterator == currentMonth.date.getDate()) {
                html += `<td class="today">${currentMonthDayIterator}</td>`;
            } else {
                html += `<td>${currentMonthDayIterator}</td>`;
            }
        }
        html += '</tr>\n';
    }
    while (currentMonthDayIterator <= currentMonth.lastDay) {
        html += '  <tr>';
        let column = 0;
        for (; column < 7 && currentMonthDayIterator <= currentMonth.lastDay; ++column, ++currentMonthDayIterator) {
            if (currentMonthDayIterator == currentMonth.date.getDate()) {
                html += `<td class="today">${currentMonthDayIterator}</td>`;
            } else {
                html += `<td>${currentMonthDayIterator}</td>`;
            }
        }
        if (column == 7) {
            html += '</tr>\n';
        }
    }

    // Print hte days of the next month (if it has)
    if (currentMonth.lastDayNumberInTheWeek < 6) {
        for (let nextMonthDayIterator = 1; nextMonthDayIterator <= 6 - currentMonth.lastDayNumberInTheWeek; ++nextMonthDayIterator) {
            html += `<td class="next-month">${nextMonthDayIterator}</td>`;
        }
        html += '</tr>\n';
    }

    html += '</table>';
    return html;
}
"use strict";

function lastMonth([day, month, year]) {
    let date = new Date(year, month, day);
    let previousDay = new Date(date.getFullYear(), date.getMonth() - 1, 0).getDate();

    console.log(previousDay);
}

lastMonth(['17','3','2002']);
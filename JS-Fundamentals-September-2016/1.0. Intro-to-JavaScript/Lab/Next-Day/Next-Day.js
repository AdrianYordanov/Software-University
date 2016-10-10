"use strict";

function nextDay([year, month, day]) {
    let date = new Date(year - 0, month - 1, day - 0);
    date.setTime(date.getTime() + 86400000);
    console.log(`${date.getUTCFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

nextDay(['1901', '1', '1']);
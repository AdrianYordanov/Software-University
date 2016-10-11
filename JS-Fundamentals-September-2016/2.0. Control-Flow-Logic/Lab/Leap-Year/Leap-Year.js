"use strict";

function leapYear([year]) {
    let isLeap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

    if(isLeap)
        console.log('yes');
    else
        console.log('no');
}

leapYear(['1990']);
"use strict";

function rounding(array) {
    let [number, precision] = array.map(Number);

    let temp = Math.pow(10, precision);
    let result = Math.round(number * temp) / temp;
    console.log(result);
}

rounding(['3.1415926535897932384626433832795', '2']);
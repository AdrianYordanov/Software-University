"use strict";

function sumFirstLast(array) {
    let numbers = array.map(Number);
    let result = numbers[0] + numbers[numbers.length - 1];
    console.log(result);
}

sumFirstLast(['20', '30', '40']);
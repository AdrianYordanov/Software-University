"use strict";

function modifyAverage(input) {
    let num = input;

    function calcAvg() {
        let result = num;
        let sum = 0;
        let count = 0;
        while (result > 0) {
            sum += result % 10;
            result = (result - result % 10) / 10;
            count++;
        }
        return sum / count;
    }

    function addNine() {
        return num * 10 + 9;
    }

    while (calcAvg() <= 5) {
        num = addNine();
    }
    console.log(num);
}

modifyAverage('5555');
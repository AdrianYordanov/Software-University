"use strict";

function functionalCalculator([arg1,arg2, operator]) {
    [arg1, arg2] = [arg1, arg2].map(Number);

    let calculating = function (a, b, operation) {
        return operation(a, b);
    };

    let summing = function (a, b) {
        return a + b;
    };
    let difference = function (a, b) {
        return a - b;
    };
    let multiplication = function (a, b) {
        return a * b;
    };
    let division = function (a, b) {
        return a / b;
    };

    switch (operator) {
        case '+':
            console.log(calculating(arg1, arg2, summing));
            break;
        case '-':
            console.log(calculating(arg1, arg2, difference));
            break;
        case '*':
            console.log(calculating(arg1, arg2, multiplication));
            break;
        case '/':
            console.log(calculating(arg1, arg2, division));
            break;
    }
}

functionalCalculator(['3', '4', '/']);
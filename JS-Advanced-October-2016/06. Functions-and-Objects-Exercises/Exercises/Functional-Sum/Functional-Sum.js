"use strict";

let functionalSum = (function () {
    let hidden = 0;

    return function addNumber(number) {
        hidden += number;
        addNumber.toString = () => hidden;
        return addNumber;
    }
})();

console.log(functionalSum(5)(5)(-4));
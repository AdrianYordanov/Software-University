"use strict";

function aggregateElements(array) {
    array = array.map(Number);

    aggregate(array, 0, (a, b) => a + b);
    aggregate(array, 0, (a, b) => a + (1 / b));
    aggregate(array, '', (a, b) => a + b);

    function aggregate(numbers, initValue, operation) {
        let result = initValue;

        for (let number of numbers) {
            result = operation(result, number);
        }

        console.log(result);
    }
}

aggregateElements(['1', '2', '3']);
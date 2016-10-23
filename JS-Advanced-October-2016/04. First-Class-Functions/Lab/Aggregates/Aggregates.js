"use strict";

function aggregates(numbers) {
    console.log('Sum = ' + reduce(numbers, (a, b) => a + b));
    console.log('Min = ' + reduce(numbers, (a, b) => Math.min(a, b)));
    console.log('Max = ' + reduce(numbers, (a, b) => Math.max(a, b)));
    console.log('Product = ' + reduce(numbers, (a, b) => a * b));
    console.log('Join = ' + reduce(numbers, (a, b) => '' + a + b));


    function reduce(array, action) {
        let result = array[0];

        for (let value of array.slice(1)) {
            result = action(result, value);
        }

        return result;
    }
}

aggregates([2, 3, 10, 5]);
"use strict";

function fibonacci(number) {
    let fibonacciExecution = (function () {
        let previous = 1;
        let beforePrevious = 0;

        return function () {
            let temp = previous;
            previous += beforePrevious;
            beforePrevious = temp;
            return beforePrevious;
        }
    })();
    let array = [];

    for (let i = 0; i < number; ++i) {
        array.push(fibonacciExecution());
    }

    return array;
}

fibonacci(15);
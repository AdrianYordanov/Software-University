"use strict";

function* fibonacciGenerator() {
    let current = 1;
    let next = 1;

    while (true) {
        yield current;
        [current, next] = [next, current + next];
    }
}

let fib = fibonacciGenerator();
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
console.log(fib.next().value);
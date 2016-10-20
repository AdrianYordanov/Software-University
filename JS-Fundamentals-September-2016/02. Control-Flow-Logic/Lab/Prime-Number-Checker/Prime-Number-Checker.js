"use strict";

function isPrime(array) {
    let number = Number(array[0]);

    if (number < 2) {
        console.log('false');
        return;
    }

    if (number % 2 == 0) {
        console.log(number == 2);
        return;
    }

    let root = Math.sqrt(number);
    for (let i = 3; i <= root; i += 2)
    {
        if (number % i == 0) {
            console.log('false');
            return;
        }
    }

    console.log('true');
}

isPrime(['10']);
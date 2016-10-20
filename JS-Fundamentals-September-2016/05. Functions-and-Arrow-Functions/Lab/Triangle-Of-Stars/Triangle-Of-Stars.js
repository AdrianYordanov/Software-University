"use strict";

function triangleOfStars(array) {
    let number = Number(array[0]);

    for (let i = 1; i <= number; ++i)
        console.log('*'.repeat(i))

    for (let i = number - 1; i >= 1; --i)
        console.log('*'.repeat(i));
}

triangleOfStars(['1']);
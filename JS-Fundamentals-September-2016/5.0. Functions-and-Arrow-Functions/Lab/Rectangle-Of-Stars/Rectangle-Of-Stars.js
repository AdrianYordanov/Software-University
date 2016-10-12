"use strict";

function rectangleOfStars(array) {
    let number = 5;

    if(arguments.length > 0)
        number = Number(array[0]);

    for(let i = 0; i < number; ++i) {
        console.log('* '.repeat(number));
    }
}

rectangleOfStars(['5']);
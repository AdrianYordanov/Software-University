"use strict";

function oddOrEven(array) {
    let number = Number(array[0]);

    if(number !== Math.round(number))
        console.log('invalid');
    else if(number % 2 == 0)
        console.log('even');
    else
        console.log('odd');
}

oddOrEven(['-3']);
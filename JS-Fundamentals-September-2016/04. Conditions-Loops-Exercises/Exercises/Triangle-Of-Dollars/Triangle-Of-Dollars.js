"use strict";

function triangleOfDollars([number]) {
    let n = Number(number);

    for(let i = 1; i <= n; ++i) {
        console.log('$'.repeat(i));
    }
}

triangleOfDollars(['3']);
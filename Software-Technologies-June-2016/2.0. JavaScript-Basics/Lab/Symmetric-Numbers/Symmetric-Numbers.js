"use strict";

function run(array) {
    let number = Number(array[0]);

    for(let i = 1; i <= number; ++i) {
        if(i == reverse(i)) {
            console.log(i);
        }
    }

    function reverse(number) {
        let str = number.toString();
        return str.split('').reverse().join('');
    }
}

run(['600']);
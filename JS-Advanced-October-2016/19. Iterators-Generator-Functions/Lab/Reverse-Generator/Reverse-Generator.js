"use strict";

function* reverseArrayGenerator(arr) {
    for (let i = arr.length - 1; i >= 0; i--)
        yield arr[i];
}

let arr = [10, 20, 30];
for (let item of reverseArrayGenerator(arr)) {
    console.log(item);
}
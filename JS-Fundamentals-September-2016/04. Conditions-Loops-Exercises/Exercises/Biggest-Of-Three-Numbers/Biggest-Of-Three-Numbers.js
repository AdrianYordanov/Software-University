"use strict";

function biggestOfThreeNumbers(array) {
    // We take first for the biggest.
    let [biggestNumber, second, third] = array.map(Number);

    if(biggestNumber < second) {
        biggestNumber = second;
    }

    if(biggestNumber < third) {
        biggestNumber = third;
    }

    console.log(biggestNumber);
}

biggestOfThreeNumbers(['5', '-2', '7']);
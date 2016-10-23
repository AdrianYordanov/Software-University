"use strict";

function maxElement(array) {
    let maxNumber = Math.max.apply(null, array);
    return maxNumber;
}

maxElement([4, 6, 2, -45, 656, 34]);
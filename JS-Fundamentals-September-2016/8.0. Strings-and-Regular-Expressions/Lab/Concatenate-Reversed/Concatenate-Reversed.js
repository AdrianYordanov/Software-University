"use strict";

function concatenateReversed(array) {
    let joinedString = array.join('');
    let reversedString = Array.from(joinedString).reverse().join('');

    console.log(reversedString);
}

concatenateReversed(['I', 'am', 'student']);
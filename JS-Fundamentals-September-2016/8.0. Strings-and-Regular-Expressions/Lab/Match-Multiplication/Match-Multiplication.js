"use strict";

function matchMultiplication([text]) {
    let regex = /(-?\d+)\s*\*\s*(-?\d+(\.\d+)?)/g;
    let result = text.replace(regex, (match, firstNumber, secondNumber) => firstNumber * secondNumber);

    console.log(result);
}

matchMultiplication(['My bill: 2*2.50 (beer); 2* 1.20 (kepab); -2  * 0.5 (deposit).']);
"use strict";

function run(array) {
    let numbers = array[0].split(' ').map(Number);
    console.log(
        checkSum(numbers[1], numbers[2], numbers[0]) ||
        checkSum(numbers[2], numbers[0], numbers[1]) ||
        checkSum(numbers[0], numbers[1], numbers[2]) ||
        "No"
    );

    function checkSum(firstNumber, secondNumber, thirdNumber) {
        if((firstNumber + secondNumber) == thirdNumber) {
            if(firstNumber > secondNumber) {
                [firstNumber, secondNumber] = [secondNumber, firstNumber];
            }

            return `${firstNumber} + ${secondNumber} = ${thirdNumber}`;
        }

        return false;
    }
}

run(['20 10 30']);
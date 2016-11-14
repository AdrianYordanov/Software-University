"use strict";

function calculate(array) {
    let numbers = array.map(Number);
    let biggestProduct = Number.NEGATIVE_INFINITY;

    for(let index = 0; index < numbers.length; ++index) {
        let currentNumber = numbers[index];

        if(currentNumber > 0 && currentNumber < 10) {
            let currentProduct = 1;

            for(let iterationCounter = 0, nestedIndex = index + 1; iterationCounter < currentNumber; ++iterationCounter, ++nestedIndex) {
                currentProduct *= numbers[nestedIndex];
            }

            if(currentProduct > biggestProduct)
                biggestProduct = currentProduct;
        }
    }

    console.log(biggestProduct);
}

calculate([
    '10',
    '20',
    '2',
    '30',
    '44',
    '123',
    '3',
    '56',
    '20',
    '24'
]);

calculate([
    '100',
    '200',
    '2',
    '3',
    '2',
    '3',
    '2',
    '1',
    '1',
]);
"use strict";

function aggregateTable(array) {
    let towns = [];
    let sum = 0;

    for (let str of array) {
        let tokens = str.split('|');
        let town = tokens[1].trim();
        let price = tokens[2].trim();
        towns.push(town);
        sum += Number(price);
    }

    console.log(towns.join(', '));
    console.log(sum);
}

aggregateTable([
    '| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275'
]);
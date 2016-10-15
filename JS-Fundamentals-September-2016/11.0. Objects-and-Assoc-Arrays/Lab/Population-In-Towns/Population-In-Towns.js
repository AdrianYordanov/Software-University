"use strict";

function populationInTowns(array) {
    let dictionary = new Map();

    for (let text of array) {
        let pair = text.split(/\s*<->\s*/g);
        let [townName, townPopulation] = [pair[0], Number(pair[1])];

        if (dictionary.has(townName))
            dictionary.set(townName, dictionary.get(townName) + townPopulation);
        else
            dictionary.set(townName, townPopulation);
    }

    for (let [key, value] of dictionary) {
        console.log(`${key} : ${value}`);
    }
}

populationInTowns([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]);
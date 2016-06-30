"use strict";

function run(array) {
    let objects = array.map(JSON.parse);
    let dictionary = {};

    for(let obj of objects) {
        if(obj.town in dictionary) {
            dictionary[obj.town] += obj.income;
        } else {
            dictionary[obj.town] = obj.income;
        }
    }

    let sortedTowns = Object.keys(dictionary).sort();

    for(let town of sortedTowns) {
        console.log(`${town} -> ${dictionary[town]}`);
    }
}

run([
    '{"town":"Sofia","income":200}',
    '{"town":"Varna","income":120}',
    '{"town":"Pleven","income":60}',
    '{"town":"Varna","income":70}'
]);
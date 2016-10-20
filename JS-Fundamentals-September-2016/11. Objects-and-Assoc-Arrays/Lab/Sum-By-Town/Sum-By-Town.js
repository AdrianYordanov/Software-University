"use strict";

function sumByTown(array) {
    let dictionary = {};

    for (let i = 0; i < array.length; i += 2) {
        let [town, sum] = [array[i], Number(array[i + 1])];
        dictionary[town] ? dictionary[town] += sum : dictionary[town] = sum;
    }

    console.log(JSON.stringify(dictionary));
}

sumByTown(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);
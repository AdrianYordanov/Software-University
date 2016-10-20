"use strict";

function townsToJSON(array) {
    array.shift();
    let townsArray = [];

    for(let currentTown of array) {
        let [empty, town, latitude, longitude] = currentTown
            .split(/\s*\|\s*/g);
        townsArray.push({
            'Town': town,
            'Latitude': Number(latitude),
            'Longitude': Number(longitude)
        });
    }

    console.log(JSON.stringify(townsArray));
}

townsToJSON([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'
]);
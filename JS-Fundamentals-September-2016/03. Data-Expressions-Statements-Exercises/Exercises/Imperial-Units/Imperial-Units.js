"use strict";

function imperialUnits(array) {
    let inches = Number(array[0]);

    let resultFoots = Math.floor(inches / 12);
    let resultInches = inches % 12;

    console.log(`${resultFoots}'-${resultInches}"`);
}

imperialUnits(['55']);
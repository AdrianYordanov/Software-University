"use strict";

function boxesAndBottles([bottles, boxCapacity]) {
    let result = Math.ceil(bottles / boxCapacity);
    console.log(result);
}

boxesAndBottles(['15', '7']);
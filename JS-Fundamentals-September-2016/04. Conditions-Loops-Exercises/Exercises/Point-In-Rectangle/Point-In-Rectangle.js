"use strict";

function pointInRectangle(array) {
    let [x, y, xMin, xMax, yMin, yMax] = array.map(Number);

    if(x >= xMin && x <= xMax && y >= yMin && y <= yMax)
        console.log('inside');
    else
        console.log('outside');
}

pointInRectangle([8, -1, 2, 12, -3, 3]);
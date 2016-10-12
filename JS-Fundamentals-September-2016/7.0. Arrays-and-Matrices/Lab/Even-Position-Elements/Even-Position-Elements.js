"use strict";

function evenPositionElements(array) {
    let result = array
        .filter((x, i) => i % 2 == 0);
    console.log(result.join(' '));
}

evenPositionElements(['20', '30', '40']);
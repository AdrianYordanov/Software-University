"use strict";

function areaAndPerimeter(array) {
    let [a, b] = [Number(array[0]), Number(array[1])];

    let area = a * b;
    let perimeter = 2 * a + 2 * b;

    console.log(area);
    console.log(perimeter);
}

areaAndPerimeter(['2', '3']);
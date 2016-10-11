"use strict";

function triangleAreaByThreeSides(array) {
    let a = Number(array[0]);
    let b = Number(array[1]);
    let c = Number(array[2]);

    let p = (a + b + c) / 2;
    let area = Math.sqrt(p * (p - a) * (p - b) * (p - c));
    console.log(area);
}

triangleAreaByThreeSides(['2', '3.5', '4']);
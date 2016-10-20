"use strict";

function circleArea([radius]) {
    let area = Math.PI * radius * radius;
    let roundedArea = Math.round(area * 100) / 100;
    console.log(area);
    console.log(roundedArea);
}

circleArea(['5']);
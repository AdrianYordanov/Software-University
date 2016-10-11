"use strict";

function cone([radius, height]) {
    let volume = (1 / 3) * (Math.PI * radius * radius * height);
    let lateral = Math.PI * radius * Math.sqrt((radius * radius) + (height * height));
    let base = Math.PI * radius * radius;
    let area = lateral + base;

    console.log(`volume = ${volume}`);
    console.log(`area = ${area}`);
}

cone(['3', '5']);
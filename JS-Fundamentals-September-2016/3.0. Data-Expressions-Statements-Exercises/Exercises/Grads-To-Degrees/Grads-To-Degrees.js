"use strict";

function gradsToDegrees(array) {
    let grads = Number(array[0]);

    grads = grads % 400;

    if (grads < 0) {
        grads += 400;
    }

    let degrees = grads / ((Math.PI / 180) / (Math.PI / 200));
    console.log(degrees);
}

gradsToDegrees(['100']);
"use strict";

function distanceIn3D(array) {
    let [x1, y1, z1] = [Number(array[0]), Number(array[1]), Number(array[2])];
    let [x2, y2, z2] = [Number(array[3]), Number(array[4]), Number(array[5])];

    let distance = Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
    console.log(distance);
}

distanceIn3D(['1', '1', '0', '5', '4', '0']);
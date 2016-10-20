"use strict";

function distanceOverTime(array) {
    let timeInHours = Number(array[2]) / 3600;
    let firstObjectDistance = Number(array[0]) * timeInHours;
    let secondObjectDistance = Number(array[1]) * timeInHours;

    let distanceInMeters = Math.abs(firstObjectDistance - secondObjectDistance) * 1000;
    console.log(distanceInMeters);
}

distanceOverTime(['0', '60', '3600']);
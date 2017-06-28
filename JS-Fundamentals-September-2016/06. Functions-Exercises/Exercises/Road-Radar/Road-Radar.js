"use strict";

function roadRadar(input) {
    let speed = Number(input[0]);
    let limitation = String(input[1]);
    let checkSpeed = 0;

    switch (limitation) {
        case "residential":
            checkSpeed = 20;
            break;
        case "city":
            checkSpeed = 50;
            break;
        case "interstate":
            checkSpeed = 90;
            break;
        case "motorway":
            checkSpeed = 130;
            break;
    }

    if (speed > checkSpeed) {
        if (speed <= checkSpeed + 20) {
            console.log('speeding');
        }
        else if (speed > checkSpeed + 20 && speed <= checkSpeed + 40) {
            console.log('excessive speeding');
        }
        else if (speed > checkSpeed + 40) {
            console.log('reckless driving');
        }
    }
}

roadRadar(['180', 'residential']);
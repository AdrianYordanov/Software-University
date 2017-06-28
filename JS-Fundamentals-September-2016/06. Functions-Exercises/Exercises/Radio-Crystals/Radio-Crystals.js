"use strict";

function radioCrystals(input) {
    let desireThickness = Number(input[0]);

    for (let i = 1; i < input.length; i++) {
        let startingThiknes = Number(input[i]);
        let counter = 0;
        console.log('Processing chunk ' + startingThiknes + ' microns');

        while (startingThiknes / 4 >= desireThickness) {
            startingThiknes /= 4;
            counter++;
        }
        if (counter != 0) {
            console.log('Cut x' + counter);
            console.log('Transporting and washing');
            if (startingThiknes == desireThickness) {
                console.log('Finished crystal ' + startingThiknes + ' microns');
            }
            counter = 0;
        }
        startingThiknes = Math.floor(startingThiknes);

        while (startingThiknes * 0.8 >= desireThickness) {
            startingThiknes *= 0.8;
            counter++;
        }
        if (counter != 0) {
            console.log('Lap x' + counter);
            console.log('Transporting and washing');
            if (startingThiknes == desireThickness) {
                console.log('Finished crystal ' + startingThiknes + ' microns');
            }
            counter = 0;
            startingThiknes = Math.floor(startingThiknes);
        }

        while (startingThiknes - 20 >= desireThickness) {
            startingThiknes -= 20;
            counter++;
        }
        if (counter != 0) {
            console.log('Grind x' + counter);
            console.log('Transporting and washing');

            if (startingThiknes == desireThickness) {
                console.log('Finished crystal ' + startingThiknes + ' microns');
                break
            }
            counter = 0;
            startingThiknes = Math.floor(startingThiknes);
        }


        while (startingThiknes - 1 >= desireThickness) {
            startingThiknes -= 2;
            counter++;
        }
        if (counter != 0) {
            console.log('Etch x' + counter);
            console.log('Transporting and washing');
            if (startingThiknes == desireThickness) {
                console.log('Finished crystal ' + startingThiknes + ' microns');
                break
            }
            counter = 0;
        }
        startingThiknes = Math.floor(startingThiknes);


        if (startingThiknes + 1 == desireThickness) {
            console.log('X-ray x1');
            console.log('Finished crystal ' + Number(startingThiknes + 1) + ' microns');
        }
    }
}

radioCrystals(['100', '100.1', '101.9', '102']);
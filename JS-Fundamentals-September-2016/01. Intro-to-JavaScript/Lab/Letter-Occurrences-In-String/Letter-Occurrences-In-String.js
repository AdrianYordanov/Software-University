"use strict";

function letterOccurrencesInString([string, letter]) {
    let counter = 0;

    for(let currentLetter of string) {
        if(currentLetter === letter) {
            ++counter;
        }
    }

    console.log(counter);
}

letterOccurrencesInString(['hello', 'l']);
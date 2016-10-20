"use strict";

function matchTheDates(array) {
    let dateRegex = /\b([0-9]{1,2})-([A-Z][a-z]{2})-([0-9]{4})\b/g;
    let foundDate;

    for (let sentence of array) {
        while (foundDate = dateRegex.exec(sentence)) {
            console.log(`${foundDate[0]} (Day: ${foundDate[1]}, Month: ${foundDate[2]}, Year: ${foundDate[3]})`);
        }
    }
}

matchTheDates(['1-Jan-1999 is a valid date. So is 01-July-2000. I am an awful liar, by the way – Ivo, 28-Sep-2016.']);
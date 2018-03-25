"use strict";

function* lookAndSayGenerator(number) {
    number = number.toString();

    while (true) {
        if (number.length === 1) {
            number = "" + 1 + number[0];
            yield number;
        } else {
            let prev = number[0];
            number = number.substr(1);
            let newNumber = "";
            let counter = 1;
            while (number) {
                let current = number.charAt(0);
                if (current === prev) {
                    counter++;
                } else {
                    newNumber += "" + counter + prev;
                    counter = 1;
                }

                if (number.length === 1) {
                    newNumber += counter + current;
                }
                number = number.substr(1);
                prev = current;
            }

            number = newNumber;
            yield number;
        }
    }
}

let lookSequence = lookAndSayGenerator(1);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
console.log(lookSequence.next().value);
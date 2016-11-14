"use strict";

function spyMaster(array) {
    let specialKey = array.shift();
    let firstRegex = new RegExp(`((?: |^)${specialKey}[ ]+)([!#$%A-Z]{8,})([ \\.\\,]|$)`, "gi");

    for (let text of array) {
        let result = text.replace(firstRegex, function (full, specialKeyAndInterval, message, endInterval) {
            if (!/[a-z]/.test(message)) {
                message = message
                    .replace(/!/g, '1')
                    .replace(/%/g, '2')
                    .replace(/#/g, '3')
                    .replace(/\$/g, '4')
                    .toLocaleLowerCase()
            }

            return specialKeyAndInterval + message + endInterval;
        });
        console.log(result);
    }
}

spyMaster([
    'specialKey',
    'In this text the specialKey HELLOWORLD! is correct, but',
    'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
    'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!',
    'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$'
]);
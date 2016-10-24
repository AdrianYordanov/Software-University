"use strict";

function argumentInfo() {
    let typesCounter = {};

    for (let i = 0; i < arguments.length; ++i) {
        let currentArg = arguments[i];
        let type = typeof currentArg;
        console.log(type + ': ' + currentArg);

        if (!typesCounter[type]) {
            typesCounter[type] = 1;
        } else {
            typesCounter[type]++;
        }
    }

    let sortedTypes = Object.keys(typesCounter).sort((a, b) => typesCounter[b] - typesCounter[a]);
    sortedTypes.forEach(type => console.log(`${type} = ${typesCounter[type]}`));
}

argumentInfo({ name: 'bob'}, 3.333, 9.999);
"use strict";

function cars(commands) {
    let executor = (function () {
        let map = new Map();

        function createObject([name, , parentName]) {
            let parentObject = map.get(parentName) || null;
            let createdObject = Object.create(parentObject);
            map.set(name, createdObject);
        }

        function setPropertyToObject([name, key, value]) {
            map.get(name)[key] = value;
        }

        function printObject([name]) {
            let currentObject = map.get(name);
            let properties = Object.keys(currentObject);

            for (let parentObject = Object.getPrototypeOf(currentObject);
                 parentObject;
                 parentObject = Object.getPrototypeOf(parentObject)) {
                // Start for loop.
                let parentObjectProperties = Object.keys(parentObject);
                parentObjectProperties.forEach(function (prop) {
                    if (properties.indexOf(prop) === -1) {
                        properties.push(prop);
                    }
                });
            }

            let resultText = properties.map(prop => `${prop}:${currentObject[prop]}`).join(', ');
            console.log(resultText);
        }

        return {
            create: createObject,
            set: setPropertyToObject,
            print: printObject
        }
    })();

    for (let command of commands) {
        let commandArguments = command.split(' ');
        let commandName = commandArguments.shift();
        executor[commandName](commandArguments);
    }
}

cars([
    'create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
]);
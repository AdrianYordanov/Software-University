"use strict";

function radicalMarketing(array) {
    let dictionary = new Map();

    for (let command of array) {
        if (command.indexOf('-') == -1) {
            if (dictionary.has(command))
                continue;
            dictionary.set(command, new Set());
        }
        else {
            let tokens = command.split('-');
            let [firstPerson, secondPerson] = [tokens[0], tokens[1]];

            if (firstPerson == secondPerson || !dictionary.has(firstPerson) || !dictionary.has(secondPerson))
                continue;

            dictionary.get(secondPerson).add(firstPerson);
        }
    }

    let winnerName = '',
        winnerCountSubscribers = -1;

    for (let [name, subscribers] of dictionary) {
        let currentCount = subscribers.size;

        if (winnerCountSubscribers < currentCount) {
            winnerName = name;
            winnerCountSubscribers = currentCount;
        } else if (winnerCountSubscribers == currentCount) {
            if (foundSubscriptions(winnerName) < foundSubscriptions(name)) {
                winnerName = name;
                winnerCountSubscribers = currentCount;
            }
        }
    }

    printWinner(winnerName, dictionary);

    function printWinner(name, dict) {
        console.log(name);

        let winnerSubscribers = Array.from(dict.get(name));

        for (let index = 0; index < winnerSubscribers.length; ++index)
            console.log(`${index + 1}. ${winnerSubscribers[index]}`);
    }

    function foundSubscriptions(wantedName) {
        let counter = 0;

        for (let [name, subscribers] of dictionary) {
            if (name == wantedName) {
                continue;
            }

            if (dictionary.get(name).has(wantedName)) {
                ++counter;
            }
        }

        return counter;
    }
}

radicalMarketing([
    'J',
    'G',
    'P',
    'R',
    'C',
    'P-G',
    'J-G',
    'G-J',
    'P-R',
    'R-P',
    'C-J'
]);
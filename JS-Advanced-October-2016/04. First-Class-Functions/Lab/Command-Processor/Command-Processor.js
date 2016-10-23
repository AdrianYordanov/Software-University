"use strict";

function commandProcessor(commands) {
    let executor = (function () {
        let text = '';

        return {
            append: (appendText) => text += appendText,
            removeStart: (count) => text = text.slice(count),
            removeEnd: (count) => text = text.slice(0, text.length - count),
            print: () => console.log(text)
        }
    })();

    for (let currentCommand of commands) {
        let [commandName, argument] =currentCommand.split(' ');
        executor[commandName](argument);
    }
}

commandProcessor([
    'append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print'
]);
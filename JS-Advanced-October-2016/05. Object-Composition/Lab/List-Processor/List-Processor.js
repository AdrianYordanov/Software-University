"use strict";

function listProcessor(commands) {
    let executor = (function () {
        let nestedArray = [];

        function add(text) {
            nestedArray.push(text);
        }

        function remove(text) {
            nestedArray = nestedArray.filter(element => element != text);
        }

        function print() {
            console.log(nestedArray.join(','));
        }

        return {
            add: add,
            remove: remove,
            print: print
        }
    })();

    for(let command of commands) {
        let [commandName, argument] = command.split(' ');
        executor[commandName](argument);
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);
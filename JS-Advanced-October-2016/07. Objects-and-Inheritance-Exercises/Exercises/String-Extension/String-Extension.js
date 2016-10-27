"use strict";

(function () {
    String.prototype.ensureStart = function (str) {
        let currentString = this.toString();

        if (!currentString.startsWith(str)) {
            currentString = str + currentString;
        }

        return currentString;
    };

    String.prototype.ensureEnd = function (str) {
        let currentString = this.toString();

        if (!currentString.endsWith(str)) {
            currentString = currentString + str;
        }

        return currentString;
    };

    String.prototype.isEmpty = function () {
        return this.toString().length == 0;
    };

    String.prototype.truncate = function (n) {
        let currentString = this.toString();

        if(currentString.length <= n) {
            return currentString;
        }

        if(n < 4) {
            return '.'.repeat(n);
        }

        let tokens = currentString.split(' ');
        let result = tokens.shift();

        // If there is only one word or the first word's length is greater than n.
        if(tokens.length == 0 || result.length + 3 > n) {
            return result.slice(0, n - 3) + '...';
        }

        // If there are more words.
        for (let token of tokens) {
            let nextWordToAppend = " " + token;

            if (result.length + 3 + nextWordToAppend.length > n) {
                return result + '...';
            }

            result += nextWordToAppend;
        }
    };

    // Static method.
    String.format = function () {
        let str = arguments[0];

        for (let i = 1; i < arguments.length; ++i) {
            str = str.split(`{${i - 1}}`).join(arguments[i]);
        }

        return str;
    }
})();

let string = "hello word1 word12 word1234";
console.log(string.truncate(5)); // he...
console.log(string.truncate(10)); // hello...
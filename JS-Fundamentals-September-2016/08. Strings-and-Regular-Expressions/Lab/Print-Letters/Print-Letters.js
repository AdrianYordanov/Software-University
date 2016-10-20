"use strict";

function printLetters([str]) {
    Array
        .from(str)
        .forEach((letter, index) => console.log(`str[${index}] -> ${letter}`));
}

printLetters(['Hello, World!']);
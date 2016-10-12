"use strict";

function wordsUppercase([str]) {
    let result = str
        .toUpperCase()
        .split(/\W+/)
        .filter(word => word != '')
        .join(', ');

    console.log(result);
}

wordsUppercase(['Hi, how are you?']);
"use strict";

function countWordsInText([text]) {
    let dictionary = {};
    let words = text
        .split(/\W+/g)
        .filter(element => element != '')
        .forEach(word => dictionary[word] ? dictionary[word]++ : dictionary[word] = 1);

    console.log(JSON.stringify(dictionary));
}


countWordsInText(["Far too slow, you're far too slow."]);
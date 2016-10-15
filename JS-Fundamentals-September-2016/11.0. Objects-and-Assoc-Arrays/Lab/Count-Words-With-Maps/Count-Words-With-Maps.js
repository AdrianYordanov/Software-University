"use strict";

function countWordsWithMaps([text]) {
    let dictionary = new Map();
    let words = text
        .toLowerCase()
        .split(/\W+/g)
        .filter(element => element != '')
        .forEach(word => dictionary.has(word) ? dictionary.set(word, dictionary.get(word) + 1) : dictionary.set(word, 1));

    let sortedWords = Array
        .from(dictionary.keys())
        .sort()
        .forEach(word => console.log(`'${word}' -> ${dictionary.get(word)} times`));
}

countWordsWithMaps(["Far too slow, you're far too slow."]);
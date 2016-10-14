"use strict";

function censorship(array) {
    let text = array.shift();
    let regex = new RegExp(array.join('|'), 'g');

    text = text.replace(regex, currentSpeech => '-'.repeat(currentSpeech.length));

    console.log(text);
}

censorship(['roses are red, violets are blue', ', violets are', 'red']);
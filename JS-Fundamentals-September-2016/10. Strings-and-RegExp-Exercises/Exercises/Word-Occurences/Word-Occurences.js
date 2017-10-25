'use strict';


function findOccurrencesOfWordInSentence([sentence, word]) {
    let count = 0;
    let regex = new RegExp("\\b"+word+"\\b", "gi");
    let match = regex.exec(sentence);

    while(match) {
        count++;
        match = regex.exec(sentence);
    }

    console.log(count)
}
"use strict";

function extractText([text]) {
    let result = [];

    let leftBracketIndex = text.indexOf('(');
    let rightBracketIndex = text.indexOf(')', leftBracketIndex);

    while (leftBracketIndex > -1 && rightBracketIndex > -1) {
        result.push(text.substring(leftBracketIndex + 1, rightBracketIndex));
        leftBracketIndex = text.indexOf('(', rightBracketIndex);
        rightBracketIndex = text.indexOf(')', leftBracketIndex);
    }

    console.log(result.join(', '));
}

extractText(['()Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)']);
"use strict";

function expressionSplit([expression]) {
    let tokens = expression.split(/[\.\s,;()]+/g);
    console.log(tokens.join('\n'));
}

expressionSplit(['let sum = 4 * 4,b = "wow";']);
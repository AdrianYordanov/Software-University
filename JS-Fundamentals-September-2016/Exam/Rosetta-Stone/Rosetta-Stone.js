"use strict";

function rosettaStone(array) {
    let n = Number(array.shift());

    let templateMatrix = [],
        messageMatrix = [];
    initMatrices(templateMatrix, messageMatrix);
    changeMessageMatrix(templateMatrix, messageMatrix);
    reduceMessageMatrix(messageMatrix);

    console.log(encodeMessageMatrix(messageMatrix));

    function initMatrices(templateMatrix, messageMatrix) {
        for(let i = 0; i < n; ++i)
            templateMatrix.push(array.shift().split(' ').map(Number));
        array.forEach(line => messageMatrix.push(line.split(' ').map(Number)));
    }

    function changeMessageMatrix(templateMatrix, messageMatrix) {
        for (let row = 0, templateRow = 0; row < messageMatrix.length; row++, templateRow++) {
            if(templateRow == templateMatrix.length)
                templateRow = 0;

            for(let col = 0, templateCol = 0; col < messageMatrix[row].length; col++, templateCol++) {
                if(templateCol == templateMatrix[templateRow].length)
                    templateCol = 0;

                messageMatrix[row][col] += templateMatrix[templateRow][templateCol];
            }
        }
    }

    function reduceMessageMatrix(messageMatrix) {
        for(let row = 0; row < messageMatrix.length; ++row)
            for(let col = 0; col < messageMatrix[row].length; ++col)
                messageMatrix[row][col] = rotate(messageMatrix[row][col]);

        function rotate(number) {
            while (number >= 27)
                number -= 27;
            return number;
        }
    }

    function encodeMessageMatrix(messageMatrix) {
        let stringResult = '';

        for(let row = 0; row < messageMatrix.length; ++row) {
            for (let col = 0; col < messageMatrix[row].length; ++col)
                stringResult += String.fromCharCode(96 + messageMatrix[row][col]);
         }

        return stringResult
            .replace(/`/g, ' ')
            .toUpperCase();
    }
}

rosettaStone([
    '2',
    '59 36',
    '82 52',
    '4 18 25 19 8',
    '4 2 8 2 18',
    '23 14 22 0 22',
    '2 17 13 19 20',
    '0 9 0 22 22' ]
);
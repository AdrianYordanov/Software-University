"use strict";

function chessBoard(array) {
    let number = Number(array[0]);
    let html = '<div class="chessboard">\n';

    for (let i = 0; i < number; ++i) {
        html += '  <div>\n';

        let startIndex = 0,
            endIndex = number;
        if(i % 2 != 0) {
            ++startIndex;
            ++endIndex;
        }

        for (let j = startIndex; j < endIndex; ++j) {
            if (j % 2 == 0)
                html += '     <span class="black"></span>\n';
            else
                html += '     <span class="white"></span>\n';
        }

        html+='  </div>\n';
    }

    html += '</div>';
    console.log(html);
}

chessBoard(['2']);
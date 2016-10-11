"use strict";

function colorfulNumbers(array) {
    let number = Number(array[0]);
    let html = '<ul>\n';

    for(let i = 1; i <= number; ++i) {
        if(i % 2 != 0)
            html+=`  <li><span style='color:green'>${i}</span></li>\n`;
        else
            html+=`  <li><span style='color:blue'>${i}</span></li>\n`;
    }

    html +='</ul>';
    console.log(html);
}

colorfulNumbers(['10']);
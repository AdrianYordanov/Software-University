"use strict";

function SumAndVAT(array) {
    let sum = 0;

    for(let str of array) {
        sum += Number(str);
    }

    let VAT = sum * 0.20;
    let total = sum * 1.20;
    console.log(`sum = ${sum}`);
    console.log(`VAT = ${VAT}`);
    console.log(`total = ${total}`);
}

SumAndVAT(['3.12', '5', '18', '19.24', '1953.2262', '0.001564', '1.1445']);
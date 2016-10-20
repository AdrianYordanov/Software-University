"use strict";

function lowestPriceInCity(array) {
    let dictionary = new Map();

    for (let text of array) {
        let tokens = text.split(/\s*\|\s*/g);
        let [town, product, price] = [tokens[0], tokens[1], Number(tokens[2])];

        if(!dictionary.has(product))
            dictionary.set(product, new Map());

        dictionary.get(product).set(town, price);
    }

    for(let [product, subDictionary] of dictionary) {
        let lowestPrice = Number.POSITIVE_INFINITY;
        let lowestPriceTownName = '';

        for(let [town, price] of subDictionary)
            if(price < lowestPrice) {
                lowestPrice = price;
                lowestPriceTownName = town;
            }

        console.log(`${product} -> ${lowestPrice} (${lowestPriceTownName})`);
    }
}

lowestPriceInCity([
    'Sample Town | Sample Product | 3000',
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
]);
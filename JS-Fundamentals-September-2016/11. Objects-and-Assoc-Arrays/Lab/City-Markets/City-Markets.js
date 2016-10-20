"use strict";

function cityMarkets(array) {
    let dictionary = new Map;

    for(let text of array) {
        let tokens = text.split(/\s*->\s*|\s*:\s*/g);
        let [town, product, amountOfSales, priceForOneUnit] =
            [tokens[0], tokens[1], Number(tokens[2]), Number(tokens[3])];

        let productSum = amountOfSales * priceForOneUnit;

        if(!dictionary.has(town))
            dictionary.set(town, new Map);

        if(!dictionary.get(town).has(product))
            dictionary.get(town).set(product, productSum);
        else
            dictionary.get(town).set(product, dictionary.get(town).get(product) + productSum);
    }

    for(let [town, subDictionary] of dictionary) {
        console.log(`Town - ${town}`);

        for(let [product, value] of subDictionary)
            console.log(`$$$${product} : ${value}`);
    }
}

cityMarkets([
    'Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'
]);
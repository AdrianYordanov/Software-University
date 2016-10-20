"use strict";

function fruitOrVegetable([something]) {
    let fruits = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes', 'peach'];
    let vegetables = ['tomato', 'cucumber', 'pepper', 'onion', 'garlic', 'parsley'];

    if(fruits.indexOf(something) > -1) {
        console.log('fruit');
    } else if(vegetables.indexOf(something) > -1) {
        console.log('vegetable');
    } else {
        console.log('unknown');
    }
}

fruitOrVegetable(['apple']);
"use strict";

let breakfastRobot = (function () {
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        coke: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        omelet: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        cheverme: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    };
    let commands = {
        restock: restock,
        prepare: prepare,
        report: report
    };

    function restock(array) {
        let [microelement, quantity] = [array[0], Number(array[1])];
        ingredients[microelement] += quantity;
        return 'Success';
    }
    
    function prepare(array) {
        let [recipe, quantity] = [recipes[array[0]], Number(array[1])];

        for (let ingredientName in recipe) {
            if (recipe[ingredientName] * quantity > ingredients[ingredientName]) {
                return `Error: not enough ${ingredientName} in stock`;
            }
        }

        for(let ingredientName in recipe) {
            ingredients[ingredientName] -= recipe[ingredientName] * quantity;
        }

        return "Success";
    }

    function report() {
        return Object
            .keys(ingredients)
            .map(name => `${name}=${ingredients[name]}`)
            .join(' ');
    }

    return function executor(text) {
        let args = text.split(' ');
        let commandName = args.shift();
        let returnMsg = commands[commandName](args);
        return returnMsg;
    }
})();

console.log(breakfastRobot('restock carbohydrate 10'));
console.log(breakfastRobot('restock flavour 10'));
console.log(breakfastRobot('prepare apple 1'));
console.log(breakfastRobot('restock fat 10'));
console.log(breakfastRobot('prepare burger 1'));
console.log(breakfastRobot('report'));

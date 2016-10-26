"use strict";

(function () {
    Array.prototype.last = function () {
        let currentArray = this;
        return currentArray[currentArray.length - 1];
    };

    Array.prototype.skip = function (n) {
        let currentArray = this;
        let resultArray = [];

        for (let i = n; i < currentArray.length; ++i) {
            resultArray.push(currentArray[i]);
        }

        return resultArray;
    };

    Array.prototype.take = function (n) {
        let currentArray = this;
        let resultArray = [];

        for (let i = 0; i < n; ++i) {
            resultArray.push(currentArray[i]);
        }

        return resultArray;
    };

    Array.prototype.sum = function () {
        let currentArray = this;
        return currentArray.reduce((a, b) => a + b);
    };

    Array.prototype.average = function () {
        let currentArray = this;
        return currentArray.sum() / currentArray.length;
    }
})();

let array = [2, 5, -0.4, -435, 453, 9345, -64355];

console.log(array.last());
console.log(array.take(4));
console.log(array.skip(4));
console.log(array.average());
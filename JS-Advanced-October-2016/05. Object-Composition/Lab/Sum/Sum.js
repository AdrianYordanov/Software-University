"use strict";

function operations() {
    let selectorOne;
    let selectorTwo;
    let selectorResult;

    function init(selector1, selector2, resultSelector) {
        selectorOne = selector1;
        selectorTwo = selector2;
        selectorResult = resultSelector;
    }

    function add() {
        let firstValue = Number($(selectorOne).val());
        let secondValue = Number($(selectorTwo).val());
        let result = firstValue + secondValue;
        $(selectorResult).val(result);
    }

    function subtract() {
        let firstValue = Number($(selectorOne).val());
        let secondValue = Number($(selectorTwo).val());
        let result = firstValue - secondValue;
        $(selectorResult).val(result);
    }

    return {
        init: init,
        add: add,
        subtract: subtract
    }
}

$(function () {
    let core = operations();
    core.init('#num1', '#num2', '#result');
    $('#sumButton').on('click', core.add);
    $('#subtractButton').on('click', core.subtract);
});
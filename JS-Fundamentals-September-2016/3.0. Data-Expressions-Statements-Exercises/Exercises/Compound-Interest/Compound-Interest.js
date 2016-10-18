"use strict";

function compoundInterest(array) {
    let [principalSum, nominalInterestRate, compoundingFrequency, overallLength] = array.map(Number);

    nominalInterestRate /= 100;
    compoundingFrequency = 12 / compoundingFrequency;

    let result = principalSum * Math.pow(
            ( 1 + (nominalInterestRate / compoundingFrequency)), compoundingFrequency * overallLength);
    result = Math.round(result * 100) / 100;

    console.log(result);
}

compoundInterest(['1500', '4.3', '3', '6']);
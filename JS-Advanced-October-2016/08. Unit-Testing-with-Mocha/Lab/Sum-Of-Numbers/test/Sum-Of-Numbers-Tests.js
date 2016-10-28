"use strict";

let sum = require("../Sum-Of-Numbers").sum;
let expect = require("chai").expect;

describe("Function sum(arr) tests.", function () {
    it("should return 99.9 for [12, 28, 59.9]", function () {
        let expectValue = 99.9;
        let actualValue = sum([12, 28, 59.9]);
        expect(actualValue).to.be.equal(expectValue);
    });
    it("should return 5 for [5]", function () {
        let expectValue = 5;
        let actualValue = sum([5]);
        expect(actualValue).to.be.equal(expectValue);
    });
    it("should return 0 for empty array", function () {
        let expectValue = 0;
        let actualValue = sum([]);
        expect(actualValue).to.be.equal(expectValue);
    });
    it("should return NaN for array of NaN values", function () {
        let actualValue = sum['Invalid', 'Not a number'];
        expect(actualValue).to.be.NaN;
    })
});
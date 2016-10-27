"use strict";

let sum = require("../Sum-Of-Numbers").sum;
let expect = require("chai").expect;

describe("Function sum(arr) tests.", function () {
    it("should return 40 for [12, 28]", function () {
        let expectValue = 40;
        let actualValue = sum([12, 28]);
        expect(actualValue).to.be.equal(expectValue);
    });
    it("should return 5 for [5]", function () {
        let expectValue = 5;
        let actualValue = sum([5]);
        expect(actualValue).to.be.equal(expectValue);
    });
    it("should return 0 for []", function () {
        let expectValue = 0;
        let actualValue = sum([]);
        expect(actualValue).to.be.equal(expectValue);
    });
});
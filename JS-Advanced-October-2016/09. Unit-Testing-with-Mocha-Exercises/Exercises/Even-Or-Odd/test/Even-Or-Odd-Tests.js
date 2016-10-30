"use strict";

let isOddOrEven = require("../Even-Or-Odd").isOddOrEven;
let expect = require("chai").expect;

describe("Function isOddOrEven(string) tests.", function () {
    it("should return odd for 'a' * 21", function () {
        let result = isOddOrEven("a".repeat(21));
        expect(result).to.equal("odd");
    });
    it("should return even for 'a' * 20", function () {
        let result = isOddOrEven("a".repeat(20));
        expect(result).to.equal("even");
    });
    it("should return undefined for number parameter", function () {
        let result = isOddOrEven(2);
        expect(result).to.be.undefined;
    });
    it("should return undefined for object parameter", function () {
        let result = isOddOrEven({number: 2});
        expect(result).to.be.undefined;
    });
});
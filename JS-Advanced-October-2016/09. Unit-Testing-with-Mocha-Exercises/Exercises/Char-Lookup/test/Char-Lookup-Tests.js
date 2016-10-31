"use strict";

let lookupChar = require("../Char-Lookup").lookupChar;
let expect = require("chai").expect;

describe("Function lookupChar(string, index) tests.", function () {
    describe('Tests with correct output.', function () {
        it("should return 'w' for ('hello world', 6)", function () {
            let result = lookupChar('hello world', 6);
            expect(result).equal('w');
        });
        it("should return 'h' for ('hello world', 0)", function () {
            let result = lookupChar('hello world', 0);
            expect(result).equal('h');
        });
        it("should return 'd' for ('hello world', 10)", function () {
            let result = lookupChar('hello world', 10);
            expect(result).equal('d');
        });
    });
    describe("Expect undefined output.",function () {
        it("should return undefined for (5003, 6)", function () {
            let result = lookupChar(50003, 6);
            expect(result).equal(undefined);
        });
        it("should return undefined for (50003, 2.3)", function () {
            let result = lookupChar(50003, 2.3);
            expect(result).equal(undefined);
        });
        it("should return undefined for ('hello world', NaN)", function () {
            let result = lookupChar('hello world', NaN);
            expect(result).equal(undefined);
        });
    });
    describe("Expect 'Incorrect index' output.", function () {
        it("should return 'Incorrect index' for ('hello world', -1)", function () {
            let result = lookupChar('hello world', -1);
            expect(result).equal('Incorrect index');
        });
        it("should return 'Incorrect index' for ('hello world', 11)", function () {
            let result = lookupChar('hello world', 11);
            expect(result).equal('Incorrect index');
        });
    });
});
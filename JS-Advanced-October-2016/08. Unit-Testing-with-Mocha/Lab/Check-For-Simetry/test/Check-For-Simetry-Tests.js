"use strict";

let isSymmetric = require("../Check-For-Simetry").isSymmetric;
let expect = require("chai").expect;

describe("Function isSymmetric(arr) tests.", function () {
    describe("Expected true cases.", function () {
        it("should return true for [1, 2, 3, 4, 3, 2, 1] (with odd numbers length)", function () {
            let result = isSymmetric([1, 2, 3, 4, 3, 2, 1]);
            expect(result).equal(true);
        });
        it("should return true for [1, 2, 3, 3, 2, 1] (with even numbers length)", function () {
            let result = isSymmetric([1, 2, 3, 3, 2, 1]);
            expect(result).equal(true);
        });
        it("should return true for [{name: 'pesho'}, new Date(), {name: 'pesho'}] (with objects)", function () {
            let result = isSymmetric([{name: 'pesho'}, new Date(), {name: 'pesho'}]);
            expect(result).equal(true);
        });
        it("should return true for [1, 1] (with two elements)", function () {
            let result = isSymmetric([1, 1]);
            expect(result).equal(true);
        });
        it("should return true for [1] (with one element)", function () {
            let result = isSymmetric([1]);
            expect(result).equal(true);
        });
        it("should return true for [] (with empty array)", function () {
            let result = isSymmetric([]);
            expect(result).equal(true);
        });
        it("should return true for [] (with empty array)", function () {
            let result = isSymmetric([]);
            expect(result).equal(true);
        });
    });
    describe("Expected false cases.", function () {
        it("should return false for [1, 7, 3, 4, 3, 5, 1] (with odd numbers length)", function () {
            let result = isSymmetric([1, 7, 3, 4, 3, 5, 1]);
            expect(result).equal(false);
        });
        it("should return false for [1, 2, 4, 5, 2, 1] (with even numbers length)", function () {
            let result = isSymmetric([1, 2, 4, 5, 2, 1]);
            expect(result).equal(false);
        });
        it("should return false for [1, 2] (with two elements)", function () {
            let result = isSymmetric([1, 2]);
            expect(result).equal(false);
        });
        it("should return false for false for 'Something else' (not array)", function () {
            let result = isSymmetric("Something else");
            expect(result).equal(false);
        });
    })
});
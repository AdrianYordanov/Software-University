"use strict";

let mathEnforcer = require("../Math-Enforcer").mathEnforcer;
let expect = require("chai").expect;

describe("Test the object mathEnforcer.", function () {
    describe("Test the addFive property.", function () {
        it("should return -1 for (-6)", function () {
            let result = mathEnforcer.addFive(-6);
            expect(result).equal(-1);
        });
        it("should be close to 5.04 for (0.04)", function () {
            let result = mathEnforcer.addFive(0.04);
            expect(result).closeTo(5.04, 0.01);
        });
        it("should be close to 5 for (-0.003425362)", function () {
            let result = mathEnforcer.addFive(-0.003425362);
            expect(result).closeTo(5, 0.01);
        });
        it("should return undefined for ('23')", function () {
            let result = mathEnforcer.addFive('23');
            expect(result).equal(undefined);
        });
    });
    describe("Test the subtractTen property.", function () {
        it("should return -15 for (-5)", function () {
            let result = mathEnforcer.subtractTen(-5);
            expect(result).equal(-15);
        });
        it("should be close to -9.95 for (0.05)", function () {
            let result = mathEnforcer.subtractTen(0.05);
            expect(result).closeTo(-9.95, 0.01);
        });
        it("should to be close to -10 for (-0.00034535)", function () {
            let result = mathEnforcer.subtractTen(-0.00034535);
            expect(result).closeTo(-10, 0.01);
        });
        it("should return undefined for ('23')", function () {
            let result = mathEnforcer.subtractTen('23');
            expect(result).equal(undefined);
        });
    });
    describe("Test the sum property.", function () {
        it("should return -15 for (-5, -10)", function () {
            let result = mathEnforcer.sum(-5, -10);
            expect(result).equal(-15);
        });
        it('should be close to 5.1 for (2.5, 2.6)', () => {
            let result = mathEnforcer.sum(2.5, 2.6);
            expect(result).closeTo(5.1, 0.01)
        });
        it("should return undefined for ('23', 1)", function () {
            let result = mathEnforcer.sum('23', 1);
            expect(result).equal(undefined);
        });
        it("should return undefined for (1, '23')", function () {
            let result = mathEnforcer.sum(1, '23');
            expect(result).equal(undefined);
        });
    });
});
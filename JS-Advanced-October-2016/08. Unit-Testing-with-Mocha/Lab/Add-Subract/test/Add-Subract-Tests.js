"use strict";

let createCalculator = require("../Add-Subract").createCalculator;
let expect = require("chai").expect;

describe("Function createCalculator() tests.", function () {
    let calculator;
    beforeEach(function () {
        calculator = createCalculator();
    });

    describe("Function returning test.", function () {
        it("should return object for calling createCalculator()", function () {
            let typeOfReturnValue = typeof calculator;
            expect(typeOfReturnValue).equal("object");
        });
        it("should have property add", function () {
            expect(calculator).to.have.property('add');
        });
        it("should have property subtract", function () {
            expect(calculator).to.have.property('subtract');
        });
        it("should have property get", function () {
            expect(calculator).to.have.property('get');
        });
        it("should return 0 for initialization the calculator", function () {
            expect(calculator.get()).to.equal(0);
        });

    });
    describe("Function add(num) tests.", function () {
        it("should return 10 for (10) (only one positive)", function () {
            calculator.add(10);
            expect(calculator.get()).equal(10);
        });
        it("should return -10 for (-10) (only one negative)", function () {
            calculator.add(-10);
            expect(calculator.get()).equal(-10);
        });
        it("should return 100 for (10)(20)(30)(40) (only positives)", function () {
            calculator.add(10);
            calculator.add(20);
            calculator.add(30);
            calculator.add(40);
            expect(calculator.get()).equal(100);
        });
        it("should return -100 for (-10)(-20)(-30)(-40) (only negatives)", function () {
            calculator.add(-10);
            calculator.add(-20);
            calculator.add(-30);
            calculator.add(-40);
            expect(calculator.get()).equal(-100);
        });
        it("should return -25 for (10)(-16)(-19) (positives and negatives)", function () {
            calculator.add(10);
            calculator.add(-16);
            calculator.add(-19);
            expect(calculator.get()).equal(-25);
        });
        it("should return 0.30000000000000004  for (0.1)(0.2) (floating)", function () {
            calculator.add(0.1);
            calculator.add(0.2);
            expect(calculator.get()).equal(0.1 + 0.2);
        });
        it("should return 10 for ('10') (correct string)", function () {
            calculator.add('10');
            expect(calculator.get()).equal(10);
        });
        it("should return NaN for ('something else')", function () {
            calculator.add('something else');
            expect(calculator.get()).to.be.NaN;
        });
        it("should return NaN for no parameter calling", function () {
            calculator.add();
            expect(calculator.get()).to.be.NaN;
        });
    });
    describe("Function subtract(num) tests.", function () {
        it("should return -10 for (10) (only one positive)", function () {
            calculator.subtract(10);
            expect(calculator.get()).equal(-10);
        });
        it("should return 10 for (-10) (only one negative)", function () {
            calculator.subtract(-10);
            expect(calculator.get()).equal(10);
        });
        it("should return -100 for (10)(20)(30)(40) (only positives)", function () {
            calculator.subtract(10);
            calculator.subtract(20);
            calculator.subtract(30);
            calculator.subtract(40);
            expect(calculator.get()).equal(-100);
        });
        it("should return -100 for (-10)(-20)(-30)(-40) (only negatives)", function () {
            calculator.subtract(-10);
            calculator.subtract(-20);
            calculator.subtract(-30);
            calculator.subtract(-40);
            expect(calculator.get()).equal(100);
        });
        it("should return -25 for (10)(-16)(-19) (positives and negatives)", function () {
            calculator.subtract(10);
            calculator.subtract(-16);
            calculator.subtract(-19);
            expect(calculator.get()).equal(25);
        });
        it("should return -0.30000000000000004  for (0.1)(0.2) (floating)", function () {
            calculator.subtract(0.1);
            calculator.subtract(0.2);
            expect(calculator.get()).equal(-0.1 - 0.2);
        });
        it("should return -10 for ('10') (correct string)", function () {
            calculator.subtract('10');
            expect(calculator.get()).equal(-10);
        });
        it("should return NaN for ('something else')", function () {
            calculator.subtract('something else');
            expect(calculator.get()).to.be.NaN;
        });
        it("should return NaN for no parameter calling", function () {
            calculator.subtract();
            expect(calculator.get()).to.be.NaN;
        });
    });
    describe("Functions add(num) and subtract(num) combined tests.", function () {
        it("should return 0 for add 10 subtract 10", function () {
            calculator.add(10);
            calculator.subtract(10);
            expect(calculator.get()).equal(0);
        });
        it("should return 0 for subtract 10 add 10", function () {
            calculator.subtract(10);
            calculator.add(10);
            expect(calculator.get()).equal(0);
        });
        it("should return 5.6 for add 100 subtract 4.4 add 20 subtract 0.54", function () {
            calculator.add(10);
            calculator.subtract(4.4);
            calculator.add(20);
            calculator.subtract(0.54);
            expect(calculator.get()).equal(10 - 4.4 + 20 - 0.54);
        });
        it("should return 5.6 for subtract 10 add 7.98 subtract 7834 subtract 0.54", function () {
            calculator.subtract(10);
            calculator.add(7.98);
            calculator.subtract(7834);
            calculator.subtract(0.54);
            expect(calculator.get()).equal(-10 + 7.98 - 7834 - 0.54);
        });
        it("should return NaN for add 'something else'  subtract 6 ", function () {
            calculator.add('something else');
            calculator.subtract(6);
            expect(calculator.get()).to.be.NaN;
        });
        it("should return NaN for add 6 subtract 'something else' ", function () {
            calculator.add(6);
            calculator.subtract('something else');
            expect(calculator.get()).to.be.NaN;
        });
    });
});
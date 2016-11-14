"use strict";

let expect = require("chai").expect;
let createList = require("../Add-Swap-Shift-Left-Right").createList;

describe("Test the function createList.", function () {
    let testObject = undefined;

    beforeEach(function () {
        testObject = createList();
    });

    describe("Test the properties.", function () {
        it("createList should be function", function () {
            expect(typeof createList).equal("function");
        });
        it("the result of returning should be object", function () {
            expect(typeof testObject).equal("object");
        });
        it("should have property add", function () {
            expect(testObject.hasOwnProperty("add")).equal(true);
        });
        it("should have property shiftLeft", function () {
            expect(testObject.hasOwnProperty("shiftLeft")).equal(true);
        });
        it("should have property shiftRight", function () {
            expect(testObject.hasOwnProperty("shiftRight")).equal(true);
        });
        it("should have property swap", function () {
            expect(testObject.hasOwnProperty("swap")).equal(true);
        });
        it("should have property toString", function () {
            expect(testObject.hasOwnProperty("toString")).equal(true);
        });
    });

    describe("Test the function add.", function () {
        it("should push number", function () {
            testObject.add(23);
            expect(testObject.toString()).equal("23");
        });
        it("should push floating point", function () {
            testObject.add(-3.14);
            expect(testObject.toString()).equal("-3.14");
        });
        it("should push string", function () {
            testObject.add("test string");
            expect(testObject.toString()).equal("test string");
        });
        it("should push empty string", function () {
            testObject.add("");
            testObject.add("test string");
            expect(testObject.toString()).equal(", test string");
        });
        it("should push string with spaces", function () {
            testObject.add("   ");
            testObject.add("test string");
            expect(testObject.toString()).equal("   , test string");
        });
        it("should push object", function () {
            testObject.add({name: "Adrian"});
            expect(testObject.toString()).equal("[object Object]");
        });
    });

    describe("Test the function shiftLeft", function () {
        it("test with more elements", function () {
            testObject.add({name: "Adrian"});
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");
            testObject.shiftLeft();
            expect(testObject.toString()).equal("23, striiing, 566, new string, [object Object]");
        });
        it("test with one element", function () {
            testObject.add(23);
            testObject.shiftLeft();
            expect(testObject.toString()).equal("23");
        });
        it("should do full cycle with data.length shifts", function () {
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");

            for (let i = 0; i < 4; ++i)
                testObject.shiftLeft();

            expect(testObject.toString()).equal("23, striiing, 566, new string");
        });
        it("should overclock correctly with one", function () {
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");

            for (let i = 0; i < 5; ++i)
                testObject.shiftLeft();

            expect(testObject.toString()).equal("striiing, 566, new string, 23");
        });
        it("test with no elements", function () {
            testObject.shiftLeft();
            expect(testObject.toString()).equal("");
        });
    });

    describe("Test the function shiftRight", function () {
        it("test with more elements", function () {
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");
            testObject.add({name: "Adrian"});
            testObject.shiftRight();
            expect(testObject.toString()).equal("[object Object], 23, striiing, 566, new string");
        });
        it("test with one element", function () {
            testObject.add(23);
            testObject.shiftRight();
            expect(testObject.toString()).equal("23");
        });
        it("should do full cycle with data.length shifts", function () {
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");

            for (let i = 0; i < 4; ++i)
                testObject.shiftRight();

            expect(testObject.toString()).equal("23, striiing, 566, new string");
            it("test no elements", function () {
                testObject.shiftRight();
                expect(testObject.toString()).equal("");
            });
        });
        it("should overclock correctly with one", function () {
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");

            for (let i = 0; i < 5; ++i)
                testObject.shiftRight();

            expect(testObject.toString()).equal("new string, 23, striiing, 566");
        });
        it("test with no elements", function () {
            testObject.shiftRight();
            expect(testObject.toString()).equal("");
        });
    });

    describe("Test the function swap.", function () {
        it("swap first and last", function () {
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");
            testObject.swap(0, 3);
            expect(testObject.toString()).equal("new string, striiing, 566, 23");
        });
        it("swap last and first", function () {
            testObject.add(23);
            testObject.add("striiing");
            testObject.add(566);
            testObject.add("new string");
            testObject.swap(3, 0);
            expect(testObject.toString()).equal("new string, striiing, 566, 23");
        });
        it("swap two elements with length: 2", function () {
            testObject.add(23);
            testObject.add({name: "Adrian"});
            testObject.swap(0, 1);
            expect(testObject.toString()).equal("[object Object], 23");
        });
        it("swap the same element with itself.", function () {
            testObject.add(23);
            testObject.swap(0, 0);
            expect(testObject.toString()).equal("23");
        });
        it("with empty data should be empty again", function () {
            testObject.swap(0, 0);
            expect(testObject.toString()).equal("");
        });

        it("with valid indexes should return true", function () {
            testObject.add(23);
            testObject.add("new string");
            expect(testObject.swap(0, 1)).equal(true);
        });
        it("with negative first index should return false", function () {
            testObject.add(23);
            testObject.add("new string");
            testObject.add(533);
            testObject.add("striiing");
            expect(testObject.swap(-1, 2)).equal(false);
        });
        it("with greater first index should return false", function () {
            testObject.add(23);
            testObject.add("new string");
            testObject.add(533);
            testObject.add("striiing");
            expect(testObject.swap(4, 2)).equal(false);
        });
        it("with negative second index should return false", function () {
            testObject.add(23);
            testObject.add("new string");
            testObject.add(533);
            testObject.add("striiing");
            expect(testObject.swap(2, -1)).equal(false);
        });
        it("with greater second index should return false", function () {
            testObject.add(23);
            testObject.add("new string");
            testObject.add(533);
            testObject.add("striiing");
            expect(testObject.swap(2, 4)).equal(false);
        });
        it("with empty data should return false", function () {
            expect(testObject.swap(0, 0)).equal(false);
        });
        it("with same indexes value should false", function () {
            testObject.add(23);
            testObject.add("new string");
            testObject.add(533);
            testObject.add("striiing");
            expect(testObject.swap(2, 2)).equal(false);
        });
        it("when the first index is not Integer", function () {
            testObject.add(23);
            testObject.add("new string");
            testObject.add(533);
            testObject.add("striiing");
            expect(testObject.swap("str", 2)).equal(false);
        });
        it("when the second index is not Integer", function () {
            testObject.add(23);
            testObject.add("new string");
            testObject.add(533);
            testObject.add("striiing");
            expect(testObject.swap(2, "str")).equal(false);
        });
    });
});
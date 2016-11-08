"use strict";

let Console = require("../C-Sharp-Console").Console;
let expect = require("chai").expect;

describe("Test the class Console.", function () {
    describe("Test the class properties.", function () {
        it("the class should be function", function () {
            let type = typeof Console;
            expect(type).equal("function");
        });
        it("should have getter placeholder", function () {
            let type = typeof Console.placeholder;
            expect(type).equal('object');
        });
        it("should have function writeLine", function () {
            let type = typeof Console.writeLine;
            expect(type).equal('function');
        });
    });

    describe("Test the getter placeholder.", function () {
        it("should match valid placeholder", function () {
            let matches = "{435}".match(Console.placeholder).length;
            expect(matches).equal(1);
        });
        it("should not match invalid placeholder", function () {
            let matches = "{4352{".match(Console.placeholder);
            expect(matches).equal(null);
        });
    });

    describe("Test the function writeLine.", function () {
        describe("Tests with one argument.", function () {
            it("with string argument", function () {
                let test = "test sgl;gfsdf35g";
                expect(Console.writeLine(test)).equal(test);
            });
            it("with empty argument", function () {
                let test = "";
                expect(Console.writeLine(test)).equal("");
            });
            it("with object argument", function () {
                let test = {name: "Adrian", age: 19, course: "JS-Advanced"};
                expect(Console.writeLine(test)).equal(JSON.stringify(test));
            });
        });

        describe("Tests with more arguments.", function () {
            it("with valid arguments and more placeholders", function () {
                let result = "Hello Adrian, your age is 19 from BG. Town: Sofia.";
                expect(Console.writeLine("Hello {0}, your age is {1} from {2}. Town: {3}."
                    , "Adrian", 19, "BG", "Sofia")).equal(result);
            });
            it("with valid arguments and one placeholder", function () {
                let result = "Hello Adrian!";
                expect(Console.writeLine("Hello {0}!", "Adrian")).equal(result);
            });
            it("with valid changed placeholders places", function () {
                let result = "Hello Adrian, your age is 19 from BG. Town: Sofia.";
                expect(Console.writeLine("Hello {3}, your age is {1} from {2}. Town: {0}."
                    , "Sofia", "19", "BG", "Adrian")).equal(result);
            });
            it("with invalid message should throw TypeError.", function () {
                expect(Console.writeLine.bind(Console, {text: "hi {2}"}, "text"))
                    .to.throw(TypeError, "No string format given!");
            });
            it("with more placeholders should throw RangeError.", function () {
                expect(Console.writeLine.bind(Console, "Hello {0}, your age is {1}.", "Adrian"))
                    .to.throw(RangeError, "Incorrect amount of parameters given!");
            });
            it("when placeholder is not withing the parameter should throw RangeError.", function () {
                expect(Console.writeLine.bind(Console, "Hello {1}, your age is {3}.", "Adrian", "19"))
                    .to.throw(RangeError, "Incorrect placeholders given!");
            });
        });
    });
});
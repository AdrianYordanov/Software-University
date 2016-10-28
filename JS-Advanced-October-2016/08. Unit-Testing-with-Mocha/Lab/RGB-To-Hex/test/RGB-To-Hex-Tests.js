"use strict";

let rgbToHexColor = require("../RGB-To-Hex").rgbToHexColor;
let expect = require("chai").expect;

describe("Function rgbToHexColor(red, green, blue) tests.", function () {
    describe("Tests with correct result.", function () {
        it("should return #069A3A for (6, 154, 58) (the highest case)", function () {
            let result = rgbToHexColor(6, 154, 58);
            expect(result).equals("#069A3A");
        });
        it("should return #000000 for (0, 0, 0) (the lowest case)", function () {
            let result = rgbToHexColor(0, 0, 0);
            expect(result).equals("#000000");
        });
        it("should return #FFFFFF for (255, 255, 255) (the highest case)", function () {
            let result = rgbToHexColor(255, 255, 255);
            expect(result).equals("#FFFFFF");
        });
    });
    describe("Tests with wrong input", function () {
        describe("Tests each parameter with -1.", function () {
            it("should return undefined for (-1, 9, 9)", function () {
                let result = rgbToHexColor(-1, 9, 9);
                expect(result).equals(undefined);
            });
            it("should return undefined for (9, -1, 9)", function () {
                let result = rgbToHexColor(9, -1, 9);
                expect(result).equals(undefined);
            });
            it("should return undefined for (9, 9, -1)", function () {
                let result = rgbToHexColor(9, 9, -1);
                expect(result).equals(undefined);
            });
        });
        describe("Tests each parameter with 256", function () {
            it("should return undefined for (256, 9, 9)", function () {
                let result = rgbToHexColor(256, 9, 9);
                expect(result).equals(undefined);
            });
            it("should return undefined for (9, 256, 9)", function () {
                let result = rgbToHexColor(9, 256, 9);
                expect(result).equals(undefined);
            });
            it("should return undefined for (9, 9, 256)", function () {
                let result = rgbToHexColor(9, 9, 256);
                expect(result).equals(undefined);
            });
        });
        describe("Tests each parameter with NaN", function () {
            it("should return undefined for (NaN, 9, 9)", function () {
                let result = rgbToHexColor(NaN, 9, 9);
                expect(result).equals(undefined);
            });
            it("should return undefined for (9, NaN, 9)", function () {
                let result = rgbToHexColor(9, NaN, 9);
                expect(result).equals(undefined);
            });
            it("should return undefined for (9, 9, NaN)", function () {
                let result = rgbToHexColor(9, 9, NaN);
                expect(result).equals(undefined);
            });
        });
    });
});
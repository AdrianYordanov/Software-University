"use strict";

let list = require("../Add-Delete-In-List-Tests").SortedList;
let expect = require("chai").expect;

describe("Test the properties", function () {
    it("should have property add", function () {
        expect(list.hasOwnProperty("add")).equal(true);
    });
    it("should have property delete", function () {
        expect(list.hasOwnProperty("delete")).equal(true);
    });
    it("should have property toString", function () {
        expect(list.hasOwnProperty("toString")).equal(true);
    });
});

describe("Test add function,", function () {
    it("should add number", function () {
        list.add(23);
        expect(list.toString()).equal("23");
    });
    it("should add string", function () {
        list.add("string test");
        expect(list.toString()).equal("string test");
    });
    it("should add object", function () {
        list.add({name: "Adrian"});
        expect(list.toString()).equal("[object Object]");
    });
    it("with more items", function () {
        list.add(23);
        list.add("string");
        list.add({name: "Adrian"});
        expect(list.toString()).equal("23, string, [object Object]");
    });
});

describe("Test delete function,", function () {
    it("with valid index", function () {
        list.add(23);
        list.add(435);
        list.add(999);
        list.delete(1);
        expect(list.toString()).equal("23, 999");
    });
    it("should return the deleted object", function () {
        list.add(23);
        list.add(435);
        list.add(999);
        expect(list.delete(1)).equal(435);
    });

    it("should return undefined for negative index", function () {
        list.add(23);
        list.add(435);
        list.add(999);
        expect(list.delete(-1)).equal(undefined);
    });
    it("should return undefined for greater index", function () {
        list.add(23);
        list.add(435);
        list.add(999);
        expect(list.delete(3)).equal(undefined);
    });
    it("should return undefined for string index", function () {
        list.add(23);
        list.add(435);
        list.add(999);
        expect(list.delete("1")).equal(undefined);
    });
});
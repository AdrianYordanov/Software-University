"use strict";

let SortedList = require("../Sorted-List").SortedList;
let expect = require("chai").expect;

describe("Test SortedList class", function () {
    let list;
    beforeEach(function () {
        list = new SortedList();
    });

    describe("Check the initialization.", function () {
        it("the type should be function", function () {
            expect(typeof SortedList).equal("function");
        });
        it("should have function add", function () {
            expect(SortedList.prototype.hasOwnProperty("add")).equal(true);
        });
        it("should have function remove", function () {
            expect(SortedList.prototype.hasOwnProperty("remove")).equal(true);
        });
        it("should have function get", function () {
            expect(SortedList.prototype.hasOwnProperty("get")).equal(true);
        });
        it("should have function vrfyRange", function () {
            expect(SortedList.prototype.hasOwnProperty("vrfyRange")).equal(true);
        });
        it("should have function sort", function () {
            expect(SortedList.prototype.hasOwnProperty("sort")).equal(true);
        });
        it("should have property size", function () {
            expect(SortedList.prototype.hasOwnProperty("size")).equal(true);
        });
        it("the typeof size property should be number", function () {
            let type = typeof list.size;
            expect(type).equal("number");
        });
        it("the default list value should be empty array", function () {
            expect(list.list.length).equal(0);
        });
    });

    describe("Check add function.", function () {
        it("add only one number", function () {
            list.add(45);
            expect(list.list.length).equal(1);
        });
        it("add more numbers", function () {
            list.add(4554);
            list.add(5345);
            list.add(-3453);
            list.add(18643);
            expect(list.list.length).equal(4);
        });
        it("adding number", function () {
            list.add(45);
            expect(list.list.includes(45)).equal(true);
        });
        it("adding floating numbers", function () {
            list.add(-2.54564356);
            expect(list.list.includes(-2.54564356)).equal(true);
        });
        it("adding string", function () {
            list.add("test");
            expect(list.list.includes("test")).equal(true);
        });
    });

    describe("Check remove function.", function () {
        it("should remove the first element", function () {
            list.add(26);
            list.add(645);
            list.add(-3453);
            list.remove(0);
            expect(list.list.includes(-3453)).equal(false);
        });
        it("should remove the last element", function () {
            list.add(26);
            list.add(645);
            list.add(-3453);
            list.remove(list.list.length - 1);
            expect(list.list.join(' ')).equal('-3453 26');
        });
        it("should throw error for empty array", function () {
            expect(list.remove.bind(list, 3)).to.throw(Error, "Collection is empty.");
        });
        it("should throw error for negative index", function () {
            list.add(6);
            expect(list.remove.bind(list, -1)).to.throw(Error, "Index was outside the bounds of the collection.");
        });
        it("should throw error for greater index than length", function () {
            list.add(6);
            list.add(1345);
            list.add(-345);
            let length = list.list.length;
            expect(list.remove.bind(list, length)).to.throw(Error, "Index was outside the bounds of the collection.");
        });
    });

    describe("Check get function.", function () {
        it("should get the first element", function () {
            list.add(26);
            list.add(645);
            list.add(-3453);
            expect(list.get(0)).equal(-3453);
        });
        it("should get the last element", function () {
            list.add(26);
            list.add(645);
            list.add(-3453);
            expect(list.get(list.list.length - 1)).equal(645);
        });
        it("should throw error for empty array", function () {
            expect(list.get.bind(list, 3)).to.throw(Error, "Collection is empty.");
        });
        it("should throw error for negative index", function () {
            list.add(6);
            expect(list.get.bind(list, -1)).to.throw(Error, "Index was outside the bounds of the collection.");
        });
        it("should throw error for greater index than length", function () {
            list.add(6);
            list.add(1345);
            list.add(-345);
            let length = list.list.length;
            expect(list.get.bind(list, length)).to.throw(Error, "Index was outside the bounds of the collection.");
        });
    });

    describe("Check get size property", function () {
        it("should return zero for empty array", function () {
            expect(list.size).equal(0);
        });
        it("should return 6 for [1, 2, 3, 4, 5, 6]", function () {
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(4);
            list.add(5);
            list.add(6);
            expect(list.size).equal(6);
        });
    });

    describe("Check the sorting", function () {
        it("with positive numbers", function () {
            list.add(45);
            list.add(674567);
            list.add(45625);
            list.add(43);
            expect(list.list.join(" ")).equal("43 45 45625 674567");
        });
        it("with negative and positive numbers", function () {
            list.add(45);
            list.add(-674567);
            list.add(45625);
            list.add(43);
            expect(list.list.join(" ")).equal("-674567 43 45 45625");
        });
        it("with floating numbers", function () {
            list.add(45);
            list.add(-674567);
            list.add(45625);
            list.add(4.3);
            list.add(-4.56);
            expect(list.list.join(" ")).equal("-674567 -4.56 4.3 45 45625");
        });
        it("with equal numbers", function () {
            list.add(1);
            list.add(1);
            list.add(-4);
            list.add(6);
            list.add(6);
            expect(list.list.join(" ")).equal("-4 1 1 6 6");
        });
        it("with strings", function () {
            list.add(1);
            list.add(1);
            list.add("fsgsg");
            list.add(6);
            list.add(6);
            expect(list.list.join(" ")).equal("1 1 fsgsg 6 6");
        });
        it("with removing numbers", function () {
            list.add(45);
            list.add(-674567);
            list.add(45625);
            list.add(4.3);
            list.remove(2);
            list.add(-4.56);
            list.add(3465);
            list.remove(list.size - 1);
            expect(list.list.join(" ")).equal("-674567 -4.56 4.3 3465");
        });
    });
});
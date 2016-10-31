"use strict";

let sharedObject = require("../Shared-Object").sharedObject;
let expect = require("chai").expect;
let jsdom = require("jsdom-global")();
let $ = require("jquery");

document.body.innerHTML = `<div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>`;

describe("Test the object - sharedObject.", function () {
    describe("Test the default properties value.", function () {
        it("the default name value should be null", function () {
            expect(sharedObject.name).equal(null);
        });
        it("the default income value should be null", function () {
            expect(sharedObject.income).equal(null);
        });
    });
    describe("Test changeName.", function () {
        it("should change the name property for valid parameter", function () {
            sharedObject.changeName("Ivan");
            expect(sharedObject.name).equal("Ivan");
        });
        it("should change the name textBox value for valid parameter", function () {
            sharedObject.changeName("Ivan");
            expect($('#name').val()).equal("Ivan");
        });
        it("should not change the name property for invalid parameter", function () {
            sharedObject.name = 'test';
            sharedObject.changeName("");
            expect(sharedObject.name).equal("test");
        });
        it("should not change the name textBox value for invalid parameter", function () {
            let nameTextBox = $('#name');
            nameTextBox.val('test');
            sharedObject.changeName("");
            expect(nameTextBox.val()).equal('test');
        });
    });
    describe("Test changeIncome.", function () {
        it("should change the income property for valid parameter", function () {
            sharedObject.changeIncome(1200);
            expect(sharedObject.income).equal(1200);
        });
        it("should change the income textBox value for valid parameter", function () {
            sharedObject.changeIncome(1200);
            expect($('#income').val()).equal("1200");
        });
        it("should not change the income property for string parameter", function () {
            sharedObject.income = 500;
            sharedObject.changeIncome("545bg553");
            expect(sharedObject.income).equal(500);
        });
        it("should not change the income textBox value for string parameter", function () {
            let nameTextBox = $('#income');
            nameTextBox.val('500');
            sharedObject.changeIncome("545bg553");
            expect(nameTextBox.val()).equal('500');
        });
        it("should not change the income property for zero (negative) parameter", function () {
            sharedObject.income = 500;
            sharedObject.changeIncome(0);
            expect(sharedObject.income).equal(500);
        });
        it("should not change the income textBox value for zero (negative) parameter", function () {
            let nameTextBox = $('#income');
            nameTextBox.val('500');
            sharedObject.changeIncome(0);
            expect(nameTextBox.val()).equal('500');
        });
        it("should not change the income property for floating parameter", function () {
            sharedObject.income = 500;
            sharedObject.changeIncome(6.45);
            expect(sharedObject.income).equal(500);
        });
        it("should not change the income textBox value for floating parameter", function () {
            let nameTextBox = $('#income');
            nameTextBox.val('500');
            sharedObject.changeName(6.45);
            expect(nameTextBox.val()).equal('500');
        });
    });
    describe("Test updateName.", function () {
        it("should change the name property for valid textBox value", function () {
            $('#name').val('Ivan');
            sharedObject.updateName();
            expect(sharedObject.name).equal("Ivan");
        });
        it("should not change the name property for invalid textBox value", function () {
            sharedObject.name = 'test';
            $('#name').val('');
            sharedObject.updateName();
            expect(sharedObject.name).equal("test");
        });
    });
    describe("Test updateIncome.", function () {
        it("should change the income property for valid textBox value", function () {
            $('#income').val('1200');
            sharedObject.updateIncome();
            expect(sharedObject.income).equal(1200);
        });
        it("should not change the income property for NaN textBox value", function () {
            sharedObject.income = 1200;
            $('#income').val('string');
            sharedObject.updateIncome();
            expect(sharedObject.income).equal(1200);
        });
        it("should not change the income property for empty string textBox value", function () {
            sharedObject.income = 1200;
            $('#income').val('');
            sharedObject.updateIncome();
            expect(sharedObject.income).equal(1200);
        });
        it("should not change the income property for floating textBox value", function () {
            sharedObject.income = 1200;
            $('#income').val('6.45');
            sharedObject.updateIncome();
            expect(sharedObject.income).equal(1200);
        });
        it("should not change the income property for negative textBox value", function () {
            sharedObject.income = 1200;
            $('#income').val('-435');
            sharedObject.updateIncome();
            expect(sharedObject.income).equal(1200);
        });
    });
});
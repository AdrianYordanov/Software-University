"use strict";

let nuke = require("../Armage-DOM").nuke;
let expect = require("chai").expect;
let jsdom = require("jsdom-global")();
let $ = require("jquery");


describe("Test the function nuke(selector1, selector2)", function () {
    beforeEach(function () {
        document.body.innerHTML = `<div id="target">
    <div class="nested target">
        <p>This is some text</p>
    </div>
    <div class="target">
        <p>Empty div</p>
    </div>
    <div class="inside">
        <span class="nested">Some more text</span>
        <span class="target">Some more text</span>
    </div>
</div>`;
    });

    it("should delete all 'div.nested' for ('div', '.nested')", function () {
        nuke('div', '.nested');
        let count = $("div.nested").length;
        expect(count).equal(0);
    });
    it("should delete all 'div.nested' for ('span', '.target')", function () {
        nuke('span', '.target');
        let count = $("span.target").length;
        expect(count).equal(0);
    });
    it("should delete all items ('div', '#target')", function () {
        nuke('div', '#target');
        let count = $("body *").length;
        expect(count).equal(0);
    });

    it("should not do nothing for equal parameters", function () {
        let initLength = $("body *").length;
        nuke('div', 'div');
        let endLength = $("body *").length;
        expect(initLength).equal(endLength);
    });
    it("should not do nothing for invalid first parameter", function () {
        let initLength = $("body *").length;
        nuke('diiiiv', 'div');
        let endLength = $("body *").length;
        expect(initLength).equal(endLength);
    });
    it("should not do nothing for invalid second parameter", function () {
        let initLength = $("body *").length;
        nuke('#target', 'diiiiv');
        let endLength = $("body *").length;
        expect(initLength).equal(endLength);
    });
    it("should not do nothing for non-founding class", function () {
        let initLength = $("body *").length;
        nuke('.nested', '.inside');
        let endLength = $("body *").length;
        expect(initLength).equal(endLength);
    });
    it("should not do nothing for omitted parameter", function () {
        let initLength = $("body *").length;
        nuke('#target');
        let endLength = $("body *").length;
        expect(initLength).equal(endLength);
    });
    it("should not do nothing for no parameters", function () {
        let initLength = $("body *").length;
        nuke();
        let endLength = $("body *").length;
        expect(initLength).equal(endLength);
    });
});
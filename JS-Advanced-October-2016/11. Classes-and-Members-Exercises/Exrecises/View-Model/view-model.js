"use strict";

class Textbox {
    constructor(selector, invalidSymbols) {
        this._elements = $(selector);
        this._invalidSymbols = invalidSymbols;

        let that = this;
        this._elements.on('input', function () {
            let currentInput = $(this);
            that._elements.val(currentInput.val());
        });
    }

    get elements() {
        return this._elements;
    }

    get value() {
        return this.elements.val();
    }

    set value(changeValue) {
        this.elements.val(changeValue);
    }

    isValid() {
        return !this._invalidSymbols.test(this.value);
    }
}

let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = $('.textbox');

inputs.on('input',function() {
    console.log(textbox.value);
    console.log(textbox.isValid());
});

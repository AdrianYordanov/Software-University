"use strict";

let result = (function () {
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
    class Form {
        constructor() {
            this._element = $("<div class='form'></div>");
            this._textboxes = [];

            let that = this;
            let arrayArguments = Array.from(arguments);
            arrayArguments.forEach(function (element) {
                if (!(element instanceof Textbox)) {
                    throw new Error('The argument is not Textbox');
                }
            });
            arrayArguments.forEach(function (element) {
                that._element.append(element.elements);
                that._textboxes.push(element);
            });
        }

        submit() {
            let allTextboxesAreValid = true;

            for (let textbox of this._textboxes) {
                if (textbox.isValid()) {
                    textbox.elements.css('border', '2px solid green');
                } else {
                    allTextboxesAreValid = false;
                    textbox.elements.css('border', '2px solid red');
                }
            }

            return allTextboxesAreValid;
        }

        attach(selector) {
            $(selector).append(this._element);
        }
    }

    return {
        Textbox: Textbox,
        Form: Form
    }
})();

let Textbox = result.Textbox;
let Form = result.Form;
let username = new Textbox("#username",/[^a-zA-Z0-9]/);
let password = new Textbox("#password",/[^a-zA-Z]/);
username.value = "username";
password.value = "password2";
let form = new Form(username,password);
form.attach("#root");
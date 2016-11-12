"use strict";

class Checkbox {
    constructor(label, selector) {
        let that = this;

        this._label = label;
        this._elements = $(selector)
            .on("change", function () {
                that.value = this.checked;
            });
        this.value = this.elements[0].checked;
    }

    get label() {
        return this._label;
    }

    get elements() {
        return this._elements;
    }

    get value() {
        return this._value;
    }

    set value(newValue) {
        if (newValue == "true") {
            newValue = true;
        } else if (newValue == "false") {
            newValue = false;
        }

        if (typeof newValue !== "boolean") {
            throw new Error("The value should be boolean.");
        }

        this._value = newValue;
        this.elements.attr("checked", newValue);
    }
}

module.exports = Checkbox;
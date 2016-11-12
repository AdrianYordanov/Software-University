"use strict";

class Numberbox {
    constructor(label, selector, minValue, maxValue) {
        let that = this;

        this._label = label;
        this._elements = $(selector)
            .on('change', function () {
                that.value = $(this).val();
            });
        this._value = this.elements.val();
        this.minValue = minValue;
        this.maxValue = maxValue;
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
        newValue = Number(newValue);

        if (typeof newValue !== "number") {
            throw new Error("The value should be number.");
        }

        if (newValue < this.minValue || newValue > this.maxValue) {
            throw new Error(`The value should be in the range [${this.minValue}..${this.maxValue}].`);
        }

        this._value = newValue;
        this.elements.val(newValue);
    }
}

module.exports = Numberbox;
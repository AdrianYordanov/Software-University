"use strict";

class BaseElement {
    constructor() {
        if (new.target === BaseElement) {
            throw new Error("Abstract class BaseElement can not be directly instanced.");
        }

        this.element = null;
    }

    appendTo(selector) {
        this.createElement();
        $(selector).append(this.element);
    }

    createElement() {
        let resultHtml = this.getElementString();
        this.element = $(resultHtml);
    }

    getElementString() {
        // TODO: Should be initialize in the children classes.
        // TODO: Should return HTML string.
    }
}

module.exports = BaseElement;
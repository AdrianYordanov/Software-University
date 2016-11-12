"use strict";

let BaseElement = require("./base-element.js");

class TitleBar extends BaseElement {
    constructor(title) {
        super();

        this.title = title;
        this.links = [];
    }

    addLink(href, name) {
        this.links.push(
            $(`<a href="${href}">`)
                .addClass("menu-link")
                .text(name)
        );
    }

    getElementString() {
        let navigation = $("<nav>")
            .addClass("menu");

        this.links.forEach(link => navigation.append(link));

        return $("<header>")
            .addClass("header")
            .append($("<div>")
                .append($("<span>")
                    .addClass("title")
                    .text(this.title)
                )
            )
            .append($("<div>")
                .append(navigation)
            );
    }
}

module.exports = TitleBar;
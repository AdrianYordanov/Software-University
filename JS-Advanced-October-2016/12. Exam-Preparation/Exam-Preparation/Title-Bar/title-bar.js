"use strict";

class TitleBar {
    constructor(title) {
        this.title = title;
        this.html = this.createHtml();
    }

    createHtml() {
        let that = this;
        let drawer = $("<div class='drawer'></div>").css('display', 'none');
        let navigation = $("<nav class='menu'></nav>");
        let eventLink = $("<a class='button'>&#9776;</a>").on('click', function () {
            if (drawer.css('display') == 'none') {
                drawer.css('display', 'block')
            } else {
                drawer.css('display', 'none');
            }
        });
        drawer.append(navigation);

        return $("<header class='header'></header>")
            .append(
                $("<div class='header-row'></div>")
                    .append(eventLink)
                    .append($(`<span class='title'>${that.title}</span>`))
            )
            .append(drawer);
    }

    addLink(href, name) {
        this.html.find('nav.menu').append($(`<a class='menu-link' href='${href}'>${name}</a>`));
    }

    appendTo(selector) {
        $(selector).append(this.html);

    }
}

let header = new TitleBar('Title Bar Problem');
header.addLink('/', 'Home');
header.addLink('about', 'About');
header.addLink('results', 'Results');
header.addLink('faq', 'FAQ');
header.appendTo('#container');
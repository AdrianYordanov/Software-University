"use strict";

class Post {
    constructor(title, body, author) {
        this.title = title;
        this.body = body;
        this.author = author;
    }

    addToSelector(selector) {
        let result = $('<div>')
            .addClass('post ' + this.author)
            .append($('<h3>')
                .addClass('title')
                .text(this.title))
            .append($('<p>')
                .addClass('body')
                .text(this.body))
            .append($('<p>')
                .addClass('author')
                .text(this.author));
        $(selector).append(result);
    }
}

module.exports = Post;
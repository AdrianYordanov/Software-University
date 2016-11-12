"use strict";

let Article = require("./article.js");

class ImageArticle extends Article {
    constructor(title, content, image) {
        super(title, content);

        this.image = image;
    }

    getElementString() {
        let result =  $(super.getElementString());
        result.find(".article-title")
            .after(
                $("<div>")
                    .addClass("image")
                    .append($("<img>")
                        .attr('src', this.image)
                    )
            );

        return result;
    }
}

module.exports = ImageArticle;
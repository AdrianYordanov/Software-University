"use strict";

class Person {
    constructor(name, age) {
        this.age = age;
        this.name = name;
    }

    addToSelector(selector) {
        let result = $('<div>')
            .addClass('person ' + this.name)
            .append($('<p>')
                .addClass('name')
                .text(this.name))
            .append($('<p>')
                .addClass('age')
                .text(this.age))
            .append($('<div>')
                .addClass('posts ' + this.name));
        $(selector).append(result);
    }
}

module.exports = Person;


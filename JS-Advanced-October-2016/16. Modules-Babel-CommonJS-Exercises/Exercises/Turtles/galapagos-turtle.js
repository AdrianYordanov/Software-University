"use strict";

import Turtle from "./turtle";

export default class GalapagosTurtle extends Turtle {
    constructor(name, age, geneder) {
        super(name, age, geneder);

        this._eaten = [];
    }

    get thingsEaten() {
        return this._eaten;
    }

    grow(age) {
        super.grow(age);
        this._eaten = [];
    }

    eat(food) {
        this.thingsEaten.push(food);
    }

    toString() {
        return `${ super.toString()}\nThings, eaten this year: ${this.thingsEaten.join(', ')}`;
    }
}
"use strict";

import Turtle from "./turtle";

export default class EvkodianTurtle extends Turtle {
    constructor(name, age, gender, evkodiumValue) {
        super(name, age, gender);

        this._evkodium = evkodiumValue;
    }

    get evkodium() {
        return {
            value: this._evkodium,
            density: this.density
        };
    }

    get density() {
        if (this.gender == 'male') {
            return this.age * 3;
        }

        return this.age * 2;
    }

    toString() {
        return super.toString() + `\nEvkodium: ${this._evkodium * this.density}`;
    }
}
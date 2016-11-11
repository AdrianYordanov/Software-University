"use strict";
import Entity from "./entity";

export  default class Dog extends Entity {
    constructor(name) {
        super(name);
    }

    saySomething() {
        return `${this.name} barks!`;
    }
}
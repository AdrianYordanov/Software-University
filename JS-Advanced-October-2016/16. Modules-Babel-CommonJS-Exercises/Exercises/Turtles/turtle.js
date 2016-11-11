"use strict";

export default class Turtle {
    constructor(name, age, geneder) {
        if (new.target === Turtle) {
            throw new Error("Abstract class Turtle can not be directly instanced.");
        }

        this._name = name;
        this._age = age;
        this._gender = geneder;
    }

    get name() {
        return this._name;
    }

    get age() {
        return this._age;
    }

    get gender() {
        return this._gender;
    }

    grow(age) {
        this._age += age;
    }

    toString() {
        return `Turtle: ${this.name}\nAged - ${this.age}; Gender - ${this.gender}`;
    }
}
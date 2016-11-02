"use strict";

class Rat {
    constructor(name) {
        this.name = name;
        this._rats = [];
    }

    unite(otherRat) {
        if(otherRat instanceof Rat) {
            this._rats.push(otherRat);
        }
    }

    getRats() {
        return this._rats;
    }

    toString() {
        if(this._rats.length == 0) {
            return this.name;
        }

        return this.name + '\n##' + this._rats.join('');
    }
}

let rat = new Rat('name1');
let rat2 = new Rat('name2');
rat2.unite(new Rat('name3'));
rat.unite(rat2);
console.log(rat + '');
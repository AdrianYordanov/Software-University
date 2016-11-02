"use strict";

class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;

        if(this.innerLength < 3) {
            this.innerLength = 0;
        }
    }

    toString() {
        if(this.innerLength == 0) {
            return '...';
        }

        if(this.innerString.length > this.innerLength) {
            this.innerString = this.innerString.slice(0, this.innerLength);
            return this.innerString + '...';
        }

        return this.innerString;
    }
}

let stringer = new Stringer('test123', 5);
console.log(stringer + '');
let stringer2 = new Stringer('test1', 4);
stringer2.decrease(1);
console.log(stringer2 + '');
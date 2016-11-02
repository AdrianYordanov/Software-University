"use strict";

class SortedList {
    constructor() {
        this.array = [];
        this.size = 0;
    }

    add(element) {
        this.size++;
        this.array.push(element);
        this.array.sort((a, b) => a - b);
        return this;
    }

    remove(index) {
        if (index >= 0 && index < this.array.length) {
            this.array.splice(index, 1);
            --this.size;
            return this;
        }
    }

    get(index) {
        if (index >= 0 && index < this.array.length) {
            return this.array[index];
        }
    }
}

let sortedList = new SortedList();
sortedList
    .add(2)
    .add(-3)
    .add(20);

console.log(sortedList);
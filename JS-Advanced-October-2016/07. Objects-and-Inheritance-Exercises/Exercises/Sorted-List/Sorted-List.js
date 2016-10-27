"use strict";

function sortedList() {
    let instance = (function () {
        let array = [];
        let size = 0;

        function add(element) {
            ++size;
            array.push(element);
            array.sort((a, b) => a - b);
            return this;
        }

        function remove(index) {
            if (index >= 0 && index < array.length) {
                array.splice(index, 1);
                --size;
                return this;
            }
        }

        function get(index) {
            if (index >= 0 && index < array.length) {
                return array[index];
            }
        }

        return {
            add: add,
            remove: remove,
            get: get,
            get size() {
                return size;
            }
        }
    })();

    return instance;
}

let newSortedList = sortedList();
newSortedList
    .add(3)
    .add(5)
    .remove(0);
console.log(newSortedList.size);
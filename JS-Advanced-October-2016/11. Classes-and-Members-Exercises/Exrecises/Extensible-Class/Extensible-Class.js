"use strict";

let Extensible = (function () {
    let id = 0;

    class Extensible {
        constructor() {
            this.id = id;
            ++id;
        }

        extend(template) {
            let currentObj = this;

            for (let prop in template) {
                if (typeof template[prop] == 'function') {
                    let parent = Object.getPrototypeOf(currentObj);
                    parent[prop] = template[prop];
                } else {
                    currentObj[prop] = template[prop];
                }
            }
        }
    }

    return Extensible;
})();

let obj1 = new Extensible();
let obj2 = new Extensible();
let obj3 = new Extensible();
console.log(obj1.id);
console.log(obj2.id);
console.log(obj3.id);

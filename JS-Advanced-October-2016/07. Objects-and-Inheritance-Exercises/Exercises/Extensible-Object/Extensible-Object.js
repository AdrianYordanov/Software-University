"use strict";

function extensibleObject() {
    let obj = {};

    function extendFunction(template) {
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

    obj.extend = extendFunction;
    return obj;
}

let obj = extensibleObject();
let template = {
    extensionMethod: function () {
        return 'just function'
    },
    extensionProperty: 'someString'
};
obj.extend(template);
console.log(obj);
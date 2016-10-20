"use strict";

function assignProperties([prop1, val1, prop2, val2, prop3, val3]) {
    let obj = {};
    obj[prop1] = val1;
    obj[prop2] = val2;
    obj[prop3] = val3;

    console.log(obj);
}

assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male']);
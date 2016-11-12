"use strict";

//result.Checkbox = require("./js/checkbox");
//result.Numberbox = require("./js/numberbox");

let Checkbox = require("./js/checkbox.js");
let Numberbox = require("./js/numberbox.js");

(function () {
    let checkbox = new Checkbox("Is Married:", "#married");
    let numberbox = new Numberbox("Age:", "#age", 1, 100);

    checkbox.elements.on('change', ()=>console.log(checkbox.value));
    numberbox.elements.on('change', ()=>console.log(numberbox.value));
})();
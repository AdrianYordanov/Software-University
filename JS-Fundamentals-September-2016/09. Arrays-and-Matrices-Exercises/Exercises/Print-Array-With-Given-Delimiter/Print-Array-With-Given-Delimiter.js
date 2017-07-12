"use strict";

function printArrayWithGivenDelimiter(input) {
    let delimiter = input.pop();
    console.log(input.join(delimiter));
}

printArrayWithGivenDelimiter(["one", "two", "three", "four", "-"]);
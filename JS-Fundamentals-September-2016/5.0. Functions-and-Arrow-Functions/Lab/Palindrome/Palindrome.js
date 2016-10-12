"use strict";

function palindrome([string]) {
    console.log(string === reverse(string));

    function reverse(str){
        return str.split("").reverse().join("");
    }
}

palindrome(['racecar']);


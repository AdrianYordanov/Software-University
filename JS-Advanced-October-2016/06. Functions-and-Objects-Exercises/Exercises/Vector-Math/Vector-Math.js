"use strict";

let vectorMath = (function () {
    function addition(vec1, vec2) {
        let [x, y] = [vec1[0] + vec2[0], vec1[1] + vec2[1]];
        return [x, y];
    }

    function multiply(vec1, scalar) {
        let [x, y] = [vec1[0] * scalar, vec1[1] * scalar];
        return [x, y];
    }

    function length(vec1) {
        return Math.sqrt(vec1[0] * vec1[0] + vec1[1] * vec1[1]);
    }

    function dot(vec1, vec2) {
        return vec1[0] * vec2[0] + vec1[1] * vec2[1];
    }

    function cross(vec1, vec2) {
        return vec1[0] * vec2[1] - vec1[1] * vec2[0];
    }

    return {
        add: addition,
        multiply: multiply,
        length: length,
        dot: dot,
        cross: cross
    }
})();

console.log(vectorMath.add([1, 1], [1, 0]));
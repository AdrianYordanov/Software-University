"use strict";

function euclidAlg(a ,b) {
    if (b == 0) {
        return a;
    }

    return euclidAlg(b, a % b);
}

console.log(euclidAlg(252, 105));

"use strict";

function lastKNumbersSequence([n, k]) {
    [n, k] = [n, k].map(Number);
    let array = [];

    for (let i = 0; (i < k) && (i < n); ++i) {
        if (i < 2)
            array.push(1);
        else
            array[i] = array
                .slice(0, i)
                .reduce((a, b) => a + b);
    }

    for (let i = k; i < n; ++i) {
        array[i] = array
            .slice(i - k, i)
            .reduce((a, b) => a + b);
    }

    console.log(array.join(', '))
}

lastKNumbersSequence(['1', '2']);
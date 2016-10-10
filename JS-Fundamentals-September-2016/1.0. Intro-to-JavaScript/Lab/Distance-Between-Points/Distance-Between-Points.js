"use strict";

function distanceBetweenPoints([x1, y1, x2, y2]) {
    let distance = Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    console.log(distance);
}

distanceBetweenPoints(['2.34', '15.66', '-13.55', '-2.9985']);
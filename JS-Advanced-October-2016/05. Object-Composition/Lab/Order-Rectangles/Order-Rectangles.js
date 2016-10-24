"use strict";

function orderRectangles(rectParameters) {
    let rectangles = [];

    for (let currentRectParam of rectParameters) {
        let newRectangle = {
            width: currentRectParam[0],
            height: currentRectParam[1],
            area: function () {
                return this.width * this.height;
            },
            compareTo: function (another) {
                return another.area() - this.area() || another.width - this.width;
            }
        };
        rectangles.push(newRectangle);
    }

    rectangles.sort((a, b) => a.compareTo(b));
    return rectangles;
}

orderRectangles([[10,5], [3,20], [5,12]]);
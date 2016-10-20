"use strict";

function quadraticEquation(array) {
    let [a, b, c] = array.map(Number);

    if( a < 0) {
        a = -a;
        b = -b;
        c = -c;
    }

    let discriminant = b * b - 4 * a * c;

    if (discriminant <= 0) {
        if (discriminant == 0) {
            let x = (-b + Math.sqrt(discriminant)) / (2 * a);
            console.log(x);
            return;
        }
        else {
            console.log("No");
            return;
        }
    }

    let x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
    let x2 = (-b - Math.sqrt(discriminant)) / (2 * a);

    if (x1 > x2) {
        let temp = x1;
        x1 = x2;
        x2 = temp;
    }

    console.log(x1);
    console.log(x2);
}

quadraticEquation(['6', '11', '-35']);
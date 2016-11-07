"use strict";

function classHierarchy() {
    class Figure {
        constructor() {
            if (new.target === Figure) {
                throw new Error('Can not directly instance this class.');
            }
        }

        get area() {
            throw new Error('This should not happen.');
        }

        toString() {
            return `${this.constructor.name} - `;
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();
            this.radius = radius;
        }

        get area() {
            return Math.PI * this.radius * this.radius;
        }

        toString() {
            return `${super.toString()}radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height) {
            super();
            this.width = width;
            this.height = height;
        }

        get area() {
            return this.width * this.height;
        }

        toString() {
            return `${super.toString()}width: ${this.width}, height: ${this.height}`;
        }
    }

    return {Figure, Circle, Rectangle};
}

let result = classHierarchy();

//let f = new Figure(); Should throw error.
let c = new result.Circle(5);
console.log(c.area);
console.log(c.toString());
let r = new result.Rectangle(3,4);
console.log(r.area);
console.log(r.toString());

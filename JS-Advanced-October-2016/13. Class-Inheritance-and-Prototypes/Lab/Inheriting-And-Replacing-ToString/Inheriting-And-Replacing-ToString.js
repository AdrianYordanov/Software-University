"use strict";

function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.email = email;
            this.name = name;
        }

        toString() {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return `${super.toString().slice(0, -1)}, subject: ${this.subject})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return `${super.toString().slice(0, -1)}, course: ${this.course})`;
        }
    }

    return {Person, Teacher, Student};
}

let result = toStringExtension();
let person = new result.Person('Ivan', 'ivan@gmail.com');
let teacher = new result.Teacher('Peter', 'peter@gmail.com', 'math');
let student = new result.Student('Steve', 'steve@gmail.com', 'js-advanced');

console.log(person + '');
console.log(teacher + '');
console.log(student + '');
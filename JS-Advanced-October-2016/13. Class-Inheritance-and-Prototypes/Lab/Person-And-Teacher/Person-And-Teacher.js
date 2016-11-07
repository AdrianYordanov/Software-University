"use strict";

function personAndTeacher() {
    class Person {
        constructor(name, email) {
            this.email = email;
            this.name = name;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    }

    return {Person, Teacher};
}

let result = personAndTeacher();
let person = new result.Person('Ivan', 'ivan@gmail.com');
let teacher = new result.Teacher('Peter', 'peter@gmail.com', 'math');

console.log(person);
console.log(teacher);
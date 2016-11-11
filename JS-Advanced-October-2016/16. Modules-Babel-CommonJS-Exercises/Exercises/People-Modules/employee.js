"use strict";

export default class Employee {
    constructor(name, age) {
        if (new.target === Employee) {
            throw new Error("The class can not be instanced directly.");
        }

        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    work() {
        let currentTask = this.tasks.shift();
        console.log(currentTask);
        this.tasks.push(currentTask);
    }

    collectSalary() {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }

    getSalary() {
        return this.salary;
    }
}
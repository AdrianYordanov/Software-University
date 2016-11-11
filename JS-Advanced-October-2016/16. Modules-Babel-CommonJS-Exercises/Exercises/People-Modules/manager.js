"use strict";

import Employee from "./employee";

export default class Manager extends Employee {
    constructor(name, age) {
        super(name, age);
        this.dividend = 0;
        this.tasks.push(`${this.name} scheduled a meeting.`);
        this.tasks.push(`${this.name} is preparing a quarterly report.`);
    }

    getSalary() {
        return this.salary + this.dividend;
    }
}
"use strict";

import Employee from "./employee";

export default class Junior extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks.push(`${this.name} is working on a simple task.`);
    }
}
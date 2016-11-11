"use strict";

import Employee from "./employee";

export default class Senior extends Employee {
    constructor(name, age) {
        super(name, age);
        this.tasks.push(`${this.name} is working on a complicated task.`);
        this.tasks.push(`${this.name} is taking time off work.`);
        this.tasks.push(`${this.name} is supervising junior workers.`);
    }
}
"use strict";

export default class Branch {
    constructor(id, branchName, companyName) {
        this.id = id;
        this.branchName = branchName;
        this.companyName = companyName;
        this._employees = [];
    }

    get employees() {
        return this._employees;
    }

    hire(employee) {
        this.employees.push(employee);
    }

    toString() {
        let result = `@ ${this.companyName}, ${this.branchName}, ${this.id}\nEmployed:\n`;
        this.employees.length > 0 ? result += this.employees.map(e => "** " + e).join("\n") : result += "None...";
        return result;
    }
}
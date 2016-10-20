"use strict";

function parseEmployeeData(array) {
    let regex = /^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9 -]+)$/;

    for (let employee of array) {
        let info = regex.exec(employee);

        if(info)
            console.log(
                `Name: ${info[1]}\n` +
                `Position: ${info[3]}\n` +
                `Salary: ${info[2]}`);
    }
}

parseEmployeeData([
    'Isacc - 1000 - CEO',
    'Ivan - 500 - Employee',
    'Peter - 500 - Employee']);
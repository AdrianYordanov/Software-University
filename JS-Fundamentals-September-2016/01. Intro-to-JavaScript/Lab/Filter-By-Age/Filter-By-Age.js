"use strict";

function FilterByAge([minAge, firstName, firstAge, secondName, secondAge]) {
    let minimumAge = Number(minAge);
    let firstPerson = { name: firstName, age: Number(firstAge) },
        secondPerson = { name: secondName, age: Number(secondAge) };

    if(firstPerson.age >= secondPerson.age) {
        if(firstPerson.age >= minimumAge)
            console.log(firstPerson);
        else return;
        if(secondPerson.age >= minimumAge)
            console.log(secondPerson);
    }
    else {
        if(secondPerson.age >= minimumAge)
            console.log(secondPerson);
        else return;
        if(firstPerson.age >= minimumAge)
            console.log(firstPerson);
    }
}

FilterByAge(['12', 'Ivan', '15', 'Asen', '9']);
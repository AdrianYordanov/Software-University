"use strict";

function constructionCrew(person) {
    if(person['handsShaking'] == true) {
        person['bloodAlcoholLevel'] += 0.1 * person['weight'] * person['experience'];
        person['handsShaking'] = false;
    }

    return person;
}

let obj = {
    weight: 80,
    experience: 1,
    bloodAlcoholLevel: 0,
    handsShaking: true
};

console.log(constructionCrew(obj));
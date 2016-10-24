"use strict";

function personalBMI(name, age, weight, height) {
    let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        }
    };

    setBMI(person);
    setStatus(person);
    setRecommendation(person);
    roundAllNumericValues(person);

    return person;

    function setBMI(obj) {
        let weight = obj.personalInfo.weight;
        let heightImMeters = obj.personalInfo.height / 100;
        obj.BMI = weight / (heightImMeters * heightImMeters);
    }

    function setStatus(obj) {
        let status = '';

        if (obj.BMI < 18.5) {
            status = 'underweight';
        } else if (obj.BMI < 25) {
            status = 'normal';
        } else if (obj.BMI < 30) {
            status = 'overweight';
        } else {
            status = 'obese';
        }

        obj.status = status;
    }

    function setRecommendation(obj) {
        if (obj.status == 'obese') {
            obj.recommendation = 'admission required';
        }
    }

    function roundAllNumericValues(obj) {
        obj.personalInfo.age = Math.round(obj.personalInfo.age);
        obj.personalInfo.weight = Math.round(obj.personalInfo.weight);
        obj.personalInfo.height = Math.round(obj.personalInfo.height);
        obj.BMI = Math.round(obj.BMI);
    }
}

console.log(personalBMI("Peter", 29, 75, 182));


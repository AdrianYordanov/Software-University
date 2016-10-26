"use strict";

function carFactory(requirements) {
    let newCar = {
        model: requirements.model
    };
    let engines = [
        {power: 90, volume: 1800},
        {power: 120, volume: 2400},
        {power: 200, volume: 3500}
    ];

    addEngine();
    addCarriage();
    addWheelsize();

    return newCar;

    function addEngine() {
        requirements.power = roundRequirement(requirements.power);

        for (let engine of engines) {
            if (requirements.power <= engine.power || requirements.power == 200) {
                newCar.engine = engine;
                return;
            }
        }
    }

    function addCarriage() {
        newCar.carriage = {
            type: requirements.carriage,
            color: requirements.color
        }
    }

    function addWheelsize() {
        newCar.wheels = [];
        requirements.wheelsize = roundRequirement(requirements.wheelsize);

        for (let i = 0; i < 4; ++i) {
            newCar.wheels.push(requirements.wheelsize);
        }
    }

    function roundRequirement(requirement) {
        requirement = Math.trunc(requirement);

        if (requirement % 2 == 0) {
            --requirement;
        }

        return requirement;
    }
}

let obj = {
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
};

console.log(carFactory(obj));
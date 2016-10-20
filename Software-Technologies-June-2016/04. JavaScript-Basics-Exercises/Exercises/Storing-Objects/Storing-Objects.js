function run(array) {
    for(let str of array) {
        let tokens = str.split(' -> ');
        let currentPerson = {
            'Name': tokens[0],
            'Age': tokens[1],
            'Grade': tokens[2]
        };

        printPerson(currentPerson);
    }

    function printPerson(person) {
        for(let key in person) {
            console.log(`${key}: ${person[key]}`);
        }
    }
}

run([
    'Pesho -> 13 -> 6.00',
    'Ivan -> 12 -> 5.57',
    'Toni -> 13 -> 4.90'
]);
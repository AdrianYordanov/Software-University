function run(array) {
    for(let line of array) {
        let currentPerson = JSON.parse(line);
        printPerson(currentPerson);
    }

    function printPerson(person) {
        for(let key in person) {
            let changedKey = key.charAt(0).toUpperCase() + key.slice(1);
            console.log(`${changedKey}: ${person[key]}`);
        }
    }
}

run([
    '{"name":"Gosho","age":10,"date":"19/06/2005"}',
    '{"name":"Tosho","age":11,"date":"04/04/2005"}'
]);
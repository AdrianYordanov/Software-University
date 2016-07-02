function run(array) {
    let person = {};

    for(let line of array) {
        let tokens = line.split(' -> ');
        let key = tokens[0];
        let value = tokens[1];
        person[key] = value;

        if (!isNaN(value)) {
            person[key] = Number(value);
        }
    }

    console.log(JSON.stringify(person));
}

run([
    'name -> Angel',
    'surname -> Georgiev',
    'age -> 20',
    'grade -> 6.00',
    'date -> 23/05/1995',
    'town -> Sofia'
]);
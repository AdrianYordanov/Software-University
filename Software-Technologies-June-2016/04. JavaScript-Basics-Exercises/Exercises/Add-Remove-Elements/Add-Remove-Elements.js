function run(array) {
    let list = [];

    for(let i = 0; i < array.length; ++i) {
        let tokens = array[i].split(' ');
        let command = tokens[0];
        let valueOrIndex = tokens[1];

        if(command === "add") {
            list.push(valueOrIndex);
        }
        else if(command === "remove") {
            list.splice(valueOrIndex, 1);
        }
    }

    console.log(list.join('\n'));
}

run([
    'add 3',
    'add 5',
    'remove 2',
    'remove 0',
    'add 7'
]);
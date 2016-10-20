function run(array) {
    let dictionary = {};
    let givenKeyToPrint = array.pop();

    while(array.length > 0) {
        let currentElement = array.shift();
        let tokens = currentElement.split(' ');
        let key = tokens[0];
        let value = tokens[1];

        if(!(key in dictionary)) {
            dictionary[key] = [];
        }

        dictionary[key].push(value);
    }

    console.log(givenKeyToPrint in dictionary ?
        dictionary[givenKeyToPrint].join('\n'):
        'None');
}

run([
    '3 test',
    '3 test1',
    '4 test2',
    '4 test3',
    '4 test5',
    '4'
]);
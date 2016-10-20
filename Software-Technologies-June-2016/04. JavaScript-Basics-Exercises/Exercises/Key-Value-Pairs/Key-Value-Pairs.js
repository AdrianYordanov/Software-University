function run(array) {
    let dictionary = {};
    let givenKeyToPrint = array.pop();

    while(array.length > 0) {
        let currentElement = array.shift();
        let tokens = currentElement.split(' ');
        let key = tokens[0];
        let value = tokens[1];

        dictionary[key] = value;
    }

    console.log(givenKeyToPrint in dictionary ?
        dictionary[givenKeyToPrint] :
        'None');
}

run([
    '3 bla',
    '3 alb',
    '2'
]);
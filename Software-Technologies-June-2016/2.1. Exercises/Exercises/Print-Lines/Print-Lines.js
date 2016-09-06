function run(array) {
    for(let str of array) {
        if(str === "Stop")
            break;

        console.log(str);
    }
}

run([
    '3',
    '6',
    '5',
    '4',
    'Stop',
    '10',
    '12'
]);
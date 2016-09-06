function run(array) {
    let numbers = array.map(Number);
    let result = 0;

    if(numbers[1] >= numbers[0]) {
        result = numbers[0] * numbers[1];
    } else {
        result = numbers[0] / numbers[1];
    }

    console.log(result);
}

run(['20', '30']);
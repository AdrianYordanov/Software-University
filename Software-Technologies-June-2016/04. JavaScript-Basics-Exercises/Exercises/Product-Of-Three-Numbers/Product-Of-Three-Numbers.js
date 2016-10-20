function run(array) {
    let numbers = array.map(Number);
    let result = isNegative(numbers);

    if(result) {
        console.log("Positive");
    } else {
        console.log("Negative");
    }

    function isNegative(numbers) {
        let counter = 0;

        if (numbers[0] < 0) {
            ++counter;
        }

        if(numbers[1] < 0) {
            ++counter;
        }

        if(numbers[2] < 0) {
            ++counter;
        }

        return counter % 2 === 0;
    }
}

run(['-20', '10', '-30']);
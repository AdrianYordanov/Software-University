function run(array) {
    let numbers = array.map(Number);
    let result = multiplyTwoNumbers(numbers[0], numbers[1]);
    console.log(result);

    function multiplyTwoNumbers(first, second) {
        return first * second;
    }
}

run(['10', '20']);
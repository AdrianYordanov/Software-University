function run(array) {
    let number = Number(array[0]);
    let result = multiplyNumber(number);
    console.log(result);

    function multiplyNumber(number) {
        return number * 2;
    }
}

run(['20']);
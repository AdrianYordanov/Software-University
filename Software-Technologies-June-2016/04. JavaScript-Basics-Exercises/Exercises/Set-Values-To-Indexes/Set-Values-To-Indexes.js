function run(array) {
    let n = Number(array[0]);
    let container = Array(n);
    setDefaultValue(container);

    for (let i = 1; i < array.length; ++i) {
        let lineTokens = array[i].split(' ');
        let selectedIndex = Number(lineTokens[0]);
        let selectedValue = Number(lineTokens[2]);
        container[selectedIndex] = selectedValue;
    }

    console.log(container.join('\n'));

    function setDefaultValue(array) {
        for (let i = 0; i < array.length; ++i) {
            array[i] = 0;
        }
    }
}

run([
    '3',
    '0 - 5',
    '1 - 6',
    '2 - 7'
]);
function run(array) {
    let reversed = array.reverse();

    for(let value of reversed) {
        console.log(value);
    }
}

run(['60', '20', '-5', '80']);
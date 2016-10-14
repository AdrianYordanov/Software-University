"use strict";

function userNames(array) {
    let result = array
        .map(changeUsername);

    console.log(result.join(', '));

    function changeUsername(username) {
        let tokens = username.split('@');
        let leftPart = tokens[0];
        let rightPart = '';
        tokens[1]
            .split('.')
            .forEach(subDomain => rightPart += subDomain[0]);
        return leftPart + '.' + rightPart;
    }
}

userNames(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);

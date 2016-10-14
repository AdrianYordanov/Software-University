"use strict";

function emailValidation([email]) {
    let result = email.search(/^[a-zA-Z0-9]+@[a-z]+.[a-z]+$/);

    if(result != -1)
        console.log('Valid');
    else
        console.log('Invalid');
}

emailValidation(['valid@email.bg']);
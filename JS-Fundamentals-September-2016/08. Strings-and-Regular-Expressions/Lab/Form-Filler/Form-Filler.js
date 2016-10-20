"use strict";

function formFiller(array) {
    let [username, email, phone] = [array.shift(), array.shift(), array.shift()];

    array.forEach(line =>
        console.log(line
            .replace(/<![a-z]+!>/gi, username)
            .replace(/<@[a-z]+@>/gi, email)
            .replace(/<\+[a-z]+\+>/gi, phone)));
}

formFiller(['Pesho',
    'pesho@softuni.bg',
    '90-60-90',
    'Hello, <!username!>!',
    'Welcome to your Personal profile.',
    'Here you can modify your profile freely',
    'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
    'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
    'Your current phone number is: <+number+>. Would you like to change that? (Y/N)'
]);
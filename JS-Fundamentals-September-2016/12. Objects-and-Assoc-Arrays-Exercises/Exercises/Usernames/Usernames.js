'use strict';

function usernames(input) {
    let users = new Set();

    for(let username of input){
        users.add(username);
    }

    Array.from(users.keys()).sort((a, b) => sortUsernames(a, b)).forEach(u => console.log(u));

    function sortUsernames(a, b) {
        if(a.length != b.length) {
            return(a.length - b.length);
        } else {
            return a.localeCompare(b);
        }
    }
}
"use strict";

function run(array) {
    let capitalCaseWords = array
        .join("")
        .split(/\W+/)
        .filter(word=> word !== "" && word === word.toUpperCase());

    console.log(capitalCaseWords.join(', '));
}

run([
    'We start by HTML, CSS, JavaScript, JSON and REST.',
    'Later we touch some PHP, MySQL and SQL.',
    'Later we play with C#, EF, SQL Server and ASP.NET MVC.',
    'Finally, we touch some Java, Hibernate and Spring.MVC.'
]);
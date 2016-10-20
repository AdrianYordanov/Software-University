"use strict";

function scoreToHTML([inputJSON]) {
    let array = JSON.parse(inputJSON);
    let html = '<table>\n  <tr><th>name</th><th>score</th></tr>\n';

    array.forEach(obj =>
        html += `  <tr><td>${escape(obj['name'])}</td><td>${escape(obj['score'])}</td></tr>\n`);

    html += '</table>';
    console.log(html);

    function escape(something) {
        let text = String(something);
        let escapingElements = {'<': '&lt;', '>': '&gt;', '&': '&amp;', '"': '&quot;', "'":"&#39;"};
        return text.replace(/["'&<>]/g, ch => escapingElements[ch]);
    }
}

scoreToHTML(['[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]']);
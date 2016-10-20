"use strict";

function fromJSONToHTMLTable([inputJSON]) {
    let array = JSON.parse(inputJSON);
    let html = '<table>\n';
    let properties = Object.keys(array[0]);
    html += createTableHeading(properties) + '\n';

    for(let currentObj of array) {
        html += '  <tr>';
        for (let currentKey in currentObj) {
            html += `<td>${escape(currentObj[currentKey])}</td>`;
        }
        html += '</tr>\n';
    }

    html += '</table>';
    console.log(html);

    function escape(something) {
        let text = String(something);
        let escapingElements = {'<': '&lt;', '>': '&gt;', '&': '&amp;', '"': '&quot;', "'": "&#39;"};
        return text.replace(/["'&<>]/g, ch => escapingElements[ch]);
    }

    function createTableHeading(propertiesArray) {
        let header = '<tr>';
        propertiesArray.forEach(prop => header += `<th>${prop}</th>`);
        header += '</tr>';
        return header;
    }
}

fromJSONToHTMLTable(['[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]']);
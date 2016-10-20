"use strict";

function multiplicationTable([number]) {
    let n = Number(number);
    let html = '<table border="1">\n';

    html += '  <tr><th>x</th>';

    for (let i = 1; i <= n; ++i) {
        html += `<th>${i}</th>`;
    }

    html += '</tr>\n';

    for (let row = 0; row < n; ++row) {
        html += `  <tr><th>${row + 1}</th>`;

        for (let col = 0, number = row + 1; col < n; ++col, number += row + 1) {
            html += `<td>${number}</td>`;
        }

        html += '</tr>\n';
    }

    html += '</table>';

    console.log(html);
}

multiplicationTable(['5']);
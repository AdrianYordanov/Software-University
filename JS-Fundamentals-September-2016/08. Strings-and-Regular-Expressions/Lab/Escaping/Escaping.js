"use strict";

function escapeHTML(array) {
    let escapingElements = {
        '<': '&lt;',
        '>': '&gt;',
        '&': '&amp;',
        '"': '&quot;'
    };

    let result = '<ul>\n' + array
            .map(userInput => `  <li>${userInput.replace(/["&<>]/g, ch => escapingElements[ch])}</li>`)
            .join('\n') + '\n</ul>';

    console.log(result);
}

escapeHTML(['<b>unescaped text</b>', 'normal text']);

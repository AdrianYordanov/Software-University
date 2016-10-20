"use strict";

function extractUniqueWords(array) {
    let set = new Set();

    for(let text of array) {
        text
            .toLowerCase()
            .split(/\W+/g)
            .filter(element => element != '')
            .forEach(word => set.add(word));
    }

    let uniqueWords = [...set.keys()];
    console.log(uniqueWords.join(', '));
}

extractUniqueWords([
    'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.'
]);
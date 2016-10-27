"use strict";

function domTraversal(selector) {
    let map = new Map();
    let startElement = $(selector);

    recursion(startElement, 1);

    let deepestLevel = 0;
    let deepestElement = startElement;
    map.forEach(function (value, key) {
        if (value > deepestLevel) {
            deepestLevel = value;
            deepestElement = key;
        }
    });

    for(let i = 0, parentNode = deepestElement; i <= deepestLevel; ++i) {
        parentNode.addClass('highlight');
        parentNode = parentNode.parent();
    }

    function recursion(element, level) {
        let children = element.children();

        for (let child of children) {
            let currentChild = $(child);
            map.set(currentChild, level);
            recursion(currentChild, level + 1);
        }
    }
}
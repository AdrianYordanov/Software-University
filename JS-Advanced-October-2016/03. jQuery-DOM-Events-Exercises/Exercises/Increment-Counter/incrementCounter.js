"use strict";

function increment(selector) {
    let textArea = $('<textarea class="counter" disabled>0</textarea>');
    let incrementBtn = $('<button class="btn" id="incrementBtn">Increment</button>').on('click', incrementEvent);
    let addBtn = $('<button class="btn" id="addBtn">Add</button>').on('click', addEvent);
    let list = $('<ul class="results"></ul>');

    $(selector)
        .append(textArea)
        .append(incrementBtn)
        .append(addBtn)
        .append(list);
    
    function incrementEvent() {
        let textArea = $('.counter');
        let currentValue = Number(textArea.val()) + 1;
        textArea.val(currentValue);
    }
    
    function addEvent() {
        let addValue = $('.counter').val();
        $('.results').append($('<li></li>').text(addValue));
    }
}
"use strict";

function timer() {
    let timerInSeconds = 1;
    let interval;
    
    $('#start-timer').on('click', function () {
        if(interval === undefined) {
            interval = setInterval(updateWatch, 1000);
        }
    });
    
    $('#stop-timer').on('click', function () {
        clearInterval(interval);
        interval = undefined;
    });
    
    function updateWatch() {
        let hours = Math.trunc(timerInSeconds / (60 * 60));
        let leftSeconds = timerInSeconds % (60 * 60);
        let minutes = Math.trunc(leftSeconds / 60);
        let seconds = leftSeconds % 60;

        $('#hours').text(('0' + hours).slice(-2));
        $('#minutes').text(('0' + minutes).slice(-2));
        $('#seconds').text(('0' + seconds).slice(-2));

        ++timerInSeconds;
    }
}
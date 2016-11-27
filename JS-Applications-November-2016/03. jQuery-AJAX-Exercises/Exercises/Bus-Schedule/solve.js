"use strict";
function  solve() {

    let apiUrl = 'https://judgetests.firebaseio.com/schedule/';
    let currentStop = 'depot';
    let nextStop = 'depot';

    function depart() {
        toggleButtons('#arrive', '#depart');
        $.ajax({
            method: 'GET',
            url: apiUrl + currentStop + '.json',
            success: function (data) {
                nextStop = data.next;
                $('#info').find('span').text(`Next stop ${data.name}`);
            }
        });
    }

    function arrive() {
        toggleButtons('#depart', '#arrive');
        $.ajax({
            method: 'GET',
            url: apiUrl + currentStop + '.json',
            success: function (data) {
                $('#info').find('span').text(`Arriving at ${data.name}`);
                currentStop = nextStop;
            }
        });
    }

    function toggleButtons(buttonA, buttonB) {
        $(buttonA).removeAttr('disabled');
        $(buttonB).attr('disabled', 'disabled');
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
"use strict";

function attachGradientEvents() {
    document.getElementById('gradient').addEventListener('mousemove', gradientMove);
    document.getElementById('gradient').addEventListener('mouseout', gradientOut);

    function gradientMove(event) {
        console.log(event);
        let width = event.target.clientWidth - 1;
        let mouseX = event.offsetX;
        let percentage = 100 / width;
        let result = Math.trunc(mouseX * percentage);

        document.getElementById('result').textContent = result + '%';
    }

    function gradientOut() {
        document.getElementById('result').textContent = '';
    }
}
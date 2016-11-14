"use strict";

function cardDeckBuilder(selector) {
    let faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    let suits = {
        C: "\u2663",
        D: "\u2666",
        H: "\u2665",
        S: "\u2660"
    };

    function addCard(face, suit) {
        suit = suits[suit];

        if(!faces.includes(face) || suit == undefined) {
            return;
        }

        let container = $(selector);
        let card = $("<div>")
            .addClass("card")
            .text(`${face} ${suit}`)
            .on("click", function () {
                container
                    .children()
                    .each(function(iindex, div) {
                        container.prepend(div)
                    })
            });

        container.append(card);
    }

    return {
        addCard: addCard
    }
}
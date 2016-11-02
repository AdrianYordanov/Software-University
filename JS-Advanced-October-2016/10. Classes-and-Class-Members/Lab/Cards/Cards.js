"use strict";

let result = (function () {
    let Suits = {
        SPADES: '\u2660',
        HEARTS: '\u2665',
        DIAMONDS: '\u2666',
        CLUBS: '\u2663'
    };
    let Faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(face) {
            if(Faces.indexOf(face) < 0) {
                throw new Error('Invalid face.');
            }

            this._face = face;
        }

        get suit() {
            return this._suit;
        }

        set suit(suit) {
            let suitsValues = Object.keys(Suits).map(suit => Suits[suit]);

            if(suitsValues.indexOf(suit) < 0) {
                throw new Error('Invalid face.');
            }

            this._suit = suit;
        }
    }

    return {
        Card: Card,
        Suits: Suits
    }
})();

let Card = result.Card;
let Suits = result.Suits;

let card = new Card("Q", Suits.CLUBS);
card.face = "A";
card.suit = Suits.DIAMONDS;
let card2 = new Card("1", Suits.DIAMONDS); // Should throw exception.
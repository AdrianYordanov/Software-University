"use strict";

function sortTickets(tickets, sortMethod) {
    let ticketsContainer = [];
    let sortMethods = {
        destination: (a, b) => a.destination.localeCompare(b.destination),
        price: (a, b) => a.price - b .price,
        status: (a, b) => a.status.localeCompare(b.status)
    };

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for(let ticket of tickets) {
        let tokens = ticket.split('|');
        ticketsContainer.push(new Ticket(tokens[0], Number(tokens[1]), tokens[2]));
    }

    return ticketsContainer.sort(sortMethods[sortMethod]);
}

let result = sortTickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
);
console.log(result);
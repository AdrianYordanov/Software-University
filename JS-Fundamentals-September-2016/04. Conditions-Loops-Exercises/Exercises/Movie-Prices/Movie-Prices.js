"use strict";

function moviePrices([movie, day]) {
    movie = movie.toLowerCase();
    day = day.toLowerCase();

    let ticketPrice = "error";

    if (movie == "the godfather") {
        switch (day) {
            case "monday":
                ticketPrice = 12;
                break;
            case "tuesday":
                ticketPrice = 10;
                break;
            case "wednesday":
                ticketPrice = 15;
                break;
            case "thursday":
                ticketPrice = 12.5;
                break;
            case "friday":
                ticketPrice = 15;
                break;
            case "saturday":
                ticketPrice = 25;
                break;
            case "sunday":
                ticketPrice = 30;
                break;
        }
    } else if (movie == "schindler's list") {
        switch (day) {
            case "monday":
                ticketPrice = 8.5;
                break;
            case "tuesday":
                ticketPrice = 8.5;
                break;
            case "wednesday":
                ticketPrice = 8.5;
                break;
            case "thursday":
                ticketPrice = 8.5;
                break;
            case "friday":
                ticketPrice = 8.5;
                break;
            case "saturday":
                ticketPrice = 15;
                break;
            case "sunday":
                ticketPrice = 15;
                break;
        }
    } else if (movie == "casablanca") {
        switch (day) {
            case "monday":
                ticketPrice = 8;
                break;
            case "tuesday":
                ticketPrice = 8;
                break;
            case "wednesday":
                ticketPrice = 8;
                break;
            case "thursday":
                ticketPrice = 8;
                break;
            case "friday":
                ticketPrice = 8;
                break;
            case "saturday":
                ticketPrice = 10;
                break;
            case "sunday":
                ticketPrice = 10;
                break;
        }
    } else if (movie == "the wizard of oz") {
        switch (day) {
            case "monday":
                ticketPrice = 10;
                break;
            case "tuesday":
                ticketPrice = 10;
                break;
            case "wednesday":
                ticketPrice = 10;
                break;
            case "thursday":
                ticketPrice = 10;
                break;
            case "friday":
                ticketPrice = 10;
                break;
            case "saturday":
                ticketPrice = 15;
                break;
            case "sunday":
                ticketPrice = 15;
                break;
        }
    }

    console.log(ticketPrice);
}

moviePrices(['The Godfather', 'Friday']);
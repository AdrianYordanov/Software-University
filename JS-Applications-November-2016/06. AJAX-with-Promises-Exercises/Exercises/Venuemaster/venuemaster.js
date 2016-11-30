"use strict";

function attachEvents() {
    const appId = "kid_BJ_Ke8hZg";
    const username = "guest";
    const password = "pass";
    let container = $("#venue-info");

    $("#getVenues").on("click", function () {
        let venueDate = $("#venueDate").val();

        if (validateDate(venueDate)) {
            getVenuesIdRequest(venueDate);
        }
    });

    function getVenuesIdRequest(venueDate) {
        let url = "https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/calendar?query=" + venueDate;
        makeRequest("POST", url)
            .then(function (data) {
                container.empty();

                for (let venueId of data) {
                    getVenueByIdRequest(venueId);
                }
            });
    }

    function getVenueByIdRequest(id) {
        let url = "https://baas.kinvey.com/appdata/kid_BJ_Ke8hZg/venues/" + id;
        makeRequest("GET", url)
            .then(renderVenue)
    }

    function getConfirmedHtmlRequest(venue, qty) {
        let url = "https://baas.kinvey.com/rpc/kid_BJ_Ke8hZg/custom/purchase?venue=" + venue._id + "&qty=" + qty;
        makeRequest("POST", url)
            .then(function (data) {
                container.html(data.html);
            })
    }

    function renderVenue(venue) {
        container
            .append(
                $(`<div class="venue" id="${venue._id}">`)
                    .append(
                        $('<span class="venue-name">')
                            .append(
                                $('<input class="info" type="button" value="More info"></span>')
                                    .on('click', function () {
                                        let parent = $(this).parent().parent();
                                        let details = parent.find(".venue-details");

                                        if (details.css("display") == "none") {
                                            details.css("display", "block");
                                        } else {
                                            details.css("display", "none")
                                        }
                                    })
                            )
                            .append(venue.name)
                    )
                    .append(
                        $('<div class="venue-details" style="display: none;">')
                            .append(
                                $('<table>')
                                    .append(
                                        $('<tr><th>Ticket Price</th><th>Quantity</th><th></th></tr>')
                                    )
                                    .append(
                                        $('<tr>')
                                            .append(
                                                $('<td class="venue-price"></td>')
                                                    .text(venue.price + " lv")
                                            )
                                            .append(
                                                $(`<td><select class="quantity">
                                                      <option value="1">1</option>
                                                      <option value="2">2</option>
                                                      <option value="3">3</option>
                                                      <option value="4">4</option>
                                                      <option value="5">5</option>
                                                    </select></td>`)
                                            )
                                            .append(
                                                $('<td>')
                                                    .append(
                                                        $('<input class="purchase" type="button" value="Purchase">')
                                                            .on("click", function () {
                                                                let row = $(this).parent().parent();
                                                                let selectElement = row.find(".quantity");
                                                                let qty = selectElement.find(":selected").text();
                                                                renderConfirmation(venue, qty);
                                                            })
                                                    )
                                            )
                                    )
                            )
                            .append(
                                $('<span class="head">Venue description:</span>')
                            )
                            .append(
                                $('<p class="description"></p>')
                                    .text(venue.description)
                            )
                            .append(
                                $('<p class="description"></p>')
                                    .text(`Starting time: ${venue.startingHour}`)
                            )
                    )
            )
    }

    function renderConfirmation(venue, qty) {
        container.empty();
        container
            .append(
                $('<span class="head">Confirm purchase</span>')
            )
            .append(
                $('<div class="purchase-info">')
                    .append(
                        $('<span></span>')
                            .text(venue.name)
                    )
                    .append(
                        $('<span></span>')
                            .text(`${qty} x ${venue.price}`)
                    )
                    .append(
                        $('<span></span>')
                            .text(`Total: ${qty * venue.price} lv`)
                    )
                    .append(
                        $('<input type="button" value="Confirm">')
                            .on('click', function () {
                                getConfirmedHtmlRequest(venue, qty);
                            })
                    )
            )
    }

    function makeRequest(method, url, data) {
        let headers = {
            "Authorization": "Basic " + btoa(username + ":" + password)
        };

        let objectRequest = {
            method: method,
            headers: headers,
            url: url
        };

        if (data) {
            objectRequest["data"] = JSON.stringify(data);
            objectRequest["contentType"] = "application/json"
        }

        return $.ajax(objectRequest);
    }

    function validateDate(date) {
        let tokens = date.split('-');

        if (tokens.length != 2) {
            return false;
        }

        let firstNumber = Number(tokens[0]);
        let secondNumber = Number(tokens[1]);

        if (firstNumber < 1 || firstNumber > 31 || secondNumber < 1 || secondNumber > 12) {
            return false;
        }

        return true;
    }
}
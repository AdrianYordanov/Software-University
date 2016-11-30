"use strict";

function loadApp() {
    const appId = "kid_BJRuignI";
    const username = "guest";
    const password = "guest";
    const baseUrl = "https://baas.kinvey.com/appdata/" + appId + "/";

    // Application starts with displaying the countries and attaching the events.
    getCountriesRequest();
    $("#addCountry").on("click", function () {
        let data = {
            name: $("#country").val()
        };
        addCountryRequest(data);
    });

    // Countries request.
    function getCountriesRequest() {
        let requestUrl = baseUrl + "countries";
        makeRequest("GET", requestUrl)
            .then(renderCountries)
    }

    function addCountryRequest(data) {
        let requestUrl = baseUrl + "countries";
        makeRequest("POST", requestUrl, data)
            .then(function () {
                getCountriesRequest()
            });
    }

    function editCountryRequest(data, countryId) {
        let requestUrl = baseUrl + "countries/" + countryId;
        makeRequest("PUT", requestUrl, data)
            .then(function () {
                getCountriesRequest()
            });
    }

    function deleteCountryRequest(countryId) {
        let requestUrl = baseUrl + "countries/" + countryId;
        makeRequest("DELETE", requestUrl)
            .then(function () {
                getCountriesRequest();
                deleteTownsByCountryIdRequest(countryId);
            });
    }

    // Towns requests.
    function getTownsRequest(countryId) {
        let data = {
            country: countryId
        };
        let requestUrl = baseUrl + "towns?query=" + JSON.stringify(data);
        makeRequest("GET", requestUrl)
            .then(renderTowns)
    }

    function addTownRequest(data, countryId) {
        let requestUrl = baseUrl + "towns";
        makeRequest("POST", requestUrl, data)
            .then(function () {
                getTownsRequest(countryId);
            });
    }

    function editTownRequest(data, townId, countryId) {
        let requestUrl = baseUrl + "towns/" + townId;
        makeRequest("PUT", requestUrl, data)
            .then(function () {
                getTownsRequest(countryId);
            });
    }

    function deleteTownRequest(townId, countryId) {
        let requestUrl = baseUrl + "towns/" + townId;
        makeRequest("DELETE", requestUrl)
            .then(function () {
                getTownsRequest(countryId);
            });
    }

    function deleteTownsByCountryIdRequest(countryId) {
        let data = {
            country: countryId
        };
        let requestUrl = baseUrl + "towns?query=" + JSON.stringify(data);
        makeRequest("DELETE", requestUrl)
            .then(function () {
                $("#towns").empty();
            });
    }

    // Requester.
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

        return $.ajax(objectRequest)
    }

    // Countries renderer.
    function renderCountries(data) {
        let container = $("#countries");
        container.empty();

        for (let country of data) {
            container
                .append(
                    $("<li>")
                        .attr("data-id", country._id)
                        .append(
                            $("<span>")
                                .text(country.name)
                        )
                        .append(" ")
                        .append(
                            $('<a href="#">Edit</a>').on("click", function () {
                                let name = prompt("Edit country name:");

                                if (name === null) {
                                    return;
                                }

                                let data = {
                                    name: name
                                };
                                let parent = $(this).parent();
                                let countryId = parent.attr("data-id");

                                editCountryRequest(data, countryId);
                            })
                        )
                        .append(" ")
                        .append(
                            $('<a href="#">Delete</a>').on("click", function () {
                                let parent = $(this).parent();
                                let countryId = parent.attr("data-id");

                                deleteCountryRequest(countryId);
                            })
                        )
                        .append(" ")
                        .append(
                            $('<a href="#">Add town</a>').on("click", function () {
                                let parent = $(this).parent();
                                let name = prompt("Add town name:");
                                let countryId = parent.attr("data-id");

                                if (name === null) {
                                    return;
                                }

                                let data = {
                                    name: name,
                                    country: countryId
                                };

                                addTownRequest(data, countryId);
                            })
                        )
                        .on("click", function () {
                            let countryId = $(this).attr("data-id");
                            getTownsRequest(countryId);
                        })
                );
        }
    }

    // Towns renderer.
    function renderTowns(data) {
        let container = $("#towns");
        container.empty();

        for (let town of data) {
            container
                .append(
                    $("<li>")
                        .attr("data-id", town._id)
                        .attr("data-country-id", town.country)
                        .append(
                            $("<span>")
                                .text(town.name)
                        )
                        .append(" ")
                        .append(
                            $('<a href="#">Edit</a>').on("click", function () {
                                let name = prompt("Edit town name:");
                                let parent = $(this).parent();
                                let townId = parent.attr("data-id");
                                let countryId = parent.attr("data-country-id");

                                if (name === null) {
                                    return;
                                }

                                let data = {
                                    name: name,
                                    country: countryId
                                };

                                editTownRequest(data, townId, countryId);
                            })
                        )
                        .append(" ")
                        .append(
                            $('<a href="#">Delete</a>').on("click", function () {
                                let parent = $(this).parent();
                                let townId = parent.attr("data-id");
                                let countryId = parent.attr("data-country-id");

                                deleteTownRequest(townId, countryId);
                            })
                        )
                );
        }
    }
}
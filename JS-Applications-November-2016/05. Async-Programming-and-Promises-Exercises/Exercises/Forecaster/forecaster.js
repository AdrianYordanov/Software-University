"use strict";

function attachEvents() {
    let mainContainer = $("#forecast");
    let todayWeather = undefined;
    let upcomingWeather = undefined;

    $("#submit").on("click", locationCodeRequest);

    function locationCodeRequest() {
        restContainer();
        let inputLocation = $("#location").val();

        $.ajax({
            url: "https://judgetests.firebaseio.com/locations.json"
        })
            .then(function (data) {
                let code = data
                    .filter(location => location.name == inputLocation)[0].code;

                if (code) {
                    makeWeatherReport(code);
                }
            })
            .catch(renderError);
    }

    function makeWeatherReport(code) {
        Promise.all([todayRequest(code), upcomingRequest(code)])
            .then(function ([todayRequestData, upcomingRequestData]) {
                renderTodayRequest(todayRequestData);
                renderUpcomingRequest(upcomingRequestData);
            });

        function todayRequest(code) {
            return $.ajax({
                url: "https://judgetests.firebaseio.com/forecast/today/" + code + ".json"
            })
        }

        function upcomingRequest(code) {
            return $.ajax({
                url: "https://judgetests.firebaseio.com/forecast/upcoming/" + code + ".json"
            })
        }

        function renderTodayRequest(location) {
            mainContainer.show();

            let name = location.name;
            let forecast = location.forecast;
            let todayContainer = $("#current");

            todayContainer
                .append(
                    $("<div>")
                        .addClass("label")
                        .text("Current conditions")
                )
                .append(
                    $("<span>")
                        .addClass("condition symbol")
                        .html(getSymbolByCondition(forecast.condition))
                )
                .append(
                    $("<span>")
                        .addClass("condition")
                        .append(
                            $("<span>")
                                .addClass("forecast-data")
                                .text(name)
                        )
                        .append(
                            $("<span>")
                                .addClass("forecast-data")
                                .html(`${forecast.low}&deg;/${forecast.high}&deg;`)
                        )
                        .append(
                            $("<span>")
                                .addClass("forecast-data")
                                .text(forecast.condition)
                        )
                );
        }

        function renderUpcomingRequest(location) {
            mainContainer.show();

            let forecasts = location.forecast;
            let upcomingContainer = $("#upcoming");

            for (let forecast of forecasts) {
                upcomingContainer
                    .append(
                        $("<div>")
                            .addClass("label")
                            .text("Three-day forecast")
                    )
                    .append(
                        $("<span>")
                            .addClass("upcoming")
                            .append(
                                $("<span>")
                                    .addClass("symbol")
                                    .html(getSymbolByCondition(forecast.condition))
                            )
                            .append(
                                $("<span>")
                                    .addClass("forecast-data")
                                    .html(`${forecast.low}&deg;/${forecast.high}&deg;`)
                            )
                            .append(
                                $("<span>")
                                    .addClass("forecast-data")
                                    .text(forecast.condition)
                            )
                    )
            }
        }

        function getSymbolByCondition(condition) {
            let forecast = "";

            switch (condition) {
                case "Sunny":
                    forecast = "&#x2600;";
                    break;
                case "Partly sunny":
                    forecast = "&#x26C5;";
                    break;
                case "Overcast":
                    forecast = "&#x2601;";
                    break;
                case "Rain":
                    forecast = "&#x2614;";
                    break;
                case "Degrees":
                    forecast = "&#176;";
                    break;
            }

            return forecast;

        }
    }

    function renderError() {
        mainContainer.text("Error");
        mainContainer.show();
    }

    function restContainer() {
        todayWeather = $("<div id='current'>");
        upcomingWeather = $("<div id='upcoming'>");

        mainContainer
            .hide()
            .empty()
            .append(todayWeather)
            .append(upcomingWeather);
    }
}
"use strict";

function getInfo() {
    let stopId = $("#stopId").val();
    let stopName = $("#stopName");
    let busesContainer = $("#buses");

    stopName.empty();
    busesContainer.empty();

    $.get("https://judgetests.firebaseio.com/businfo/" + stopId + ".json")
        .then(function (data) {
            stopName.text(data.name);

            for (let bus in data.buses) {
                busesContainer.append(
                    $("<li>").text(`Bus ${bus} arrives in ${data.buses[bus]} minutes`)
                )
            }
        })
        .catch(function () {
            stopName.text("Error");
        });
}
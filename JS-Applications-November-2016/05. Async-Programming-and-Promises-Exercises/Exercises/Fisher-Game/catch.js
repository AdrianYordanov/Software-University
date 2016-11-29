"use strict";

function attachEvents() {
    const appId = "kid_BJRuignI";
    const username = "guest";
    const password = "guest";
    const baseTableUrl = "https://baas.kinvey.com/appdata/" + appId + "/biggestCatches";
    let headers = {
        "Authorization": "Basic " + btoa(username + ":" + password)
    };

    $(".load").on("click", function () {
        loadCatchesRequest();
    });
    $(".add").on("click", function () {
        let addCatchElement = $("#addForm");
        let data = getDataFromCatchElement(addCatchElement);
        addCatchRequest(data);
    });

    function loadCatchesRequest() {
        makeRequest(baseTableUrl, "GET")
            .then(displayCatches)
    }

    function addCatchRequest(data) {
        makeRequest(baseTableUrl, "POST", data)
            .then(function () {
                loadCatchesRequest();
            });
    }

    function updateCatchesRequest(data, catchId) {
        let url = baseTableUrl + "/" + catchId;
        makeRequest(url, "PUT", data)
            .then(function () {
                loadCatchesRequest();
            });
    }

    function deleteCatchRequest(catchId) {
        let url = baseTableUrl + "/" + catchId;
        makeRequest(url, "DELETE")
            .then(function () {
                loadCatchesRequest();
            });
    }

    function makeRequest(url, method, data) {
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

    function displayCatches(catches) {
        let container = $("#catches");
        container.empty();

        for (let currentCatch of catches) {
            let mainDiv = $(`<div class="catch" data-id="${currentCatch._id}">`)
                .append($('<label>Angler</label>'))
                .append($('<input type="text" class="angler"/>').val(currentCatch.angler))
                .append($('<label>Weight</label>'))
                .append($('<input type="number" class="weight"/>').val(currentCatch.weight))
                .append($('<label>Species</label>'))
                .append($('<input type="text" class="species"/>').val(currentCatch.species))
                .append($(' <label>Location</label>'))
                .append($('<input type="text" class="location"/>').val(currentCatch.location))
                .append($('<label>Bait</label>'))
                .append($('<input type="text" class="bait"/>').val(currentCatch.bait))
                .append($('<label>Capture Time</label>'))
                .append($('<input type="number" class="captureTime"/>').val(currentCatch.captureTime))
                .append($('<button class="update">Update</button>')
                    .on("click", function () {
                        let currentCatchElement = $(this).parent();
                        let data = getDataFromCatchElement(currentCatchElement);
                        let catchId = currentCatchElement.attr("data-id");
                        updateCatchesRequest(data, catchId)
                    }))
                .append($('<button class="delete">Delete</button>')
                    .on("click", function () {
                        let currentCatchElement = $(this).parent();
                        let catchId = currentCatchElement.attr("data-id");
                        deleteCatchRequest(catchId);
                    }));

            container.append(mainDiv);
        }
    }

    function getDataFromCatchElement(catchElement) {
        return {
            angler: catchElement.find(".angler").val(),
            weight: Number(catchElement.find(".weight").val()),
            species: catchElement.find(".species").val(),
            location: catchElement.find(".location").val(),
            bait: catchElement.find(".bait").val(),
            captureTime: Number(catchElement.find(".captureTime").val())
        };
    }
}
function attachEvents() {
    const appId = "kid_BJRuignI";
    const username = "guest";
    const password = "guest";
    const baseUrl = "https://baas.kinvey.com/appdata/" + appId + "/players/";
    let container = $("#players");
    let currentPlayerData = {};

    $("#save").on("click", invokeSave);
    $("#reload").on("click", function () {
        currentPlayerData.money -= 60;
        currentPlayerData.bullets = 6;

        if (currentPlayerData.money < 0) {
            currentPlayerData.money = 0;
        }
    });
    $("#addPlayer").on("click", function () {
        let name = $("#addName").val();
        addPlayerRequest(name);
    });

    getPlayersRequest();

    function getPlayersRequest() {
        makeRequest("GET", baseUrl)
            .then(renderPlayers);
    }

    function addPlayerRequest(name) {
        let defaultPlayer = {
            name: name,
            money: 500,
            bullets: 6
        };
        makeRequest("POST", baseUrl, defaultPlayer)
            .then(function () {
                getPlayersRequest();
            });
    }

    function deletePlayerRequest(playerId) {
        let url = baseUrl + playerId;
        makeRequest("DELETE", url)
            .then(function () {
                getPlayersRequest();
            })
    }

    function saveCurrentPlayerRequest(playerData, playerId) {
        let url = baseUrl + playerId;
        return makeRequest("PUT", url, playerData)
            .then(function () {
                let canvas = $("#canvas");
                canvas.hide();
                clearInterval(canvas[0].intervalId);
                $("#save").hide();
                $("#reload").hide();
            })
            .then(function () {
                getPlayersRequest();
            })
    }

    function invokeSave() {
        let playerId = currentPlayerData.id;

        let passingPlayerObject = {
            name: currentPlayerData.name,
            money: currentPlayerData.money,
            bullets: currentPlayerData.bullets
        };

        return saveCurrentPlayerRequest(passingPlayerObject, playerId);
    }

    function renderPlayers(players) {
        container.empty();

        for (let player of players) {
            container
                .append(
                    $(`<div class="player" data-id="${player._id}">`)
                        .append(
                            $('<div class="row">')
                                .append(
                                    $('<label>Name:</label>')
                                )
                                .append(
                                    $('<label class="name"</label>')
                                        .text(player.name)
                                )
                        )
                        .append(
                            $('<div class="row">')
                                .append(
                                    $('<label>Money:</label>')
                                )
                                .append(
                                    $('<label class="money"</label>')
                                        .text(player.money)
                                )
                        )
                        .append(
                            $('<div class="row">')
                                .append(
                                    $('<label>Bullets:</label>')
                                )
                                .append(
                                    $('<label class="bullets"</label>')
                                        .text(player.bullets)
                                )
                        )
                        .append(
                            $('<button class="play">Play</button>').on("click", function () {
                                let parent = $(this).parent();
                                let saveButton = $("#save");
                                let reloadButton = $("#reload");
                                let canvas = $("#canvas");

                                currentPlayerData.id = parent.attr("data-id");
                                currentPlayerData.name = parent.find(".name").text();
                                currentPlayerData.money = Number(parent.find(".money").text());
                                currentPlayerData.bullets = Number(parent.find(".bullets").text());

                                invokeSave()
                                    .then(function () {
                                        saveButton.show();
                                        reloadButton.show();
                                        canvas.show();

                                        loadCanvas(currentPlayerData);
                                    });
                            })
                        )
                        .append(
                            $('<button class="delete">Delete</button>').on("click", function () {
                                let parent = $(this).parent();
                                let playerId = parent.attr("data-id");
                                deletePlayerRequest(playerId);
                            })
                        )
                )
        }
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
}
"use strict";

(function secretKnock() {
    const appId = "kid_BJXTsSi-e";
    const appSecret = "447b8e7046f048039d95610c1b039390";
    const username = "guest";
    const password = "guest";
    const startMessage = "Knock Knock.";

    getRequest(startMessage);

    function getRequest(message) {
        console.log(message);

        let headers = {
            "Authorization": "Basic " + btoa(username + ":" + password)
        };

        $.ajax({
            headers: headers,
            url: "https://baas.kinvey.com/appdata/" + appId + "/knock?query=" + message
        })
            .then(function (dialog) {
                if (dialog.message) {
                    console.log(dialog.answer);
                    getRequest(dialog.message);
                }
            })
            .catch(function (error) {
                console.dir(error);
            });
    }
})();
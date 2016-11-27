"use strict";

function attachEvents() {
    $("#submit").on("click", addMessage);

    $("#refresh").on("click", getMessages);

    function getMessages() {
        let messagesContainer = $("#messages");
        messagesContainer.empty();

        $.ajax({
            method: "GET",
            url: "https://messenger-f91ce.firebaseio.com/.json",
            success: function (data) {
                let messages = [];

                for (let key in data) {
                    messages.push(data[key]);
                }
                let sortedMessages = messages.sort((a, b) => a.timestamp - b.timestamp);
                let textToAppend = sortedMessages
                    .map(object => `${object.author}: ${object.content}`)
                    .join("\n");
                messagesContainer.text(textToAppend);
            },
            error: function () {
                alert("ERROR");
            }
        })
    }

    function addMessage() {
        let pushObject = {
            author: $("#author").val(),
            content: $("#content").val()
        };

        $.ajax({
            method: "POST",
            url: "https://messenger-f91ce.firebaseio.com/.json",
            data: JSON.stringify(pushObject),
            success: function () {
                getMessages();
            },
            error: function () {
                alert("ERROR");
            }
        })
    }
}
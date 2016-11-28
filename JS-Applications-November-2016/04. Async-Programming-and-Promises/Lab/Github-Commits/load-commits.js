"use strict";

function loadCommits() {
    let username = $("#username").val();
    let repo = $("#repo").val();
    let container = $("#commits");

    container.empty();

    $.ajax({
        method: "GET",
        url: "https://api.github.com/repos/" + username + "/" + repo + "/commits"
    })
        .then(function (data) {
            for (let commit of data) {
                container.append(
                    $("<li>").text(`${commit.commit.author.name}: ${commit.commit.message}`)
                )
            }
        })
        .catch(function (error) {
            container.append(
                $("<li>").text(`Error: ${error.status} (${error.statusText})`)
            )
        });
}
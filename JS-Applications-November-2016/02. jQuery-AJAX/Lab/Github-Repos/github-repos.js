"use strict";

function loadRepos() {
    $('#repos').empty();
    let username = $('#username').val();
    let request = {
        method: 'GET',
        url: 'https://api.github.com/users/' + username + '/repos',
        success: renderRepositories,
        error: renderErrorMessage
    };

    $.ajax(request);

    function renderRepositories(repositories) {
        for (let repo of repositories) {
            let listItem = $('<li>')
                .append($('<a>')
                    .attr('href', repo.html_url)
                    .text(repo.full_name));

            listItem.appendTo($('#repos'));
        }
    }

    function renderErrorMessage() {
        $('<li>').text('Error').appendTo($('#repos'));
    }
}

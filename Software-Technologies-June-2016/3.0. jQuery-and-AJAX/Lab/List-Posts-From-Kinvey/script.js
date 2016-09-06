$("button").on('click', function () {
    makeRequest();
});

function makeRequest() {
    let headersRequest = {
        "Authorization": "Basic " + btoa("guest:guest"),
        "Content-Type": "application/json"
    };

    $.ajax({
        method: "GET",
        url: "https://baas.kinvey.com/appdata/kid_BJRuignI/posts",
        headers: headersRequest,
        success: function(data) {
            for(let post of data) {
                let newListItem = $("<li>");
                newListItem.text(post.title + " -> " + post.body);
                $("#items").append(newListItem);
            }
        },
        error: function(data) {
            $("#errors").append(JSON.stringify(data));
        }
    });
}
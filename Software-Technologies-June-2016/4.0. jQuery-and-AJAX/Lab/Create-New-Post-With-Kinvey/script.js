$("button").on('click', function () {
    makeRequest();
});

function makeRequest() {
    let headersRequest = {
        "Authorization": "Basic " + btoa("guest:guest"),
        "Content-Type": "application/json"
    };
    let dataRequest = {
        "title": $("#title").val(),
        "body": $("#body").val()
    };

    $.ajax({
        method: "POST",
        url: "https://baas.kinvey.com/appdata/kid_BJRuignI/posts",
        data: JSON.stringify(dataRequest),
        headers: headersRequest,
        success: function(data) {
            $("#output").append(JSON.stringify(data));
        },
        error: function(data) {
            $("#output").append(JSON.stringify(data));
        }
    });
}
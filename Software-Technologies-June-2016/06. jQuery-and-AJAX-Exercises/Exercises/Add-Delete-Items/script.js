$("button").on('click', function () {
    let inputText = $("#inputField");
    addItem(inputText.val());
    inputText.val('');
});

function addItem(text) {
    let li = $("<li>")
        .append($("<span>").text(text))
        .append(" ")
        .append("<a href='#' onclick='deleteItems(this)'>[Delete]</a>")
    $("#items").append(li);
}

function deleteItems(link) {
    $(link)
        .parent()
        .remove();
}
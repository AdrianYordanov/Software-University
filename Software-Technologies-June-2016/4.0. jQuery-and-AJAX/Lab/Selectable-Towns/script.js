$("li").on('click', function () {
    let currentElement = $(this);

    if(currentElement.attr("data-selected")) {
        currentElement.removeAttr("data-selected");
    } 
    else {
        currentElement.attr("data-selected", true);
    }
});

$("#show-towns-button").on('click', function () {
    let towns = getAllSelectedElements();
    $("#towns-output").text("Selected towns: " + towns);

    function getAllSelectedElements() {
        let selectedJQueryElements = $("#items > li[data-selected]");
        let elements = [];

        for(let element of selectedJQueryElements) {
            elements.push(element.innerText);
        }

        return elements.join(", ");
    }
});
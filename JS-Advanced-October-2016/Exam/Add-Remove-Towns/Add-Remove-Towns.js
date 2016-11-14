"use strict";

function attachEvents() {
    $("#btnDelete").on("click", function () {
        let selectedTown = $("#newItem");
        $("#towns option:selected").remove();
    });

    $("#btnAdd").on("click", function () {
        let selectedTown = $("#newItem");

        if (selectedTown.val() === "") {
            return;
        }

        $("#towns").append(
            $("<option>").text(selectedTown.val())
        );

        selectedTown.val("");
    })
}
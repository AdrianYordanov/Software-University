"use strict";

function attachEvents() {
    $("#btnDelete").on("click", function () {
        let selectedTown = $("#townName");
        let result = $("#result");
        let removed = $("#towns option")
            .filter(function () {
                return this.value == selectedTown.val();
            })
            .remove();


        if(removed.length > 0) {
            result.text(`${selectedTown.val()} deleted.`);
        } else {
            result.text(`${selectedTown.val()} not found.`);
        }

        selectedTown.val("");
    })
}
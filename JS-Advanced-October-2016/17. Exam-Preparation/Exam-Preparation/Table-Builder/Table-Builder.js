"use strict";
function tableBuilder(selector) {
    function createTable(columnNames) {
        let tableRow = $("<tr>");

        for (let name of columnNames) {
            tableRow.append($("<th>").text(name))
        }

        $(selector)
            .empty()
            .append($("<table>")
                .append(tableRow
                    .append($("<th>").text("Action"))
                )
            );
    }

    function fillData(matrix) {
        let table = $(selector).find("table");

        for (let row of matrix) {
            let tableRow = $("<tr>");

            for (let column of row) {
                tableRow.append($("<td>").text(column))
            }

            table.append(
                tableRow
                    .append($("<td>")
                        .append($("<button>")
                            .text("Delete")
                            .click(function () {
                                let row = $(this).parent().parent();
                                row.remove();
                            })
                        )
                    )
            );
        }
    }

    return {
        createTable: createTable,
        fillData: fillData
    }
}
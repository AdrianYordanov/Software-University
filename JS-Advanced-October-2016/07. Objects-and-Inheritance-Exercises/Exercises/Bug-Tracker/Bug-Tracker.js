"use strict";

function bugTracker() {
    let tracker = (function () {
        let bugs = [];
        let currentId = 0;
        let container = undefined;

        function report(author, description, reproducible, severity) {
            bugs.push({
                ID: currentId,
                author: author,
                description: description,
                reproducible: reproducible,
                severity: severity,
                status: 'Open'
            });

            ++currentId;
            outputBugs();
        }

        function setStatus(id, newStatus) {
            let foundObj = bugs.filter(element => element.ID == id);

            if (foundObj.length > 0) {
                foundObj[0].status = newStatus;
            }

            outputBugs();
        }

        function remove(id) {
            bugs = bugs.filter(element => element.ID != id);
            outputBugs();
        }

        function sort(method) {
            let sortMethods = {
                author: (a, b) => a.author.localeCompare(b.author),
                severity: (a, b) => a.severity - b.severity,
                ID: (a, b) => a.ID - b.ID
            };

            bugs.sort(sortMethods[method]);
            outputBugs();
        }

        function output(selector) {
            container = $(selector);
        }

        function outputBugs() {
            container.empty();

            for (let bug of bugs) {
                let resultHtml = $(`<div id="report_${bug.ID}" class="report">`)
                    .append(
                        $(`<div class="body"></div>`)
                            .append($(`<p>${bug.description}</p>`))
                    )
                    .append($('<div class="title"></div>')
                        .append($(`<span class="author">Submitted by: ${bug.author}</span>`))
                        .append($(`<span class="status">${bug.status} | ${bug.severity}</span>`))
                    );
                container.append(resultHtml);
            }
        }

        return {
            report: report,
            setStatus: setStatus,
            remove: remove,
            sort: sort,
            output: output
        }
    })();

    return tracker;
}
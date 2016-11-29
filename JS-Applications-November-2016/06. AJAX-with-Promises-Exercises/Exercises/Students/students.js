"use strict";

(function() {
    const username = 'guest';
    const password = 'guest';
    const basicAuthHeader = {Authorization: "Basic " + btoa(username + ':' + password)};
    const appId = 'kid_BJXTsSi-e';
    const baseUrl = `https://baas.kinvey.com/appdata/${appId}/students/`;
    const loginUrl = `https://baas.kinvey.com/user/${appId}/login/`;
    const studentsContainer = $('#results');

    let sessionToken = null;

    $.post({
        url: loginUrl,
        headers: basicAuthHeader,
        data: JSON.stringify({
            username, password
        }),
        contentType: 'application/json'
    })
        .then((data) => sessionToken = data._kmd.authtoken)
        .then(getStudents)
        .then(bindEvents)
        .catch(renderError);

    function getStudents() {
        $.get({
            url: baseUrl,
            headers: {Authorization: `Kinvey ${sessionToken}`}
        })
            .then(renderStudents)
            .catch(renderError)
    }

    function renderStudents(students) {
        $('#results').find('tr.row').remove();
        students.sort((stA, stB) => stA.ID - stB.ID);

        for (let student of students) {
            let row = $('<tr class="row">');
            row
                .append($('<td>').text(student.ID))
                .append($('<td>').text(student.FirstName))
                .append($('<td>').text(student.LastName))
                .append($('<td>').text(student.FacultyNumber))
                .append($('<td>').text(student.Grade));

            studentsContainer.append(row);
        }
    }

    function bindEvents() {
        $('#add-new-student').on('submit', addNewStudent)
    }

    function addNewStudent(event) {
        event.preventDefault();
        let id = Number($('#id').val().trim());
        let firstName = $('#first-name').val().trim();
        let lastName = $('#last-name').val().trim();
        let facultyNumber = $('#faculty-number').val().trim();
        let grade = Number($('#grade').val().trim());

        $.ajax({
            method: 'POST',
            url: baseUrl,
            headers: {Authorization: `Kinvey ${sessionToken}`},
            data: JSON.stringify({
                ID: id,
                FirstName: firstName,
                LastName: lastName,
                FacultyNumber: facultyNumber,
                Grade: grade
            }),
            contentType: 'application/json'
        })
            .then(clearInputs)
            .then(getStudents)
            .catch(renderError)
    }

    function clearInputs() {
        $('input[id]').val('')
    }

    function renderError(error) {
        console.dir(error);
    }
})();
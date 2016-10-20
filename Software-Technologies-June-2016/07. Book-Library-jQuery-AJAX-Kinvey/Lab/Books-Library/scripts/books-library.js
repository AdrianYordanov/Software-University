const kinveyBaseUrl = 'https://baas.kinvey.com/';
const kinveyAppKey = 'kid_BJRuignI';
const kinveyAppSecret = 'a00a10fad9574127aec84756a4775272';

function showViews(viewName) {
    // Hide all views and show the selected view.
    $('main > section').hide();
    $('#' + viewName).show();
}

function showHideMenuLinks() {
    $('#linkHome').show();
    if(sessionStorage.getItem('authToken') == null) {
        // No logged user.
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkListBooks').hide();
        $('#linkCreateBook').hide();
        $('#linkLogout').hide();
    } else {
        // We have logged in user.

        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkListBooks').show();
        $('#linkCreateBook').show();
        $('#linkLogout').show();
    }
}

function showInfo(message) {
    $('#infoBox').text(message);
    $('#infoBox').show();
    setTimeout(function () {$('#infoBox').fadeOut()}, 3000);
}

function showError(errorMsg) {
    $('#errorBox').text("Error: " + errorMsg);
    $('#errorBox').show();
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response);
    if(response.readyState === 0) {
        errorMsg =  "Cannot connect due to network error.";
    }
    if(response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description;
    }
    showError(errorMsg);
}

$(function () {
    showHideMenuLinks();
    showViews('viewHome');

    //Bind the navigation menu links.
    $('#linkHome').click(showHomeView);
    $('#linkLogin').click(showLoginView);
    $('#linkRegister').click(showRegisterView);
    $('#linkListBooks').click(listBooks);
    $('#linkCreateBook').click(showCreateBookView);
    $('#linkLogout').click(logout);

    //Bind the form submit buttons.
    $('#formLogin').submit(function(e) { e.preventDefault(); login(); });
    $('#formRegister').submit(function(e) { e.preventDefault(); register(); });
    $('#formCreateBook').submit(function(e) { e.preventDefault(); createBook(); });

    $(document).on({
        ajaxStart: function() { $('#loadingBox').show() },
        ajaxStop: function() { $('#loadingBox').hide() }
    });
});

function showHomeView() {
    showViews('viewHome');
}

function showLoginView() {
    showViews('viewLogin');
}
function login() {
    const kinveyLoginUrl = kinveyBaseUrl + 'user/' + kinveyAppKey + '/login';
    const kinveyAuthHeaders = {
        'Authorization': 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret)
    };
    let userData = {
        username: $('#loginUser').val(),
        password: $('#loginPass').val()
    };
    $.ajax({
        method: 'POST',
        url: kinveyLoginUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: loginSuccess,
        error: handleAjaxError
    });

    function loginSuccess(response) {
        let userAuth = response['_kmd']['authtoken'];
        sessionStorage.setItem('authToken', userAuth);
        showHideMenuLinks();
        listBooks();
        showInfo('Login successful');
    }
}

function showRegisterView() {
    showViews('viewRegister');
}
function register() {
    const kinveyRegisterUrl = kinveyBaseUrl + 'user/' + kinveyAppKey;
    const kinveyAuthHeaders = {
        'Authorization': 'Basic ' + btoa(kinveyAppKey + ':' + kinveyAppSecret)
    };
    let userData = {
        username: $('#registerUser').val(),
        password: $('#registerPass').val()
    };
    $.ajax({
        method: 'POST',
        url: kinveyRegisterUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: registerSuccess,
        error: handleAjaxError
    });
    
    function registerSuccess(response) {
        let userAuth = response['_kmd']['authtoken'];
        sessionStorage.setItem('authToken', userAuth);
        showHideMenuLinks();
        listBooks();
        showInfo('User registration successful.');
    }
}

function listBooks() {
    $('#books').empty();
    showViews('viewBooks');

    const kinveyBooksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';
    const kinveyAuthHeaders = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    };
    $.ajax({
        method: 'GET',
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        success: loadBooksSuccess,
        error: handleAjaxError
    });
    
    function loadBooksSuccess(books) {
        showInfo('Books loaded.');
        if(books.length == 0) {
            $('#books').text('No books in the library.');
        } else {
            let bookTable = $('<table>')
                .append($('<tr>')
                    .append(
                        $('<th>Title</th>'),
                        $('<th>Author</th>'),
                        $('<th>Description</th>')
                    )
                );

            for(let book of books) {
                bookTable.append(
                    $('<tr>').append(
                        $('<td>').text(book['title']),
                        $('<td>').text(book['author']),
                        $('<td>').text(book['description'])
                    )
                );

                let commentsTableData = $('<td colspan="3">');
                if(book['comments'] && book['comments'].length > 0) {
                    for(let comment of book['comments']) {
                        commentsTableData.append(
                            $('<div>')
                                .text(comment['text']),
                            $('<div>')
                                .text('-- ' + comment['author'])
                                .css({'margin-left': '20px', 'font-style': 'italic'})
                        )
                    }
                }
                commentsTableData.append(
                    $('<div>').append(
                        $('<a href="#">').text('[Add comment]').click(function () {
                            $(this).next().show();
                            $(this).hide();
                        }),
                        $('<form>').append(
                            $('<label>').text('Comment:'),
                            $('<input name="comment" type="text">').prop('required', true),
                            $('<label>').text('Author:'),
                            $('<input name="author" type="text">').prop('required', true),
                            $('<button type="submit">').text('Add Comment'),
                            $('<button type="button">').text('Cancel')
                                .click(function () {
                                    $(this).parent().prev().show();
                                    $(this).parent().hide();
                                })
                        )
                            .submit(function (event) {
                                let comment = $(this).find('input[name=comment]').val();
                                let author = $(this).find('input[name=author]').val();
                                addBookComment(book, comment, author);
                                event.preventDefault();
                            })
                            .hide()
                    )
                );

                bookTable.append($('<tr>').append(commentsTableData));
            }

            $('#books').append(bookTable);
        }
    }
}

function showCreateBookView() {
    showViews('viewCreateBook');
}
function createBook() {
    const kinveyBooksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';
    const kinveyAuthHeaders = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    };
    let bookData = {
        title: $('#bookTitle').val(),
        author: $('#bookAuthor').val(),
        description: $('#bookDescription').val()
    };
    $.ajax({
        method: 'POST',
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        data: bookData,
        success: createBookSuccess,
        error: handleAjaxError
    });
    
    function createBookSuccess(response) {
        listBooks();
        showInfo('Book created.');
    }
}

function addBookComment(bookData, commentText, commentAuthor) {
    const kinveyBooksUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';
    const kinveyHeaders = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken'),
        'Content-type': 'application/json'
    };
    bookData['comments'] = bookData['comments'] || [];
    bookData['comments'].push({text: commentText, author: commentAuthor});
    $.ajax({
        method: 'PUT',
        url: kinveyBooksUrl + '/' + bookData['_id'],
        headers: kinveyHeaders,
        data: JSON.stringify(bookData),
        success: addBookCommentSuccess,
        error: handleAjaxError
    });

    function addBookCommentSuccess(response) {
        listBooks();
        showInfo('Book comment added.');
    }
}

function logout() {
    sessionStorage.clear();
    showHideMenuLinks();
    showViews('viewHome');
}
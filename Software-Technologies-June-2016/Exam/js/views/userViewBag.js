var app = app || {};

app.userViews = (function () {
    function showSuccessMessage(message) {
        var element = $('<div>')
            .css('width', '80%')
            .css('height', '30px')
            .css('margin', '2px auto')
            .css('border', '3px solid green')
            .css('border-radius', '5px')
            .css('background-color', 'lightgreen')
            .css('text-align', 'center')
            .text(message);

        $('body').prepend(element);
        element
            .delay(2000)
            .fadeOut(500);
    }

    function showErrorMessage(message) {
        var element = $('<div>')
            .css('width', '80%')
            .css('height', '30px')
            .css('margin', '2px auto')
            .css('border', '3px solid darkred')
            .css('border-radius', '5px')
            .css('background-color', 'rgb(255, 68, 68)')
            .css('text-align', 'center')
            .text(message);

        $('body').prepend(element);
        element
            .delay(2000)
            .fadeOut(500);
    }

    function showGuestMenu(menu) {
        $.get('templates/menu-login.html', function (templ) {
            $(menu).html(templ);
        });
    }

    function showUserMenu(menu) {
        $.get('templates/menu-home.html', function (templ) {
            $(menu).html(templ);
        });
    }

    function showGuestHomePage(container) {
        $.get('templates/welcome-guest.html', function (templ) {
           $(container).html(templ);
        });
    }

    function showUserHomePage(container) {
        $.get('templates/welcome-user.html', function (templ) {
            var rendered = Mustache.render(templ, {username: sessionStorage['username']});
            $(container).html(rendered);
        });
    }

    function showLoginPage(container) {
        $.get('templates/login.html', function (templ) {
            $(container).html(templ);
            $('#login-button').on('click', function () {
                var user = {
                    username: $('#username').val(),
                    password: $('#password').val()
                };

                Sammy(function () {
                    this.trigger('onLogin', user);
                });
            });
        })
    }
    
    function showRegisterPage(container) {
        $.get('templates/register.html', function (templ) {
           $(container).html(templ);
            $('#register-button').on('click', function () {
                var user = {
                    username: $('#username').val(),
                    password: $('#password').val(),
                    confirmPassword: $('#confirm-password').val()
                };
                Sammy(function () {
                    this.trigger('onRegister', user);
                })
            });
        });
    }

    
    return {
        bag: {
            showSuccessMessage: showSuccessMessage,
            showErrorMessage: showErrorMessage,
            showGuestMenu: showGuestMenu,
            showUserMenu: showUserMenu,
            showGuestHomePage: showGuestHomePage,
            showUserHomePage: showUserHomePage,
            showLoginPage: showLoginPage,
            showRegisterPage: showRegisterPage
        }
    }
})();
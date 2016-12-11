"use strict";

class UserView {
    constructor() {
    }

    showGuestMenu(menu) {
        $.get('templates/menu-guest.html', function (templ) {
            $(menu).html(templ);
        });
    }

    showUserMenu(menu) {
        $.get('templates/menu-user.html', function (templ) {
            let rendered = Mustache.render(templ, {user: sessionStorage.getItem('username')});
            $(menu).html(rendered);
        });
    }

    showGuestHomePage(container) {
        $.get('templates/home-guest.html', function (templ) {
            $(container).html(templ);
        });
    }

    showUserHomePage(container) {
        $.get('templates/home-user.html', function (templ) {
            let rendered = Mustache.render(templ, {username: sessionStorage.getItem('username')});
            $(container).html(rendered);
        });
    }

    showLoginPage(container) {
        $.get('templates/login.html', function (templ) {
            $(container).html(templ);
            $('form').on('submit', function (e) {
                let user = {
                    username: $('#loginUsername').val(),
                    password: $('#loginPasswd').val()
                };
                Sammy(function () {
                    this.trigger('onLogin', user);
                });

                return false;
            });
        })
    }

    showRegisterPage(container) {
        $.get('templates/register.html', function (templ) {
            $(container).html(templ);
            $('form').on('submit', function () {
                let user = {
                    username: $('#registerUsername').val(),
                    password: $('#registerPasswd').val(),
                    name: $('#registerName').val()
                };
                Sammy(function () {
                    this.trigger('onRegister', user);
                });

                return false;
            });
        });
    }
}
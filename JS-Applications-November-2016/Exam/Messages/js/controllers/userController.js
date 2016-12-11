"use strict";

class UserController {
    constructor(model, view, notificationMessages) {
        this._model = model;
        this._view = view;
        this._notificationMessages = notificationMessages;
    }

    loadMenu(menu) {
        if (sessionStorage['userSession']) {
            this._view.showUserMenu(menu);
        } else {
            this._view.showGuestMenu(menu);
        }
    };

    loadHomePage(container) {
        if (sessionStorage['userSession']) {
            this._view.showUserHomePage(container);

        } else {
            this._view.showGuestHomePage(container);
        }
    };

    loadLoginPage(container) {
        this._view.showLoginPage(container);
    };

    loadRegisterPage(container) {
        this._view.showRegisterPage(container);
    };

    userRegister(user) {
        let _this = this;

        this._model.register(user)
            .then(
                function (user) {
                    _this._onUserLogIn(user);
                    _this._notificationMessages.showSuccessMessage('User registration successful.');
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    };

    userLogin(user) {
        let _this = this;

        this._model.login(user)
            .then(
                function (user) {
                    _this._onUserLogIn(user);
                    _this._notificationMessages.showSuccessMessage('Login successful.');
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    };

    userLogout() {
        let _this = this;

        this._model.logout()
            .then(
                function () {
                    _this._onUserLogOut();
                    _this._notificationMessages.showSuccessMessage('Logout successful.');
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    };

    _onUserLogIn(user) {
        sessionStorage['userSession'] = user['_kmd']['authtoken'];
        sessionStorage['username'] = user['username'];
        sessionStorage['name'] = user['name'];
        sessionStorage['userId'] = user['_id'];
        Sammy(function () {
            this.trigger('loadUrl', {url: '#/'});
        });
    }

    _onUserLogOut() {
        sessionStorage.clear();
        Sammy(function () {
            this.trigger('loadUrl', {url: '#/'});
        })
    }
}
var app = app || {};

app.userController = (function () {
    function UserController(model) {
        this.model = model;
    }
    
    UserController.prototype.loadMenu = function (menu) {
        if(sessionStorage['userSession']) {
            app.userViews.bag.showUserMenu(menu);
        } else {
            app.userViews.bag.showGuestMenu(menu);
        }
    };
    
    UserController.prototype.loadHomePage = function (container) {
        if(sessionStorage['userSession']) {
            app.userViews.bag.showUserHomePage(container);
            
        } else {
            app.userViews.bag.showGuestHomePage(container);
        }
    };

    UserController.prototype.loadLoginPage = function (container) {
        app.userViews.bag.showLoginPage(container);
    };

    UserController.prototype.loadRegisterPage = function (container) {
        app.userViews.bag.showRegisterPage(container);
    };

    UserController.prototype.userRegister = function (user) {
        if(user.password !== user.confirmPassword) {
            app.userViews.bag.showErrorMessage('Confirm password is different.');
            return;
        }

        this.model.register(user)
            .then(
                function (user) {
                    onUserLogIn(user);
                    app.userViews.bag.showSuccessMessage('Register successful!');
                },
                function (error) {
                    app.userViews.bag.showErrorMessage(error.responseJSON.description);
                }
            ).done();

    };

    UserController.prototype.userLogin = function (user) {
        this.model.login(user)
            .then(
                function (user) {
                    onUserLogIn(user);
                    app.userViews.bag.showSuccessMessage('Login successful!');
                },
                function (error) {
                    debugger;
                    app.userViews.bag.showErrorMessage(error.responseJSON.description);
                }
            )
    };

    UserController.prototype.userLogout = function () {
        this.model.logout()
            .then(
                function () {
                    onUserLogOut();
                    app.userViews.bag.showSuccessMessage('Logout successful!');
                },
                function (error) {
                    app.userViews.bag.showErrorMessage(error.responseJSON.description);
                }
            )
    };

    function onUserLogIn(user) {
        sessionStorage['userSession'] = user._kmd.authtoken;
        sessionStorage['username'] = user.username;
        sessionStorage['userId'] = user._id;
        Sammy(function () {
            this.trigger('loadUrl', {url: '#/'});
        });
    }

    function onUserLogOut() {
        sessionStorage.clear();
        Sammy(function () {
            this.trigger('loadUrl', {url: '#/'});
        })
    }

    return {
        config: function (model) {
            return new UserController(model);
        }
    }
})();
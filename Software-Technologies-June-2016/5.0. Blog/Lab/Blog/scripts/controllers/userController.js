class UserController {
    constructor(userView, requester, baseUrl, appKey) {
        this._userView = userView;
        this._requester = requester;
        this._baseServiceUrl = baseUrl + '/user/' + appKey + '/';
        this._appKey = appKey;
    }

    showLoginPage() {
        this._userView.showLoginPage();
    }

    showRegisterPage() {
        this._userView.showRegisterPage();
    }

    login(requestData) {
        let requestUrl = this._baseServiceUrl + 'login';

        this._requester.post(
            requestUrl,
            requestData,
            function success(data) {
                showPopup('success', 'You have successfully logged in.');

                sessionStorage['_authToken'] = data._kmd.authtoken;
                sessionStorage['username'] = data.username;
                sessionStorage['fullName'] = data.fullName;

                redirectUrl('#/');
            },
            function error(data) {
                showPopup('error', 'An error has occurred while attempting to login.');
            }
        )
    }

    register(requestData) {
        if(requestData.username.length < 5) {
            showPopup('error', 'Username must consist of at least 5 symbols.');
            return;
        }

        if(requestData.fullName.length < 8) {
            showPopup('error', 'Full name must consist of at least 8 symbols.');
            return;
        }

        if(requestData.password.length < 6) {
            showPopup('error', 'Password must consist of at least 6 symbols.');
            return;
        }

        if(requestData.password !== requestData.confirmPassword) {
            showPopup('error', 'Passwords do not match.');
            return;
        }

        delete requestData['confirmPassword'];

        let requestUrl = this._baseServiceUrl;
        this._requester.post(
            requestUrl,
            requestData,
            function success(data) {
                showPopup('success', 'You have successfully registered.');
                redirectUrl('#/login');
            },
            function error(data) {
                showPopup('error', 'An error has occurred while attempting to register.');
            }
        )
    }

    logout() {
        sessionStorage.clear();
        redirectUrl('#/');
    }
}
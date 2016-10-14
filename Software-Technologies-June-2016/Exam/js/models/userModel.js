var app = app || {};

app.userModel = (function () {
    function UserModel(requester) {
        this.requester = requester;
        this.serviceUrl = this.requester.baseUrl + '/user/' + this.requester.appId;
    }
    
    UserModel.prototype.register = function (user) {
        return this.requester.post(this.serviceUrl, user, true);
    };

    UserModel.prototype.login = function (user) {
        var requestUrl = this.serviceUrl + '/login';
        return this.requester.post(requestUrl, user, true);
    };
    
    UserModel.prototype.logout = function () {
        var requestUrl = this.serviceUrl + '/_logout';
        return this.requester.post(requestUrl, null, false);
    };

    return {
        config: function (requester) {
            return new UserModel(requester);
        }
    }
})();
"use strict";

class UserModel {
    constructor(requester) {
        this._requester = requester;
        this._serviceUrl = this._requester.baseUrl + '/user/' + this._requester.appId;
    }

    register(user) {
        return this._requester.post(this._serviceUrl, user);
    };

    login(user) {
        let requestUrl = this._serviceUrl + '/login';
        return this._requester.post(requestUrl, user);
    };

    logout() {
        let requestUrl = this._serviceUrl + '/_logout';
        return this._requester.post(requestUrl);
    };
}
"use strict";

class MessageModel {
    constructor(requester) {
        this._requester = requester;
        this._serviceUrl = this._requester.baseUrl + '/appdata/' + this._requester.appId + '/products';
        this._userInfo = this._requester.baseUrl + '/user/' + this._requester.appId;
    }

    listShopItems() {
        return this._requester.get(this._serviceUrl);
    };

    listUserCart(userId) {
        let requestUrl = this._userInfo + '/' + userId;
        return this._requester.get(requestUrl);
    };

    updateUserCart(userId, userObj) {
        let requestUrl = this._userInfo + '/' + userId;
        return this._requester.put(requestUrl, userObj, false);
    };
}
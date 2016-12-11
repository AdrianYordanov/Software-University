"use strict";

class MessageModel {
    constructor(requester) {
        this._requester = requester;
        this._serviceUrl = this._requester.baseUrl + '/appdata/' + this._requester.appId + '/messages';
        this._allUsersUrl = this._requester.baseUrl + '/user/' + this._requester.appId;
    }

    listMessagesByRecipient(recipient) {
        let requestUrl = this._serviceUrl + '?query=' + JSON.stringify({recipient_username: recipient});
        return this._requester.get(requestUrl);
    };

    listMessagesBySender(sender) {
        let requestUrl = this._serviceUrl + '?query=' + JSON.stringify({sender_username: sender});
        return this._requester.get(requestUrl);
    };

    listAllUsers() {
        return this._requester.get(this._allUsersUrl);
    };

    sendMessage(message) {
        return this._requester.post(this._serviceUrl, message);
    }

    deleteMessage(messageId) {
        let requestUrl = this._serviceUrl + '/' + messageId;
        return this._requester.del(requestUrl);
    }
}
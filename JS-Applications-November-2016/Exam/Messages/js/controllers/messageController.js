"use strict";

class MessageController {
    constructor(model, view, notificationMessages) {
        this._model = model;
        this._view = view;
        this._notificationMessages = notificationMessages;
    }

    loadMyMessages(container) {
        let _this = this;

        this._model.listMessagesByRecipient(sessionStorage.getItem('username'))
            .then(
                function (data) {
                    data.forEach(message =>
                        message.date = _this._formatDate(message['_kmd']['lmt']));
                    data.forEach(message =>
                        message.formattedName = _this._formatSender(message['sender_name'], message['sender_username']));
                    _this._view.showMyMessages(container, data);
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    }

    loadSentMessages(container) {
        let _this = this;

        this._model.listMessagesBySender(sessionStorage.getItem('username'))
            .then(
                function (data) {
                    data.forEach(message =>
                        message.date = _this._formatDate(message['_kmd']['lmt']));
                    _this._view.showSentMessages(container, data);
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    }

    loadSendMessage(container) {
        let _this = this;

        this._model.listAllUsers()
            .then(
                function (data) {
                    data.forEach(user => user.formattedName = _this._formatSender(user['name'], user['username']));
                    _this._view.showSendMessage(container, data);
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    }

    sendMessage(message) {
        let _this = this;

        this._model.sendMessage(message)
            .then(
                function () {
                    _this._notificationMessages.showSuccessMessage('Message sent.');
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    }

    deleteMessage(messageId) {
        let _this = this;

        this._model.deleteMessage(messageId)
            .then(function () {
                Sammy(function () {
                    this.trigger('loadUrl', {url: '#/sent-messages'});
                });
                _this._notificationMessages.showSuccessMessage('Message deleted.');
            })
            .catch(function (error) {
                _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
            })
    }

    _formatDate(dateISO8601) {
        let date = new Date(dateISO8601);
        if (Number.isNaN(date.getDate()))
            return '';
        return date.getDate() + '.' + padZeros(date.getMonth() + 1) +
            "." + date.getFullYear() + ' ' + date.getHours() + ':' +
            padZeros(date.getMinutes()) + ':' + padZeros(date.getSeconds());

        function padZeros(num) {
            return ('0' + num).slice(-2);
        }
    }

    _formatSender(name, username) {
        if (!name)
            return username;
        else
            return username + ' (' + name + ')';
    }
}
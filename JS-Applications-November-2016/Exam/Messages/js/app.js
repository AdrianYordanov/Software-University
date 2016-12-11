"use strict";

function startApp () {
    let appId = 'kid_By8NbFcQg',
        appSecret = '75f07279423746aca0ff6d0781e36137',
        baseUrl = 'https://baas.kinvey.com';

    let menu = '#menu';
    let container = 'main';
    let notificationMessagesContainer = '#notificationMessages';

    let requester = new Requester(appId, appSecret, baseUrl);
    let notificationMessages = new NotificationMessages(notificationMessagesContainer);

    let userModel = new UserModel(requester);
    let userView = new UserView();
    let userController = new UserController(userModel, userView, notificationMessages);

    let messageModel = new MessageModel(requester);
    let messageView = new MessageView();
    let messageController = new MessageController(messageModel, messageView, notificationMessages);

    let router = Sammy(function () {
        this.before(/#\/(.*)/, function () {
            userController.loadMenu(menu);
        });

        this.get('#/', function () {
            userController.loadHomePage(container);
        });
        this.get('#/login', function () {
            userController.loadLoginPage(container);
        });
        this.get('#/register', function () {
            userController.loadRegisterPage(container);
        });
        this.get('#/logout', function () {
            this.trigger('onLogout');
        });

        this.get('#/my-messages', function () {
            messageController.loadMyMessages(container);
        });
        this.get('#/sent-messages', function () {
            messageController.loadSentMessages(container);
        });
        this.get('#/send-message', function () {
            messageController.loadSendMessage(container);
        });

        this.bind('loadUrl', function (e, data) {
            this.redirect(data.url);
        });
        this.bind('onLogin', function (e, data) {
            userController.userLogin(data);
        });
        this.bind('onRegister', function (e, data) {
            userController.userRegister(data);
        });
        this.bind('onLogout', function () {
            userController.userLogout();
        });

        this.bind('onSendMessage', function (e, data) {
            messageController.sendMessage(data);
        });
        this.bind('onDeleteMessage', function (e, data) {
            messageController.deleteMessage(data.messageId);
        })
    });

    router.run('#/');
}
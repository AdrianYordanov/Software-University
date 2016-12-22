"use strict";

function startApp () {
    let appId = 'kid_Bypyo-FNx',
        appSecret = '85bfea5616cc4fd2a96c5c222c0fbb2e',
        baseUrl = 'https://baas.kinvey.com';

    let menu = '#menu';
    let container = 'main';
    let notificationMessagesContainer = '#notificationMessages';

    let requester = new Requester(appId, appSecret, baseUrl);
    let notificationMessages = new NotificationMessages(notificationMessagesContainer);

    let userModel = new UserModel(requester);
    let userView = new UserView();
    let userController = new UserController(userModel, userView, notificationMessages);

    let shopModel = new MessageModel(requester);
    let shopView = new MessageView();
    let shopController = new MessageController(shopModel, shopView, notificationMessages);

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

        this.get('#/shop', function () {
            shopController.loadShopItems(container);
        });
        this.get('#/cart', function () {
            shopController.loadUserCart(container);
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

        this.bind('onPurchase', function (e, data) {
            shopController.purchaseItem(data.itemId, data.itemObj);
        });
        this.bind('onDiscard', function (e, data) {
            shopController.discardItem(data.itemId);
        });
    });

    router.run('#/');
}
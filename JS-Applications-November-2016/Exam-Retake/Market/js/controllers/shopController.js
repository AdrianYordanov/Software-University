"use strict";

class MessageController {
    constructor(model, view, notificationMessages) {
        this._model = model;
        this._view = view;
        this._notificationMessages = notificationMessages;
    }

    loadShopItems(container) {
        let _this = this;

        this._model.listShopItems()
            .then(
                function (data) {
                    for (let currentItem of data) {
                        currentItem['price'] = currentItem['price'].toFixed(2);
                    }
                    _this._view.showShopItems(container, data);
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    }

    loadUserCart(container, userId) {
        let _this = this;

        this._model.listUserCart(sessionStorage.getItem('userId'))
            .then(
                function (data) {
                    let cartCollection = [];

                    for (let key in data['cart']) {
                        let currentItem = data['cart'][key];
                        let quantity = Number(currentItem['quantity']);
                        let price = Number(currentItem['product']['price']);
                        let finalPrice = (quantity * price).toFixed(2);

                        cartCollection.push({
                            _id: key,
                            name: currentItem['product']['name'],
                            description: currentItem['product']['description'],
                            quantity: currentItem['quantity'],
                            price: finalPrice,
                        })
                    }
                    _this._view.showUserCart(container, cartCollection);
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            )
    }

    purchaseItem(itemId, itemProperties) {
        let _this = this;

        this._model.listUserCart(sessionStorage.getItem('userId'))
            .then(
                function (userObj) {
                    if (userObj['cart'].hasOwnProperty(itemId)) {
                        userObj['cart'][itemId]['quantity']++;
                    } else {
                        userObj['cart'][itemId] = {};
                        userObj['cart'][itemId]['quantity'] = 1;
                        userObj['cart'][itemId]['product'] = itemProperties;
                    }

                    _this._model.updateUserCart(sessionStorage.getItem('userId'), userObj)
                        .then(
                            function () {
                                Sammy(function () {
                                    this.trigger('loadUrl', {url: '#/shop'});
                                });
                                _this._notificationMessages.showSuccessMessage("Product purchased.");
                            }
                        )
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            );
    }

    discardItem(itemId) {
        let _this = this;

        this._model.listUserCart(sessionStorage.getItem('userId'))
            .then(
                function (userObj) {
                    delete userObj['cart'][itemId];
                    _this._model.updateUserCart(sessionStorage.getItem('userId'), userObj)
                        .then(
                            function () {
                                Sammy(function () {
                                    this.trigger('loadUrl', {url: '#/cart'});
                                });
                                _this._notificationMessages.showSuccessMessage("Product discarded.");
                            }
                        )
                }
            )
            .catch(
                function (error) {
                    _this._notificationMessages.showErrorMessage("Error: " + error['responseJSON']['description']);
                }
            );
    }
}
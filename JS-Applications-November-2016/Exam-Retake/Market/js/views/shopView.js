"use strict";

class MessageView {
    constructor() {
    }

    showShopItems(container, shopItems) {
        $.get('templates/shop.html', function (templ) {
            let rendered = Mustache.render(templ, {shopItems: shopItems});
            $(container).html(rendered);

            $('td button').on('click', function () {
                let row = $(this).parent().parent();
                let itemId = row.attr('id');

                let itemObj = {
                    name: row.find(':nth-child(1)').text(),
                    description: row.find(':nth-child(2)').text(),
                    price: Number(row.find(':nth-child(3)').text())
                };

                Sammy(function () {
                    this.trigger('onPurchase', {itemId: itemId, itemObj: itemObj});
                })
            });
        });
    }

    showUserCart(container, cart) {
        $.get('templates/cart.html', function (templ) {
            let rendered = Mustache.render(templ, {cart: cart});
            $(container).html(rendered);

            $('td button').on('click', function () {
                let row = $(this).parent().parent();
                let itemId = row.attr('id');

                Sammy(function () {
                    this.trigger('onDiscard', {itemId: itemId});
                })
            });
        });
    }
}
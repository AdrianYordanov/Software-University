"use strict";

class MessageView {
    constructor() {
    }

    showMyMessages(container, messages) {
        $.get('templates/my-messages.html', function (templ) {
            let rendered = Mustache.render(templ, {messages: messages});
            $(container).html(rendered);
        });
    }

    showSentMessages(container, messages) {
        $.get('templates/sent-messages.html', function (templ) {
            let rendered = Mustache.render(templ, {messages: messages});
            $(container).html(rendered);

            $('td button').on('click', function () {
                let row = $(this).parent().parent();
                let id = row.attr('id');

                debugger;

                Sammy(function () {
                    this.trigger('onDeleteMessage', {messageId: id});
                })
            });
        });
    }

    showSendMessage(container, users) {
        $.get('templates/send-message.html', function (templ) {
            let rendered = Mustache.render(templ, {users: users});
            $(container).html(rendered);

            $('form').on('submit', function (e) {
                let message = {
                    sender_username: sessionStorage.getItem('username'),
                    sender_name: sessionStorage.getItem('name'),
                    recipient_username: $('select option:selected').val(),
                    text: $('#msgText').val()
                };
                Sammy(function () {
                    this.trigger('onSendMessage', message);
                });

                return false;
            });
        });
    }
}
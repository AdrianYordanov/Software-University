"use strict";

class NotificationMessages {
    constructor(container) {
        this._containerId = container;
        this._container = $(this._containerId);

        $(document).on({
            ajaxStart: () => {
                this._container.find('#loadingBox').show();
            },
            ajaxStop: () => {
                this._container.find('#loadingBox').hide();
            }
        })
    }

    showSuccessMessage(message) {
        let _this = this;

        $.get('templates/info-box.html', function (templ) {
            let rendered = Mustache.render(templ, {message: message});
            let renderedObject = $(rendered);
            _this._container.append(renderedObject);

            renderedObject.on('click', function () {
                $(this).remove();
            });

            setTimeout(function () {
                renderedObject.remove();
            }, 3000);
        })
    }

    showErrorMessage(message) {
        let _this = this;

        $.get('templates/error-box.html', function (templ) {
            let rendered = Mustache.render(templ, {message: message});
            let renderedObject = $(rendered);
            _this._container.append(renderedObject);

            renderedObject.on('click', function () {
                $(this).remove();
            });
        })
    }
}
var app = app || {};

app.requester = (function () {
    function Requester(appId, appSecret, baseUrl) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = baseUrl;
    }

    Requester.prototype.get = function (url, useAppCredentials) {
        var headers = getHeaders.call(this, null, useAppCredentials);
        return makeRequest('GET', url, headers, null);
    };

    Requester.prototype.put = function (url, data, useAppCredentials) {
        var headers = getHeaders.call(this, data, useAppCredentials);
        return makeRequest('PUT', url, headers, data);
    };

    Requester.prototype.post = function (url, data, useAppCredentials) {
        var headers = getHeaders.call(this, data, useAppCredentials);
        return makeRequest('POST', url, headers, data);
    };

    Requester.prototype.delete = function (url, useAppCredentials) {
        var headers = getHeaders.call(this, null, useAppCredentials);
        return makeRequest('DELETE', url, headers, null);
    };

    function getHeaders(JSON, useAppCredentials) {
        var headers = {};
        var token;

        if(JSON) {
            headers['Content-Type'] = 'application/json';
        }

        if(useAppCredentials) {
            token = this.appId + ':' + this.appSecret;
            headers['Authorization'] = 'Basic ' + btoa(token);
        } else {
            token = sessionStorage['userSession'];
            headers['Authorization'] = 'Kinvey ' + token;
        }

        return headers;
    }

    function makeRequest(method, url, headers, data) {
        var defer = Q.defer();
        var options = {
            method: method,
            url: url,
            headers: headers,
            data: JSON.stringify(data) || null,
            success: function (data) {
                defer.resolve(data);
            },
            error: function (error) {
                defer.reject(error)
            }
        };

        $.ajax(options);
        return defer.promise;
    }

    return {
        config: function (appId, appSecret, baseUrl) {
            return new Requester(appId, appSecret, baseUrl)
        }
    }
})();
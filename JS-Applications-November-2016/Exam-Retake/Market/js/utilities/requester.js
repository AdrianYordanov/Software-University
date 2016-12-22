"use strict";

class Requester {
    constructor(appId, appSecret, baseUrl) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = baseUrl;
    }

    get(url) {
        return this._makeRequest('GET', url);
    };

    put(url, data) {
        return this._makeRequest('PUT', url, data);
    };

    post(url, data) {
        return this._makeRequest('POST', url, data);
    };

    del(url) {
        return this._makeRequest('DELETE', url);
    };

    _makeRequest(method, url, data) {
        let headers = {};

        let objectRequest = {
            method: method,
            headers: headers,
            url: url
        };

        if (sessionStorage.getItem('userSession')) {
            headers['Authorization'] = 'Kinvey ' + sessionStorage.getItem('userSession');
        } else {
            let token = this.appId + ':' + this.appSecret;
            headers['Authorization'] = 'Basic ' + btoa(token);
        }

        if (data) {
            objectRequest["data"] = JSON.stringify(data);
            objectRequest["contentType"] = "application/json"
        }


        return $.ajax(objectRequest);
    }
}
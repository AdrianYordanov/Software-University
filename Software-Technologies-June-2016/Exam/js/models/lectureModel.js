var app = app || {};

app.lectureModel = (function () {
    function LectureModel(requester) {
        this.requester = requester;
        this.serviceUrl = this.requester.baseUrl + '/appdata/' + this.requester.appId + '/lectures/';
    }

    LectureModel.prototype.getLectureById = function (id) {
        var requestUrl = this.serviceUrl + '?query={"_id":"' + id + '"}';
        return this.requester.get(requestUrl, false);
    };
    
    LectureModel.prototype.listAllLectures = function () {
        return this.requester.get(this.serviceUrl, false);
    };

    LectureModel.prototype.listMyLectures = function () {
        var requestUrl = this.serviceUrl + '?query={"_acl.creator":"' + sessionStorage['userId'] + '"}';
        return this.requester.get(requestUrl, false);
    };

    LectureModel.prototype.addLecture = function (lecture) {
        return this.requester.post(this.serviceUrl, lecture, false);
    };
    
    LectureModel.prototype.editLecture = function (lecutre) {
        var requestUrl = this.serviceUrl + lecutre._id;
        return this.requester.put(requestUrl, lecutre, false);
    };
    
    LectureModel.prototype.deleteLecture = function (lecture) {
        var requestUrl = this.serviceUrl + lecture._id;
        return this.requester.delete(requestUrl, false);
    };

    return {
        config: function (requester) {
            return new LectureModel(requester);
        }
    }
})();
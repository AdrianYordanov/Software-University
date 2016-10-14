var app = app || {};

app.lectureController = (function () {
    function LectureController(model) {
        this.model = model;
    }

    LectureController.prototype.displayAllLectures = function (container) {
        this.model.listAllLectures()
            .then(
                function (collection) {
                    var allLectures = lecturesBinding(collection);
                    app.lectureViews.bag.showAllLecturesPage(container, allLectures);
                },
                function (error) {
                    app.userViews.bag.showErrorMessage(error.message);
                }
            );
    };
    
    LectureController.prototype.displayMyLectures = function (container) {
        this.model.listMyLectures()
            .then(
                function (collection) {
                    var myLectures = lecturesBinding(collection);
                    app.lectureViews.bag.showMyLecturesPage(container, myLectures);
                },
                function (error) {
                    app.userViews.bag.showErrorMessage(error.responseJSON.description);
                }
            );
    };
    
    LectureController.prototype.displayAddLecture = function (container) {
        app.lectureViews.bag.showAddLecturePage(container);
    };

    LectureController.prototype.displayEditLecture = function (container, lectureId) {
        this.model.getLectureById(lectureId)
            .then(
                function (collection) {
                    var lecture = collection[0];
                    app.lectureViews.bag.showEditLecturePage(container, lecture);
                },
                function (error) {
                    console.log(error);
                }
            )
    };

    LectureController.prototype.displayDeleteLecture = function (container, lectureId) {
        this.model.getLectureById(lectureId)
            .then(
                function (collection) {
                    var lecture = collection[0];
                    app.lectureViews.bag.showDeleteLecturePage(container, lecture);
                },
                function (error) {
                    console.log(error);
                }
            )
    };
    
    LectureController.prototype.addLecture = function (lecture) {
        this.model.addLecture(lecture)
            .then(
                function () {
                    Sammy(function () {
                        this.trigger('loadUrl', {url: '#/calendar/my/'})
                        app.userViews.bag.showSuccessMessage('Added lecture successful!');
                    })
                },
                function (error) {
                    app.userViews.bag.showErrorMessage(error.responseJSON.description);
                }
            )
    };

    LectureController.prototype.editLecture = function (lecture) {
        this.model.editLecture(lecture)
            .then(
                function () {
                    Sammy(function () {
                        this.trigger('loadUrl', {url: '#/calendar/my/'})
                        app.userViews.bag.showSuccessMessage('Editted lecture successful!');
                    })
                },
                function (error) {
                    app.userViews.bag.showErrorMessage(error.responseJSON.description);
                }
            )
    };

    LectureController.prototype.deleteLecture = function (lecture) {
        this.model.deleteLecture(lecture)
            .then(
                function () {
                    Sammy(function () {
                        this.trigger('loadUrl', {url: '#/calendar/my/'})
                        app.userViews.bag.showSuccessMessage('Deleted lecture successful!');
                    })
                },
                function (error) {
                    app.userViews.bag.showErrorMessage(error.responseJSON.description);
                }
            )
    };

    function lecturesBinding(lectures) {
        var collection = [];
        
        lectures.forEach(function (element) {
            var lecture = {
                _id: element._id,
                title: element.title,
                start: element.start,
                end: element.end,
                lecturer: element.lecturer
            };
            collection.push(lecture);
        });

        return collection;
    }

    return {
        config: function (model) {
            return new LectureController(model);
        }
    }
})();
var app = app || {};

(function () {
    var appId = 'kid_-kKxCmW3Z-',
        appSecret = '6a015b1ec557441ab5c04a60c95fd3e3',
        baseUrl = 'https://baas.kinvey.com';

    var requester = app.requester.config(appId, appSecret, baseUrl);

    var userModel = app.userModel.config(requester);
    var userController = app.userController.config(userModel);

    var lectureModel = app.lectureModel.config(requester);
    var lectureController = app.lectureController.config(lectureModel);

    var router = Sammy(function () {
        var menu = '#menu';
        var container = '#container';

        this.before(/#\/(.*)/, function () {
            userController.loadMenu(menu);
        });

        this.get('#/', function () {
            userController.loadHomePage(container);
        });
        this.get('#/login/', function () {
            userController.loadLoginPage(container);
        });
        this.get('#/register/', function () {
            userController.loadRegisterPage(container);
        });
        this.get('#/logout/', function () {
            this.trigger('onLogout');
        });
        this.get('#/calendar/list/', function () {
            lectureController.displayAllLectures(container);
        });
        this.get('#/calendar/my/', function () {
            lectureController.displayMyLectures(container);
        });
        this.get('#/calendar/add/', function () {
            lectureController.displayAddLecture(container);
        });
        this.get('#/calendar/edit/:lectureId', function () {
            var lectureId = this.params['lectureId'];
            lectureController.displayEditLecture(container, lectureId);
        });
        this.get('#/calendar/delete/:lectureId', function () {
            var lectureId = this.params['lectureId'];
            lectureController.displayDeleteLecture(container, lectureId);
        });
        this.notFound = function () {
            this.trigger('loadUrl', {url: '#/'});
        };

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
        this.bind('onAddLecture', function (e, data) {
            lectureController.addLecture(data);
        });
        this.bind('onEditLecture', function (e, data) {
            lectureController.editLecture(data);
        });
        this.bind('onDeleteLecture', function (e, data) {
            lectureController.deleteLecture(data);
        })
    });

    router.run('#/');
})();
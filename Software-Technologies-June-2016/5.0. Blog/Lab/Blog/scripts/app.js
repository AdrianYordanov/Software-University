(function () {

    // Create your own kinvey application

    let baseUrl = "https://baas.kinvey.com";
    let appKey = ""; // Place your appKey from Kinvey here...
    let appSecret = ""; // Place your appSecret from Kinvey here...
    var _guestCredentials = ""; // Create a guest user using PostMan/RESTClient/Fiddler and place his authtoken here...

    //Create AuthorizationService and Requester

    let selector = ".wrapper";
    let mainContentSelector = ".main-content";

    // Create HomeView, HomeController, UserView, UserController, PostView and PostController

    initEventServices();

    onRoute("#/", function () {
        // Check if user is logged in and if its not show the guest page, otherwise show the user page...
    });

    onRoute("#/post-:id", function () {
        // Create a redirect to one of the recent posts...
    });

    onRoute("#/login", function () {
        // Show the login page...
    });

    onRoute("#/register", function () {
        // Show the register page...
    });

    onRoute("#/logout", function () {
        // Logout the current user...
    });

    onRoute('#/posts/create', function () {
        // Show the new post page...
    });

    bindEventHandler('login', function (ev, data) {
        // Login the user...
    });

    bindEventHandler('register', function (ev, data) {
        // Register a new user...
    });

    bindEventHandler('createPost', function (ev, data) {
        // Create a new post...
    });

    run('#/');
})();

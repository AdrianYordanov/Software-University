class PostController {
    constructor(postView, requester, baseUrl, appKey) {
        this._postView = postView;
        this._requester = requester;
        this._baseServiceUrl = baseUrl + '/appdata/' + appKey + '/posts/';
        this._appKey = appKey;
    }

    showCreatePostPage(data, isLoggedIn) {
        this._postView.showCreatePostPage(data, isLoggedIn);
    }

    createPost(requestData) {
        if(requestData.title.length < 10) {
            showPopup('error', 'Post title must consist of at least 10 symbols.');
            return;
        }

        if(requestData.content.length < 50) {
            showPopup('error', 'Post content must consist of at least 50 symbols.');
        }

        let requestUrl = this._baseServiceUrl;

        this._requester.post(
            requestUrl,
            requestData,
            function success(data) {
                showPopup('success', 'You have successfully created post.');
                redirectUrl('#/');
            },
            function error(data) {
                showPopup('error', 'An error has occured while attempting to create new post.');
            }
        )
    }

}
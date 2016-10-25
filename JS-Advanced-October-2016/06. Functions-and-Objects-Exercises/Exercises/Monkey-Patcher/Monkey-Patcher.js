"use strict";

function monkeyPatcher(command) {
    let internalObject = this;
    let commands = {
        upvote: upvote,
        downvote: downvote,
        score: score
    };

    return commands[command]();

    function upvote() {
        ++internalObject['upvotes'];
    }

    function downvote() {
        ++internalObject['downvotes'];
    }

    function score() {
        let tempUpvote = internalObject['upvotes'];
        let tempDownvote = internalObject['downvotes'];
        let total = tempUpvote + tempDownvote;
        let score = tempUpvote - tempDownvote;

        let rating = 'new';
        let upvotePercent = tempUpvote * (100 / (total));

        if (total < 10) {
            rating = 'new';
        } else if (upvotePercent > 66) {
            rating = 'hot';
        } else if (score >= 0 && (tempUpvote > 100 || tempDownvote > 100)) {
            rating = 'controversial';
        } else if (score < 0) {
            rating = 'unpopular';
        }

        if (total > 50) {
            let biggerVote = Math.max(tempUpvote, tempDownvote);
            tempUpvote += Math.ceil(biggerVote / 100 * 25);
            tempDownvote += Math.ceil(biggerVote / 100 * 25);
        }

        return [tempUpvote, tempDownvote, score, rating];
    }
}

let obj = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

['upvote', 'downvote', 'score', 'downvote', 'score'].forEach(function (command) {
    let result = monkeyPatcher.call(obj, command);

    if (result) {
        console.log(result);
    }
});
"use strict";

function Posts() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likers, dislikers) {
            super(title, content);
            this.likers = likers;
            this.dislikers = dislikers;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = `${super.toString()}\nRating: ${this.likers - this.dislikers}`;

            if (this.comments.length > 0) {
                result += `\nComments:`;
                this.comments.forEach(comment => result += `\n * ${comment}`)
            }

            return result;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }

        view() {
            ++this.views;
            return this;
        }

        toString() {
            return `${super.toString()}\nViews: ${this.views}`;
        }
    }

    return {
        Post: Post,
        SocialMediaPost: SocialMediaPost,
        BlogPost: BlogPost
    }
}
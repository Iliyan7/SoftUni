function solve() {
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
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let str = super.toString();
            str += `\nRating: ${this.likes - this.dislikes}`;
            if(this.comments.length > 0) {
                str += `\nComments:`
                for (var comment of this.comments) {
                    str += `\n * ${comment}`;
                }
            }
           
            return str;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = Number(views);
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            let str = super.toString();
            str += `\nViews: ${this.views}`;
            return str;
        }
    }

    return {Post, SocialMediaPost, BlogPost};
}
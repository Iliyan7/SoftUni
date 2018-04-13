$(() => {
  const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs')

    this.get('index.html', handlers.home)
    this.get('#/home', handlers.home)
    this.post('#/login', handlers.loginPost)
    this.get('#/logout', handlers.logout)
    this.post('#/register', handlers.registerPost)
    this.get('#/catalog', handlers.catalog)
    this.get('#/create/post', handlers.createPost)
    this.post('#/create/post', handlers.createPostPost)
    this.get('#/edit/post/:postId', handlers.editPost)
    this.post('#/edit/post/:postId', handlers.editPostPost)
    this.get('#/delete/post/:postId', handlers.deletePost)
    this.get('#/posts', handlers.myPosts)
    this.get('#/details/:postId', handlers.details)
    this.post('#/create/comment/:postId', handlers.createCommentPost)
    this.get('#/delete/comment/:commentId/post/:postId', handlers.deleteComment)
  })

  app.run()
})

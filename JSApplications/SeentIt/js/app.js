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
  })

  app.run()
})

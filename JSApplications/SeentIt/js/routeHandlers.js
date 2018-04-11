const handlers = {}

handlers.home = (context) => {
  if (!auth.isAuth()) {
    context.loadPartials({
      header: './templates/common/header.hbs',
      footer: './templates/common/footer.hbs',
      content: './templates/welcome-anonymous.hbs',
      loginForm: './templates/forms/loginForm.hbs',
      registerForm: './templates/forms/registerForm.hbs'
    }).then(function () {
      this.partial('./templates/content.hbs')
    })
  } else {
    context.redirect('#/catalog')
  }
}

handlers.loginPost = (context) => {
  let username = context.params.username
  let password = context.params.password

  if (!validate.username(username)) {
    notify.showError('Username should be at least 3 characters long and contain only english alphabet letters')
  } else if (!validate.password(password)) {
    notify.showError('Password should be at least 6 characters long and contain only english alphabet letters')
  } else {
    auth.login(username, password)
      .then(userData => {
        auth.saveSession(userData)
        notify.showInfo('Login successful.')
        context.redirect('#/catalog')
      })
      .catch(notify.handleError)
  }
}

handlers.logout = (context) => {
  auth.logout()
    .then(userData => {
      sessionStorage.clear()
      context.redirect('#/home')
    })
    .catch(notify.handleError)
}

handlers.registerPost = (context) => {
  let username = context.params.username
  let password = context.params.password
  let repeatPassword = context.params.repeatPass

  if (!validate.username(username)) {
    notify.showError('Username should be at least 3 characters long and contain only english alphabet letters')
  } else if (!validate.password(password)) {
    notify.showError('Password should be at least 6 characters long and contain only english alphabet letters')
  } else if (password !== repeatPassword) {
    notify.showError('Passwords should match')
  } else {
    auth.register(username, password)
      .then(userData => {
        auth.saveSession(userData)
        notify.showInfo('User registration successful')
        context.redirect('#/catalog')
      })
      .catch(notify.handleError)
  }
}

handlers.catalog = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }
  posts.getAllPosts()
    .then(posts => {
      $.each(posts, (index, post) => {
        post.rank = index + 1
        post.timeCreated = calcTime(post._kmd.ect)
        post.isAuthor = post.author === sessionStorage.getItem('username')
      })

      attachUserData(context)
      context.posts = posts

      context.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        navbar: './templates/common/navbar.hbs',
        content: './templates/posts/catalogPage.hbs',
        postList: './templates/posts/postList.hbs',
        post: './templates/posts/post.hbs'
      }).then(function () {
        this.partial('./templates/content.hbs')
      })
    })
    .catch(notify.handleError)

  function calcTime (dateIsoFormat) {
    let diff = new Date() - (new Date(dateIsoFormat))
    diff = Math.floor(diff / 60000)
    if (diff < 1) return 'less than a minute'
    if (diff < 60) return diff + ' minute' + pluralize(diff)
    diff = Math.floor(diff / 60)
    if (diff < 24) return diff + ' hour' + pluralize(diff)
    diff = Math.floor(diff / 24)
    if (diff < 30) return diff + ' day' + pluralize(diff)
    diff = Math.floor(diff / 30)
    if (diff < 12) return diff + ' month' + pluralize(diff)
    diff = Math.floor(diff / 12)
    return diff + ' year' + pluralize(diff)
    function pluralize (value) {
      if (value !== 1) return 's'
      else return ''
    }
  }
}

handlers.createPost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  attachUserData(context)

  context.loadPartials({
    header: './templates/common/header.hbs',
    footer: './templates/common/footer.hbs',
    navbar: './templates/common/navbar.hbs',
    content: './templates/posts/createPostPage.hbs'
  }).then(function () {
    this.partial('./templates/content.hbs')
  })
}

handlers.createPostPost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let author = sessionStorage.getItem('username')
  let {url, imageUrl, title, description} = context.params

  if (url === '') {
    notify.showError('Link URL is required!')
  } else if (!url.startsWith('http')) {
    notify.showError('Link URL must be a valid link!')
  } else if (title === '') {
    notify.showError('Link Title is required!')
  } else {
    posts.createPost(author, title, description, url, imageUrl)
      .then(res => {
        notify.showInfo('Post created.')
        context.redirect('#/catalog')
      })
      .catch(notify.handleError)
  }
}

function attachUserData (context) {
  context.isAuth = auth.isAuth()
  context.username = sessionStorage.getItem('username')
}

const handlers = {}

handlers.mainHbsFile = './templates/content.hbs'

handlers.home = (context) => {
  if (!auth.isAuth()) {
    context.loadPartials({
      header: './templates/common/header.hbs',
      footer: './templates/common/footer.hbs',
      content: './templates/welcome-anonymous.hbs',
      loginForm: './templates/forms/loginForm.hbs',
      registerForm: './templates/forms/registerForm.hbs'
    })
      .then(function () {
        this.partial(handlers.mainHbsFile)
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
        post.timeCreated = helper.calcTime(post._kmd.ect)
        post.isAuthor = post.author === sessionStorage.getItem('username')
      })

      helper.attachUserData(context)
      context.posts = posts

      context.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        navbar: './templates/common/navbar.hbs',
        content: './templates/posts/catalogPage.hbs',
        postList: './templates/posts/postList.hbs',
        post: './templates/posts/post.hbs'
      })
        .then(function () {
          this.partial(handlers.mainHbsFile)
        })
    })
    .catch(notify.handleError)
}

handlers.createPost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  helper.attachUserData(context)

  context.loadPartials({
    header: './templates/common/header.hbs',
    footer: './templates/common/footer.hbs',
    navbar: './templates/common/navbar.hbs',
    content: './templates/posts/createPostPage.hbs'
  })
    .then(function () {
      this.partial(handlers.mainHbsFile)
    })
}

handlers.createPostPost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let author = sessionStorage.getItem('username')
  let {url, imageUrl, title, description} = context.params

  if (validate.post(url, title)) {
    posts.createPost(author, title, description, url, imageUrl)
      .then(res => {
        notify.showInfo('Post created.')
        context.redirect('#/catalog')
      })
      .catch(notify.handleError)
  }
}

handlers.editPost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let postId = context.params.postId

  posts.getPostById(postId)
    .then(post => {
      helper.attachUserData(context)
      context.post = post
      console.log(post)

      context.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        navbar: './templates/common/navbar.hbs',
        content: './templates/posts/editPostPage.hbs'
      })
        .then(function () {
          this.partial(handlers.mainHbsFile)
        })
    })
    .catch(notify.handleError)
}

handlers.editPostPost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let author = sessionStorage.getItem('username')
  let { postId, url, imageUrl, title, description } = context.params

  if (validate.post(url, title)) {
    posts.editPost(postId, author, title, description, url, imageUrl)
      .then(() => {
        notify.showInfo(`Post ${title} updated.`)
        context.redirect('#/catalog')
      })
      .catch(notify.handleError)
  }
}

handlers.deletePost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let postId = context.params.postId

  posts.deletePost(postId)
    .then(() => {
      notify.showInfo(`Post deleted.`)
      context.redirect('#/catalog')
    })
    .catch(notify.handleError)
}

handlers.myPosts = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  posts.getMyPosts(sessionStorage.getItem('username'))
    .then(posts => {
      $.each(posts, (index, post) => {
        post.rank = index + 1
        post.timeCreated = helper.calcTime(post._kmd.ect)
        post.isAuthor = post.author === sessionStorage.getItem('username')
      })

      helper.attachUserData(context)
      context.posts = posts

      context.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        navbar: './templates/common/navbar.hbs',
        content: './templates/posts/myPostsPage.hbs',
        postList: './templates/posts/postList.hbs',
        post: './templates/posts/post.hbs'
      })
        .then(function () {
          this.partial(handlers.mainHbsFile)
        })
    })
    .catch(notify.handleError)
}

handlers.details = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let postId = context.params.postId

  let postPromise = posts.getPostById(postId)
  let commentsPromise = comments.getCommentsByPostId(postId)
  Promise.all([postPromise, commentsPromise])
    .then(([post, comments]) => {
      post.timeCreated = helper.calcTime(post._kmd.ect)
      post.isAuthor = post.author === sessionStorage.getItem('username')

      $.each(comments, (index, comment) => {
        comment.timeCreated = helper.calcTime(comment._kmd.ect)
        comment.isAuthor = comment.author === sessionStorage.getItem('username')
      })

      helper.attachUserData(context)
      context.post = post
      context.comments = comments

      context.loadPartials({
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        navbar: './templates/common/navbar.hbs',
        content: './templates/details/postDetailsPage.hbs',
        postDetails: './templates/details/postDetails.hbs',
        comment: './templates/details/comment.hbs'
      })
        .then(function () {
          this.partial(handlers.mainHbsFile)
        })
    })
    .catch(notify.handleError)
}

handlers.createCommentPost = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let postId = context.params.postId
  let content = context.params.content
  let author = sessionStorage.getItem('username')

  if (content === '') {
    notify.showError('Comment cannot be empty!')
  } else {
    comments.createComment(postId, content, author)
      .then(() => {
        notify.showInfo('Comment created.')
        context.redirect(`#/details/${postId}`)
      })
      .catch(notify.handleError)
  }
}

handlers.deleteComment = (context) => {
  if (!auth.isAuth()) {
    context.redirect('#/home')
    return
  }

  let commentId = context.params.commentId
  let postId = context.params.postId

  comments.deleteComment(commentId)
    .then(() => {
      notify.showInfo('Comment deleted.')
      context.redirect(`#/details/${postId}`)
    })
    .catch(notify.handleError)
}

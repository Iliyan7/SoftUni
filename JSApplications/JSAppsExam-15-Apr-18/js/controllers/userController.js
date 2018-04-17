const userController = {}

userController.registerUser = (context) => {
  let username = context.params['username-register']
  let password = context.params['password-register']
  let repeatPassword = context.params['password-register-check']

  if (!validator.validateUsername(username)) {
    notify.showError('Username should be at least 5 characters long.')
  } else if (!validator.validatePassword(password)) {
    notify.showError("Password shouldn't be empty.")
  } else if (!validator.passwordsMatch(password, repeatPassword)) {
    notify.showError('Passwords should match.')
  } else {
    user.register(username, password)
      .then(userData => {
        user.saveSession(userData)
        notify.showInfo('User registration successful.')
        context.redirect('#/editor')
      })
      .catch(notify.handleError)
  }
}

userController.loginUser = (context) => {
  let username = context.params['username-login']
  let password = context.params['password-login']

  if (!validator.validateUsername(username)) {
    notify.showError('Username should be at least 5 characters long.')
  } else if (!validator.validatePassword(password)) {
    notify.showError("Password shouldn't be empty.")
  } else {
    user.login(username, password)
      .then(userData => {
        user.saveSession(userData)
        notify.showInfo('Login successful.')
        context.redirect('#/editor')
      })
      .catch(notify.handleError)
  }
}

userController.logoutUser = (context) => {
  user.logout()
    .then(userData => {
      user.clearSession(userData)
      notify.showInfo('Logout successful.')
      context.redirect('#/editor')
    })
    .catch(notify.handleError)
}

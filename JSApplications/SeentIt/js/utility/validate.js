let validate = (() => {
  function username (val) {
    return RegExp('^[a-zA-Z]{3,}$').test(val)
  }

  function password (val) {
    return RegExp('^[a-zA-Z0-9]{6,}$').test(val)
  }

  function post (url, title) {
    if (url === '') {
      notify.showError('Link URL is required!')
    } else if (!url.startsWith('http')) {
      notify.showError('Link URL must be a valid link!')
    } else if (title === '') {
      notify.showError('Link Title is required!')
    } else {
      return true
    }

    return false
  }

  return {
    username,
    password,
    post
  }
})()

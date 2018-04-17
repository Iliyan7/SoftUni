let user = (() => {
  const module = 'user'

  function isAuth () {
    return window.sessionStorage.getItem('authtoken') !== null
  }

  function saveSession (userData) {
    window.sessionStorage.setItem('userId', userData._id)
    window.sessionStorage.setItem('username', userData.username)
    window.sessionStorage.setItem('authtoken', userData._kmd.authtoken)
  }

  function getUserId () {
    return window.sessionStorage.getItem('userId')
  }

  function getUsername () {
    return window.sessionStorage.getItem('username')
  }

  function getAuthToken () {
    return window.sessionStorage.getItem('authtoken')
  }

  function clearSession (userData) {
    window.sessionStorage.clear()
  }

  function register (username, password) {
    let obj = { username, password }
    return remote.post(module, '', 'basic', obj)
  }

  function login (username, password) {
    let obj = { username, password }
    return remote.post(module, 'login', 'basic', obj)
  }

  function logout () {
    return remote.post(module, '_logout', 'kinvey')
  }

  return {
    isAuth,
    saveSession,
    clearSession,
    getUserId,
    getUsername,
    getAuthToken,
    register,
    login,
    logout
  }
})()

let validate = (() => {
  function username (val) {
    return RegExp('^[a-zA-Z]{3,}$').test(val)
  }

  function password (val) {
    return RegExp('^[a-zA-Z0-9]{6,}$').test(val)
  }

  return {
    username,
    password
  }
})()

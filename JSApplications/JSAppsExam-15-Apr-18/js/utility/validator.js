let validator = (() => {
  function validateUsername (username) {
    return username.length >= 5
  }

  function validatePassword (password) {
    return password !== ''
  }

  function passwordsMatch (pass, repeatPass) {
    return pass === repeatPass
  }

  function validateProductName (type) {
    return type !== ''
  }

  function validateProductQty (qty) {
    return qty !== 0 && isNumeric(qty)
  }

  function validateProductPrice (price) {
    return price !== 0 && isNumeric(price)
  }

  function isNumeric (num) {
    return !isNaN(num)
  }

  return {
    validateUsername,
    validatePassword,
    passwordsMatch,
    validateProductName,
    validateProductQty,
    validateProductPrice
  }
})()

let service = (function () {
  const appKey = 'kid_rJVKFFccz'
  const appSecret = '20f783df602149f3964ab9243214afd4'
  const hostURL = 'https://baas.kinvey.com'
  const authHeaders = 'Kinvey ' + btoa(appKey + ':' + appSecret)
  
  function loginUser () {
    let username = $('input[name=username]').val()
    let password = $('input[name=passwd]').val()

    let headers = { 'Authorization': 'Basic ' + btoa(username + ':' + password) }
    ajaxRequest({ username, password }, headers, 'POST', `/user/${appKey}/login`)
      .then(user => {
        console.log(user)
      })
      .catch(handleAjaxError)
  }

  function logoutUser() {

  }

  function registerUser () {

  }

  function createAd () {

  }

  function editAd () {

  }

  function ajaxRequest (data, headers, method, url) {
    return $.ajax({
      data: data,
      headers: headers,
      method: method,
      url: hostURL + url
    })
  }

  function handleAjaxError (response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0) { errorMsg = 'Cannot connect due to network error.' }
    if (response.responseJSON && response.responseJSON.description) { errorMsg = response.responseJSON.description }
    showError(errorMsg)
  }

  function showError (errorMsg) {
    let errorBox = $('#errorBox')
    errorBox.text('Error: ' + errorMsg)
    errorBox.show()
  }

  return { loginUser, logoutUser, registerUser, createAd, editAd }
})()

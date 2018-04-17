let remote = (() => {
  const BASE_URL = 'https://baas.kinvey.com/'
  const APP_KEY = 'kid_S1BglClhG'
  const APP_SECRET = 'a22da9d67796433caacd4299570094b0'

  function makeAuth (auth) {
    if (auth === 'basic') {
      return `Basic ${window.btoa(APP_KEY + ':' + APP_SECRET)}`
    } else {
      return `Kinvey ${window.sessionStorage.getItem('authtoken')}`
    }
  }

  function makeRequest (method, module, endpoint, auth) {
    let req = {
      url: BASE_URL + module + '/' + APP_KEY + '/' + endpoint,
      method: method,
      headers: {
        'Authorization': makeAuth(auth),
		'Content-Type': 'application/json'
      }
    }

    return req
  }

  function get (module, endpoint, auth) {
    return $.ajax(makeRequest('GET', module, endpoint, auth))
  }

  function post (module, endpoint, auth, data) {
    let obj = makeRequest('POST', module, endpoint, auth)
    if (data) {
      obj.data = JSON.stringify(data)
    }
    return $.ajax(obj)
  }

  function update (module, endpoint, auth, data) {
    let obj = makeRequest('PUT', module, endpoint, auth)
    obj.data = JSON.stringify(data)
    return $.ajax(obj)
  }

  function remove (module, endpoint, auth) {
    return $.ajax(makeRequest('DELETE', module, endpoint, auth))
  }

  return {
    get,
    post,
    update,
    remove
  }
})()

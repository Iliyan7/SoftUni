function showHiddenLinks() {
  $('#linkHome').show()
  if (sessionStorage.getItem('authToken') === null) {
    $('#linkLogin').show()
    $('#linkRegister').show()
    $('#linkListAds').hide()
    $('#linkCreateAd').hide()
    $('#linkLogout').hide()
  } else {
    $('#linkLogin').hide()
    $('#linkRegister').hide()
    $('#linkListAds').show()
    $('#linkCreateAd').show()
    $('#linkLogout').show()
  }
}

function attachEvents () {
  $('#linkHome').on('click', showHomeView)
  $('#linkLogin').on('click', showLoginView)
  $('#linkRegister').on('click', showRegisterView)
  $('#linkListAds').on('click', showAdsView)
  $('#linkCreateAd').on('click', showCreateAdView)
  $('#linkLogout').on('click', service.logoutUser)

    $('#buttonLoginUser').on('click', service.loginUser)
    $('#buttonRegisterUser').on('click', service.registerUser)
    $('#buttonCreateAd').on('click', service.createAd)
    $('#buttonEditAd').on('click', service.editAd)
  // $("form").on('submit', function (event) { event.preventDefault() });
}

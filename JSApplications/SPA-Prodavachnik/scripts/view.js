function showSectionView (viewName) {
  $('main > section').hide()
  $('#' + viewName).show()
}

function showHomeView () {
  showSectionView('viewHome')
}

function showLoginView () {
  showSectionView('viewLogin')
  $('#formLogin').trigger('reset')
    let t = 0;
}

function showRegisterView () {
  showSectionView('viewRegister')
  $('#formRegister').trigger('reset')
}

function showAdsView () {
  showSectionView('viewAds')
}

function showCreateAdView () {
  showSectionView('viewCreateAd')
    $('#formRegister').trigger('reset')
}

function showEditAdView () {
  showSectionView('viewEditAd')
    $('#formRegister').trigger('reset')
}
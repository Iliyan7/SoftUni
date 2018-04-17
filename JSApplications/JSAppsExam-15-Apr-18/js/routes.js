$(document).on('change', (event) => {
  if (event.target.name === 'qty') {
    let qtyVal = Number(event.target.value)
    let priceVal = Number($('#price').val())
    updateFields(qtyVal, priceVal)
  }
  if (event.target.name === 'price') {
    let qtyVal = Number($('#qty').val())
    let priceVal = Number(event.target.value)
    updateFields(qtyVal, priceVal)
  }

  function updateFields (qtyVal, priceVal) {
    if (validator.validateProductQty(qtyVal) && validator.validateProductPrice(priceVal)) {
      let currentSubTotal = qtyVal * priceVal
      $('#currentSubTotal').text(currentSubTotal.toFixed(2))

      let total = 0
      $('.entrySubTotal').each(function () {
        total += Number($(this).text())
      })
      total += currentSubTotal
      $('#total').text(total.toFixed(2))
    }
  }
})

$(() => {
  const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs')

    this.get('/index.html', homeController.showHome)
    this.get('#/home', homeController.showHome)

    this.post('#/register', userController.registerUser)
    this.post('#/login', userController.loginUser)
    this.get('#/logout', userController.logoutUser)

    this.get('#/editor', receiptController.showReceiptEditor)
    this.post('#/receipt/commit', receiptController.commitReceipt)
    this.get('#/overview', receiptController.showAllReceipts)
    this.get('#/details/:receiptId', receiptController.showReceiptDetails)

    this.post('#/create/entry/:receiptId', entryController.createNewEntry)
    this.get('#/delete/entry/:entryId', entryController.deleteEntry)
  })

  app.run()
})

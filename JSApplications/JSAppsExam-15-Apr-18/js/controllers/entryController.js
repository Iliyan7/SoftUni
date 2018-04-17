let entryController = {}

entryController.createNewEntry = (context) => {
  if (!user.isAuth()) {
    context.redirect('#/home')
    return
  }

  let type = context.params.type
  let qty = Number(context.params.qty)
  let price = Number(context.params.price)
  let receiptId = context.params.receiptId

  if (!validator.validateProductName(type)) {
    notify.showError('Product name must be a non-empty')
  } else if (!validator.validateProductQty(qty)) {
    notify.showError('Quantity must be a number')
  } else if (!validator.validateProductPrice(price)) {
    notify.showError('Price must be a number')
  } else {
    entryService.addEntry(type, qty, price, receiptId)
      .then(entry => {
        notify.showInfo('Entry added.')
        context.redirect('#/editor')
      })
      .catch(notify.handleError)
  }
}

entryController.deleteEntry = (context) => {
  if (!user.isAuth()) {
    context.redirect('#/home')
    return
  }

  let entryId = context.params.entryId

  entryService.deleteEntry(entryId)
    .then(entry => {
      notify.showInfo('Entry deleted.')
      context.redirect('#/editor')
    })
    .catch(notify.handleError)
}

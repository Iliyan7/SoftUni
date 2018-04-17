let receiptController = {}

receiptController.showReceiptEditor = (context) => {
  if (!user.isAuth()) {
    context.redirect('#/home')
    return
  }

  receiptService.getActiveReceipt(user.getUserId())
    .then(receipt => {
      entryService.getEntriesByReceiptId(receipt._id)
        .then(entries => {
          $.each(entries, (index, entry) => {
            entry.subTotal = (entry.qty * entry.price).toFixed(2)

            receipt.productCount++
            receipt.total += Number(entry.subTotal)
          })

          attachUserName(context)
          receipt.total = receipt.total.toFixed(2)
          context.receipt = receipt
          context.entries = entries

          context.loadPartials({
            header: './templates/common/header.hbs',
            nav: './templates/common/nav.hbs',
            footer: './templates/common/footer.hbs',
            listActiveEntries: './templates/editor/listActiveEntries.hbs',
            entry: './templates/editor/entry.hbs'
          })
            .then(function () {
              this.partial('./templates/editor/editorPage.hbs')
            })
        })
        .catch(notify.handleError)
    })
    .catch(notify.handleError)
}

receiptController.commitReceipt = (context) => {
  if (!user.isAuth()) {
    context.redirect('#/home')
    return
  }

  let receiptId = context.params.receiptId
  let productCount = Number(context.params.productCount)
  let total = Number(context.params.total)

  if (productCount === 0) {
    notify.showError('You are not able checkout an empty receipt!')
  } else {
    receiptService.commitReceipt(receiptId, false, productCount, total)
      .then(receipt => {
        notify.showInfo('Receipt checked out.')
        context.redirect('#/editor')
      })
      .catch(notify.handleError)
  }
}

receiptController.showAllReceipts = (context) => {
  if (!user.isAuth()) {
    context.redirect('#/home')
    return
  }

  let userId = user.getUserId()
  receiptService.getMyReceipts(userId)
    .then(receipts => {
      context.grandTotal = 0
      $.each(receipts, (index, receipt) => {
        receipt.creationDate = new Date(receipt._kmd.ect)
        receipt.creationDate = receipt.creationDate.toDateString()
        receipt.total = receipt.total.toFixed(2)
        context.grandTotal += Number(receipt.total)
      })

      attachUserName(context)
      context.receipts = receipts

      context.loadPartials({
        header: './templates/common/header.hbs',
        nav: './templates/common/nav.hbs',
        footer: './templates/common/footer.hbs',
        receipt: '/templates/overview/receipt.hbs'
      })
        .then(function () {
          this.partial('./templates/overview/myReceiptsPage.hbs')
        })
    })
    .catch(notify.handleError)
}

receiptController.showReceiptDetails = (context) => {
  if (!user.isAuth()) {
    context.redirect('#/home')
    return
  }

  let receiptId = context.params.receiptId

  let receiptPromise = receiptService.receiptDetails(receiptId)
  let entriesPromise = entryService.getEntriesByReceiptId(receiptId)

  Promise.all([receiptPromise, entriesPromise])
    .then(([receipt, entries]) => {
      $.each(entries, (index, entry) => {
        entry.price = entry.price.toFixed(2)
        entry.totalPrice = (entry.qty * entry.price).toFixed(2)
      })

      attachUserName(context)
      context.entries = entries

      context.loadPartials({
        header: './templates/common/header.hbs',
        nav: './templates/common/nav.hbs',
        footer: './templates/common/footer.hbs',
        entry: '/templates/overview/entry.hbs'
      })
        .then(function () {
          this.partial('./templates/overview/detailsPage.hbs')
        })
    })
    .catch(notify.handleError)
}

function attachUserName (context) {
  context.username = window.sessionStorage.getItem('username')
}

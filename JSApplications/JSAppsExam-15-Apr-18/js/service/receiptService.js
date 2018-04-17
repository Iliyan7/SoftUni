let receiptService = (() => {
  const module = 'appdata'
  const authorization = 'Kinvey'

  function getActiveReceipt (userId) {
    const endpoint = `receipts?query={"_acl.creator":"${userId}","active":true}`

    return new Promise(function (resolve, reject) {
      remote.get(module, endpoint, authorization)
        .then(receipts => {
          if (receipts.length === 0) {
            createReceipt(true, 0, 0)
              .then(resolve)
              .catch(reject)
          } else {
            resolve(receipts[0])
          }
        })
        .catch(reject)
    })
  }

  function createReceipt (active, productCount, total) {
    let data = { active, productCount, total }

    return remote.post(module, 'receipts', authorization, data)
  }

  function getMyReceipts (userId) {
    let endpoint = `receipts?query={"_acl.creator":"${userId}","active":false}`

    return remote.get(module, endpoint, authorization)
  }

  function receiptDetails (receiptId) {
    let endpoint = `receipts/${receiptId}`

    return remote.get(module, endpoint, authorization)
  }

  function commitReceipt (receiptId, active, productCount, total) {
    let endpoint = `receipts/${receiptId}`
    let data = { active, productCount, total }

    return remote.update(module, endpoint, authorization, data)
  }

  return {
    getActiveReceipt,
    createReceipt,
    getMyReceipts,
    receiptDetails,
    commitReceipt
  }
})()

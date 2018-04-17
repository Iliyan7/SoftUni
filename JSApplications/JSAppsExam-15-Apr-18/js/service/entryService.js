let entryService = (() => {
  const module = 'appdata'
  const authorization = 'Kinvey'

  function getEntriesByReceiptId (receiptId) {
    const endpoint = `entries?query={"receiptId":"${receiptId}"}`

    return remote.get(module, endpoint, authorization)
  }

  function addEntry (type, qty, price, receiptId) {
    let data = {type, qty, price, receiptId}

    return remote.post(module, 'entries', authorization, data)
  }

  function deleteEntry (entryId) {
    let endpoint = `entries/${entryId}`

    return remote.remove(module, endpoint, authorization)
  }

  return {
    getEntriesByReceiptId,
    addEntry,
    deleteEntry
  }
})()

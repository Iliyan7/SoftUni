let comments = (() => {
  function getCommentsByPostId (postId) {
    const endpoint = `comments?query={"postId":"${postId}"}&sort={"_kmd.ect": -1}`

    return remote.get('appdata', endpoint, 'kinvey')
  }

  function createComment (postId, content, author) {
    let data = { postId, content, author }

    return remote.post('appdata', 'comments', 'kinvey', data)
  }

  function deleteComment (commentId) {
    const endpoint = `comments/${commentId}`

    return remote.remove('appdata', endpoint, 'kinvey')
  }

  return {
    getCommentsByPostId,
    createComment,
    deleteComment
  }
})()

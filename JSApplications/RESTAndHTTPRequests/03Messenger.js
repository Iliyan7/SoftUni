function attachEvents() {
    $('#submit').on('click', send);
    $('#refresh').on('click', refresh);

    const url = 'https://softuni-messenger-b9d50.firebaseio.com/.json';

    function send() {
        let author = $('#author');
        let content = $('#content');
        let postData = JSON.stringify({author: author.val(), content: content.val(), timestamp: Date.now()});

        $.post(url, postData)
            .then(refresh)
            .catch((err) => console.log(err));
    }

    function refresh() {
        $.get(url)
            .then(res => {
                let text = '';
                $.each(res, (id, message) => {
                    text += `${message.author}: ${message.content}\n`;
                });
                $('#messages').empty().text(text);
            })
            .catch((err) => console.log(err));
    }
}
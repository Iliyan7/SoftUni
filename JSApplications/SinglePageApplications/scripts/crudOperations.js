const BASE_URL = 'https://baas.kinvey.com/'
const APP_KEY = 'kid_Bkwf8svqz'
const APP_SECRET = 'f91b142f9a59480cb72bd1a09a5799d3'
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)}
const BOOKS_PER_PAGE = 10

function loginUser() {
    let username = $('#formLogin input[name=username]').val();
    let password = $('#formLogin input[name=passwd]').val();
    $.ajax({
        data: { username, password },
        headers: AUTH_HEADERS,
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/login',
    })
        .then(res => {
            signInUser(res, 'Login successful.')
        })
        .catch(handleAjaxError);
}

function registerUser() {
    let username = $('#formRegister input[name=username]').val();
    let password = $('#formRegister input[name=passwd]').val();
    $.ajax({
        data: {username, password},
        headers: AUTH_HEADERS,
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/',
    })
        .then(res => {
            signInUser(res, 'Registration successful.')
        })
        .catch(handleAjaxError);
}

function listBooks() {
    $.ajax({
        headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
    })
        .then(res => {
            showView('viewBooks');
            displayPaginationAndBooks(res.reverse());
        })
        .catch(handleAjaxError);
}

function createBook() {
    let title = $('#formCreateBook input[name=title]').val();
    let author = $('#formCreateBook input[name=author]').val();
    let description = $('#formCreateBook textarea[name=description]').val();
    $.ajax({
        data: {author, title, description},
        headers: { 'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken') },
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
    })
        .then(res => {
            listBooks();
            showInfo('Book created.');
        })
        .catch(handleAjaxError);
}

function deleteBook(book) {
    $.ajax({
        headers: { 'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken') },
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + book._id,
    })
    .then(res => {
        listBooks();
        showInfo('Book deleted.')
    })
    .catch(handleAjaxError);
}

function loadBookForEdit(book) {
    showView('viewEditBook');
    $('#formEditBook input[name=id]').val(book._id);    
    $('#formEditBook input[name=title]').val(book.title);
    $('#formEditBook input[name=author]').val(book.author);
    $('#formEditBook textarea[name=description]').val(book.description);
}

function editBook() {
    let id = $('#formEditBook input[name=id]').val();
    let title = $('#formEditBook input[name=title]').val();
    let author = $('#formEditBook input[name=author]').val();
    let description = $('#formEditBook textarea[name=description]').val();
    $.ajax({
        data: { title, author, description},
        headers: { 'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken') },
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + id,
    })
        .then(res => {
            listBooks();
            showInfo('Book edited.')
        })
        .catch(handleAjaxError);
}

function saveAuthInSession(userInfo) {
    // TODO
}

function logoutUser() {
    sessionStorage.clear();
    showHideMenuLinks();
    showHomeView();
    showInfo('Logout successful.')
}

function signInUser(res, message) {
    sessionStorage.setItem('id', res._id);
    sessionStorage.setItem('authToken', res._kmd.authtoken);
    sessionStorage.setItem('username', res.username);
    showHideMenuLinks();
    showHomeView();
    showInfo(message);
}

function displayPaginationAndBooks(books) {
    let pagination = $('#pagination-demo')
    if(pagination.data("twbs-pagination")){
        pagination.twbsPagination('destroy')
    }
    pagination.twbsPagination({
        totalPages: Math.ceil(books.length / BOOKS_PER_PAGE),
        visiblePages: 5,
        next: 'Next',
        prev: 'Prev',
        onPageClick: function (event, page) {
            $('#books > table tr:gt(0)').remove();
            let startBook = (page - 1) * BOOKS_PER_PAGE
            let endBook = Math.min(startBook + BOOKS_PER_PAGE, books.length)
            $(`a:contains(${page})`).addClass('active')
            for (let i = startBook; i < endBook; i++) {
                let tr = $('<tr>');
                tr.append($('<td>').text(books[i].title));
                tr.append($('<td>').text(books[i].author));
                tr.append($('<td>').text(books[i].description));
                if(books[i]._acl.creator == sessionStorage.getItem('id')) {
                    tr.append($('<td>')
                        .append($('<a>').prop('href', '#').text('[Delete]').on('click', deleteBook.bind(this, books[i])))
                        .append($('<a>').prop('href', '#').text('[Edit]').on('click', loadBookForEdit.bind(this, books[i])))
                    );
                }
                tr.appendTo('#books > table')
            }
        }
    })
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error."
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description
    showError(errorMsg)
}
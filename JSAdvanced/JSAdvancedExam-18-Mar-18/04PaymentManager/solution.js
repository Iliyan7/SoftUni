class PaymentManager {
    constructor(title) {
        this.title = title;
    }

    render(id) {
        let container = $(`#${id}`)[0];
        
        let table = $('<table>');
        $('<caption>').text(`${this.title} Payment Manager`).appendTo(table);
        let thead = $('<thead>').appendTo(table);
        let tr = $('<tr>').appendTo(thead);
        $('<th>').addClass('name').text('Name').appendTo(tr);
        $('<th>').addClass('category').text('Category').appendTo(tr);
        $('<th>').addClass('price').text('Price').appendTo(tr);
        $('<th>').text('Actions').appendTo(tr);
        let tbody = $('<tbody>').addClass('payments').appendTo(table);
        let tfoot = $('<tfoot>').addClass('input-data').appendTo(table);
        let trFoot = $('<tr>').appendTo(tfoot);
        let inputName = $('<input>').attr('name', 'name').attr('type', 'text');
        let inputCategory = $('<input>').attr('name', 'category').attr('type', 'text');
        let inputPrice = $('<input>').attr('name', 'price').attr('type', 'number');
        $('<td>').append(inputName).appendTo(trFoot);
        $('<td>').append(inputCategory).appendTo(trFoot);
        $('<td>').append(inputPrice).appendTo(trFoot);
        $('<td>').append($('<button>').text('Add').on('click', addToTable)).appendTo(trFoot);
        
        table.appendTo(container);
        console.log(container);

        function addToTable(params) {
            if (inputName.val() == '' || inputCategory.val() == '' || inputPrice.val() == '')
                return;

            let trBody = $('<tr>').appendTo(tbody);
            $('<td>').text(inputName.val()).appendTo(trBody);
            $('<td>').text(inputCategory.val()).appendTo(trBody);
            $('<td>').text(Number(inputPrice.val())).appendTo(trBody);
            $('<td>').append($('<button>').text('Delete').on('click', deleteFromTable)).appendTo(trBody);

            inputName.val('');
            inputCategory.val('');
            inputPrice.val('');

            function deleteFromTable(params) {
                trBody.remove();
            }
        }
    }
}
function solve(arr, sort) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    
    let tickets = [];

    for (let str of arr) {
        let [dest, price, status] = str.split('|');
        tickets.push(new Ticket(dest, price, status));
    }

    tickets.sort((a, b) => {
        if(sort == 'price'){
            return a[sort] - b[sort];
        }

        return a[sort].localeCompare(b[sort]);
    });

    return tickets;
}
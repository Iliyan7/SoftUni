class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.products = [];
    }

    set clientId(value) {
        if(value.length != 6 || isNaN(Number(value))) {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        this._clientId = value;
    }

    set email(value) {
        if (!RegExp('^[A-Za-z0-9]+@[A-Za-z\.]+$').test(value)) {
            throw new TypeError('Invalid e-mail');
        }

        this._email = value;
    }

    set firstName(value) {
        if (value.length < 3 || value.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        }

        if (!RegExp('^[A-Za-z]+$').test(value)) {
            throw new TypeError('First name must contain only Latin characters');
        }

        this._firstName = value;
    }

    set lastName(value) {
        if (value.length < 3 || value.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }

        if (!RegExp('^[A-Za-z]+$').test(value)) {
            throw new TypeError('Last name must contain only Latin characters');
        }

        this._lastName = value;
    }
}
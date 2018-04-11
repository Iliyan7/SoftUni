class PaymentProcessor {
    constructor(options) {
        this._options = { types: ["service", "product", "other"], precision: 2 };
        if(options != null) {
            if (options.hasOwnProperty('types')) {
                this._options.types = options.types;
            }

            if (options.hasOwnProperty('precision')) {
                this._options.precision = options.precision;
            }
        }
        this._payments = [];
    }

    registerPayment(id, name, type, value) {
        if (typeof id !== 'string') {
            throw new Error('ID must be a non-empty string');
        }
        if (id.length === 0) {
            throw new Error('ID must be a non-empty string');
        }

        if (typeof name !== 'string') {
            throw new Error('Name must be a non-empty string');
        }
        if (name.length === 0) {
            throw new Error('Name must be a non-empty string');
        }

        if (typeof value !== 'number') {
            throw new Error('Value must be a non-negative number');
        }

        if (!this._options.types.includes(type)) {
            throw new Error('invalid type');
        }

        if(this._payments.some(p => p.id == id)) {
            throw new Error('invalid ID');
        }

        this._payments.push({ id, name, type, value: Number(value.toFixed(this._options.precision))});
    }

    deletePayment(id) {
        if (!this._payments.some(p => p.id == id)) {
            throw new Error('ID not found');
        }

        let index = this._payments.findIndex(p => p.id == id);
        this._payments.splice(index, 1);
    }

    get(id) {
        if (!this._payments.some(p => p.id == id)) {
            throw new Error('ID not found');
        }

        let payment = this._payments.find(p => p.id == id);

        let output = `Details about payment ID: ${id}`;
        output += `\n- Name: ${payment.name}`;
        output += `\n- Type: ${payment.type}`;
        output += `\n- Value: ${payment.value}`;
        return output;
    }

    setOptions(options) {
        if(options == null) {
            this._options = { types: ["service", "product", "other"], precision: 2 };
            return;
        }

        if(options.hasOwnProperty('types')) {
            this._options.types = options.types;
        }

        if (options.hasOwnProperty('precision')) {
            this._options.precision = options.precision;
        }
    }

    toString() {
        let output = 'Summary:';
        output += `\n- Payments: ${this._payments.length}`;
        if (this._payments.length > 0) {
            output += `\n- Balance: ${this._payments.map((a) => a.value).reduce((a, b) => a + b)}`;
        }
        else {
            output += `\n- Balance: 0`;
        }
        
        return output;
    }
}



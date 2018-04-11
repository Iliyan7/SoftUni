class PaymentPackage {
    constructor(name, value) {
        this.name = name;
        this.value = value;
        this.VAT = 20;      // Default value    
        this.active = true; // Default value
    }

    get name() {
        return this._name;
    }

    set name(newValue) {
        if (typeof newValue !== 'string') {
            throw new Error('Name must be a non-empty string');
        }
        if (newValue.length === 0) {
            throw new Error('Name must be a non-empty string');
        }
        this._name = newValue;
    }

    get value() {
        return this._value;
    }

    set value(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('Value must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('Value must be a non-negative number');
        }
        this._value = newValue;
    }

    get VAT() {
        return this._VAT;
    }

    set VAT(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('VAT must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('VAT must be a non-negative number');
        }
        this._VAT = newValue;
    }

    get active() {
        return this._active;
    }

    set active(newValue) {
        if (typeof newValue !== 'boolean') {
            throw new Error('Active status must be a boolean');
        }
        this._active = newValue;
    }

    toString() {
        const output = [
            `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
            `- Value (excl. VAT): ${this.value}`,
            `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
        ];
        return output.join('\n');
    }
}

let expect = require('chai').expect;

describe("PaymentPackage Tests", function () {
    let pack;
    beforeEach(() => {
        pack = new PaymentPackage('HR Services', 1500);
    });

    it("expect to throw an error", function () {
        expect(new PaymentPackage('HR Services', 1500)).to.be.an.instanceOf(PaymentPackage);
    });

    it("expect to throw an error", function () {
        expect(() => new PaymentPackage(null, 1500)).to.throw('Name must be a non-empty string');
    });

    it("expect to throw an error", function () {
        expect(() => new PaymentPackage('HR Services')).to.throw('Value must be a non-negative number');
    });

    it("expect to throw an error", function () {
        expect(pack.value).to.equal(1500);
    });

    it("expect to throw an error", function () {
        expect(pack.VAT).to.equal(20);
    });

    it("expect to throw an error", function () {
        expect(pack.active).to.equal(true);
    });

    it("expect to throw an error", function () {
        expect(() => {
            pack.name = null;
        }).to.throw('Name must be a non-empty string');
    });

    it("expect to throw an error", function () {
        expect(() => {
            pack.value = null;
        }).to.throw('Value must be a non-negative number');
    });

    it("expect to throw an error", function () {
        expect(() => { 
            pack.VAT = -20;
        }).to.throw('VAT must be a non-negative number');
    });

    it("expect to throw an error", function () {
        expect(() => {
            pack.active = null;
        }).to.throw('Active status must be a boolean');
    });

    it("expect to throw an error", function () {
        expect(pack.active).to.equals(true);
    });

    it("Expect to be a ...", function () {
        expect(pack.toString()).to.equal('Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
    });

    it("Expect to be a ...", function () {
        pack.active = false;
        expect(pack.toString()).to.equal('Package: HR Services (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800');
    });
});


class Stringer {
    constructor(initialString, length) {
        this.initialString = initialString;
        this.length = Number(length);
    }

    get innerString() {
        return this.initialString;
    }

    get innerLength() {
        return this.length;
    }

    set innerLength(value) {
        this.length = Math.max(0, value);
    }

    increase(length) {
        this.innerLength = this.innerLength + length;
    }
    
    decrease(length) {
        this.innerLength = this.innerLength - length;
    }

    toString() {
        if (this.innerString.length > this.innerLength) {
            return this.innerString.substr(0, this.innerLength) + '...';
        }
        
        return this.innerString;
    }
}
class Textbox {
    constructor(selector, regex) {
        this._elements = $(selector);
        this.value = $(this._elements[0]).val();
        this.invalidSymbols = regex;

        this.elements.on('input', (event) => {
            let text = $(event.target).val();
            this.value = text;
        });
    }

    get value() {
        return this._value;
    }
    
    set value(val) {
        this._value = val;
        for (let element of this.elements) {
            $(element).val(val);
        }
    }

    get elements() {
        return this._elements;
    }

    isValid() {
        return !this.invalidSymbols.test(this._value);
    }
}
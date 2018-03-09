function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new TypeError('Abstract class cannot be instantiated directly');
            }
            this.weight = Number(weight);
            this.melonSort = melonSort;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = this.weight * this.melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let str = `Element: ${this.constructor.name.substr(0, this.constructor.name.length - 5)}`;
            str += `\nSort: ${this.melonSort}`;
            str += `\nElement Index: ${this.elementIndex}`
            return str;
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = this.weight * this.melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let str = `Element: ${this.constructor.name.substr(0, this.constructor.name.length - 5)}`;
            str += `\nSort: ${this.melonSort}`;
            str += `\nElement Index: ${this.elementIndex}`
            return str;
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = this.weight * this.melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let str = `Element: ${this.constructor.name.substr(0, this.constructor.name.length - 5)}`;
            str += `\nSort: ${this.melonSort}`;
            str += `\nElement Index: ${this.elementIndex}`
            return str;
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elementIndex = this.weight * this.melonSort.length;
        }

        get elementIndex() {
            return this._elementIndex;
        }

        toString() {
            let str = `Element: ${this.constructor.name.substr(0, this.constructor.name.length - 5)}`;
            str += `\nSort: ${this.melonSort}`;
            str += `\nElement Index: ${this.elementIndex}`
            return str;
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this._elements = ['Water', 'Fire', 'Earth', 'Air'];
        }

        morph() {
            let unshifted = this._elements.shift();
            this._elements.push(unshifted);
        }

        toString() {
            let str = `Element: ${this._elements[0]}`;
            str += `\nSort: ${this.melonSort}`;
            str += `\nElement Index: ${this.elementIndex}`
            return str;
        }
    }

    return {Melon, Watermelon, Firemelon, Earthmelon, Airmelon, Melolemonmelon};
}
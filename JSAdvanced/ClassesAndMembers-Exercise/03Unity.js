class Rat {
    constructor(name) {
        this.name = name;
        this.rats = [];
    }

    getRats() {
        return this.rats;
    }

    unite(otherRat) {
        if(otherRat.constructor.name == "Rat")
        {
            this.rats.push(otherRat);
        }
    }

    toString() {
        let result = `${this.name}`;
        this.rats.forEach(element => {
            result += `\n##${element}`
        });
        return result;
    }
}

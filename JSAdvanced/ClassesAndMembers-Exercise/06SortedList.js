class sortedList {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(elemnt) {
        this.size++;
        this.list.push(elemnt);
    }

    remove(index) {
        if (this.list[index] == undefined) {
            throw new RangeError();
        }

        this.size--;
        return this.list.sort((a, b) => a - b).splice(index, 1)[0];
    }

    get(index) {
        if (this.list[index] == undefined) {
            throw new RangeError();
        }

        return this.list.sort((a, b) => a - b)[index];
    }
}
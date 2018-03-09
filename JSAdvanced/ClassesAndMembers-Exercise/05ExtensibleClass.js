(function() {
    let id = 0;
    return class {
        constructor() {
            this.id = id++;
        }

        extend(templete) {
            for (const prop in templete) {
                if (typeof templete[prop] === 'function') {
                    Object.getPrototypeOf(this)[prop] = templete[prop]
                    
                }
                else {
                    this[prop] = templete[prop];
                }
            }
        }
    }
})();
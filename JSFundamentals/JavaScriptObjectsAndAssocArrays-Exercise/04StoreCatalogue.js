function solve(array) {
    let catalogue = new Map();
    let letters = new Set();
    for (let prodcut of array) {
        let [prodcutName, prodcutPrice] = prodcut.split(' : ');
        
        catalogue.set(prodcutName, prodcutPrice);
        letters.add(prodcutName[0]);
    }

    let sorted = new Map(Array.from(catalogue).sort());

    for (let letter of Array.from(letters.values()).sort()) {
        console.log(letter);
        for (let [key, value] of sorted) {
            if(key[0] == letter) {
                console.log(`  ${key}: ${value}`);
            }
        }
    }
}

let input = [
    'Appricot : 20.4',
    //'Fridge : 1500',
    //'TV : 1499',
    //'Deodorant : 10',
    //'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    //'T-Shirt : 10'   
]
solve(input);
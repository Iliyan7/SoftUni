function solve(array) {
    let bottles = new Map();
    let juices = new Map();
    for (let data of array) {
        let [juiceName, juiceQuantity] = data.split(' => ')
        juiceQuantity = Number(juiceQuantity);

        if(!juices.has(juiceName)) {
            juices.set(juiceName, 0)
            
        }

        juices.set(juiceName, juices.get(juiceName) + juiceQuantity);

        if(juices.get(juiceName) >= 1000)
        {
            let juiceQ = juices.get(juiceName);
            juices.set(juiceName, juiceQ % 1000);
            if(!bottles.has(juiceName)) {
                bottles.set(juiceName, 0)
            }

            bottles.set(juiceName, bottles.get(juiceName) + parseInt(juiceQ / 1000, 10));
        }
    }

    for (let [key, value] of bottles) {
        console.log(key + ' => ' + value);
    }
}

solve(['orange => 2000', 'Peach => 1432', 'Peach => 600']);
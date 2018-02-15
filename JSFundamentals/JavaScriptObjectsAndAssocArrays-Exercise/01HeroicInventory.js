function solve(args) {
    let data = [];
    for (let hero of args) {
        let [heroName, heroLevel, items] = hero.split(' / ');

        items = items != null ? items.split(', ') : [];

        data.push({
            name: heroName,
            level: Number(heroLevel),
            items: items
        });
    }
    return JSON.stringify(data);
}

let input = ['Isacc / 25', 'Hes / 1 / Desolator, Sentinel, Antara'];
console.log(solve(input));
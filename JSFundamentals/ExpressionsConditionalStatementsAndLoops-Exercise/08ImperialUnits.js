function solve(inches) {
    let feet = parseInt(inches / 12);
    inches %= 12;

    return `${feet}'-${inches}"`;
}

console.log(solve(11))
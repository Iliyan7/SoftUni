function solve(args) {
    let person = {};
    person[args[0]] = args[1];
    person[args[2]] = args[3];
    person[args[4]] = args[5];
    return person;
}

console.log(solve(['a', '1', 'b', '2', 'c', '3']))
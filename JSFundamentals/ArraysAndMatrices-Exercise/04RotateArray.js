function solve(args) {
    let n = Number(args.pop());
    let array = [];
    for (let i = 0; i < args.length; i++) {
        array[(i + n) % args.length] = args[i];
    }

    return array.join(' ');
}

console.log(solve([1,2,3,4,2]));
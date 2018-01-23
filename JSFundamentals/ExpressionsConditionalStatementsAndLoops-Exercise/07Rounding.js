function solve(args) {
    return Number(args[0].toFixed(Math.min(args[1], 15)))
}

console.log(solve([3.1, 4]))
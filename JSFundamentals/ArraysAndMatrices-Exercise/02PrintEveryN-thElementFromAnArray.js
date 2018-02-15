function solve(args) {
    let step = Number(args[args.length - 1]);
    args.pop();
    for (let i = 0; i < args.length; i += step) {
        console.log(args[i]);
    }
}
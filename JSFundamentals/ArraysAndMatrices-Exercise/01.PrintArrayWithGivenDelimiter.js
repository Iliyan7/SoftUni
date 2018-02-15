function solve(args) {
    let delimiter = args[args.length - 1]
    args.pop();
    console.log(args.join(delimiter));
}
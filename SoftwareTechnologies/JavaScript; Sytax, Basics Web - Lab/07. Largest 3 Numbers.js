function solve(args) {
    args = args.map(Number).sort((a, b) => b-a);

    for(let i=0; i<Math.min(args.length, 3); i++)
        console.log(args[i]);

}

//solve(['7', '11', '5', '2'])
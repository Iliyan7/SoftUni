function solve(args) {
    console.log(args.join(' ').split(/\W+/).filter(w => w.length != 0).filter(w => w == w.toUpperCase()).join(', '));
}

//solve(['PHP e typ', 'C# e mn QK']);
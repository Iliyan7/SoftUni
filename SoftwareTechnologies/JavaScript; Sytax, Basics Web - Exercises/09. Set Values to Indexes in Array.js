function solve(args) {
    let arr = new Array(Number(args[0]) + 1).join(0).split('');

    for(let i=1; i<args.length; i++) {
        let indexAndValue = args[i].split(" - ");
        arr[indexAndValue[0]] = indexAndValue[1];
}

    for(let i=0; i<arr.length; i++) {
        console.log(Number(arr[i]));
    }
}

//solve(['5', '0 - 5', '0 - 6', '0 - 7']);
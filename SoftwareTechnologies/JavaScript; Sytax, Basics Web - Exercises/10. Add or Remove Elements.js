function solve(args) {
    let arr = [];

    for(let i = 0; i < args.length; i++) {
        let commandAndArg = args[i].split(' ');
        let command = commandAndArg[0];
        let arg = commandAndArg[1];
        if(command == 'add') {
            arr.push(arg);
        } else if (command == 'remove') {
            arr.splice(arg, 1);
        }
    }

    for (let i = 0; i < arr.length; i++) {
        console.log(arr[i]);
    }
}

//solve(['add 3', 'add 5', 'remove 1', 'add 2']);
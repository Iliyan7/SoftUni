function solve(args) {
    let obj = {};
    for (let i = 0; i < args.length; i++) {
        args[i] = args[i].split(' -> ');

        if(args[i][0] == 'age' || args[i][0] == 'grade') {
            args[i][1] = parseInt(args[i][1]);
        }
        obj[args[i][0]] = args[i][1];
    }

    console.log(JSON.stringify(obj));
}

//solve(['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.00', 'date -> 23/05/1995', 'town -> Sofia']);
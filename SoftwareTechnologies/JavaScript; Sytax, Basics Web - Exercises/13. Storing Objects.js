function solve(args) {
    for (let i = 0; i < args.length; i++) {
        args[i] = args[i].split(' -> ');
        console.log(`Name: ${args[i][0]}`);
        console.log(`Age: ${args[i][1]}`);
        console.log(`Grade: ${args[i][2]}`);
    }
}

//solve(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90']);
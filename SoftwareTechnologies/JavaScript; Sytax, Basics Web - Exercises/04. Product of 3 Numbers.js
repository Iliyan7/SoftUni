function solve(args) {
    let count = 0;

    for(let i=0; i<args.length; i++) {
        let num = Number(args[i]);

        if(num == 0) {
            console.log("Positive");
            return;
        } else if(num < 0) {
            count++;
        }
    }

    if(count % 2 == 0) {
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}
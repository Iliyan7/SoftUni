function solve(args) {
    args.sort(function(a, b) {
        if(a.length > b.length) {
            return 1;
        }
        else if(a.length < b.length) {
            return -1;
        }
        
        if(a > b) {
            return 1;
        }
        else
        {
            return -1;
        }

        return 0;
    });

    console.log(args.join('\n'));
}

solve(['Alpha', 'Beta', 'Gamma']);
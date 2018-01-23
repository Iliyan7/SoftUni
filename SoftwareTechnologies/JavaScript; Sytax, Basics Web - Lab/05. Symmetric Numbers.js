function solve(args) {
    let n = Number(args[0]);

    let result = '';

    for(let i=1; i<=n; i++) {
        if(isSym(i))
            result += i + ' ';
    }

    console.log(result);

    function isSym(i) {
        let str = i.toString();
        let len = str.length;

        for(let i=0; i<len/2; i++) {
            if(str[i] != str[len - 1 - i])
                return false;
        }

        return true;
    }
}

//solve(['100']);
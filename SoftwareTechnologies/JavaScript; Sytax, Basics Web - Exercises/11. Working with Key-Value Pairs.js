function solve(args) {
    var arr = [];

    for (let i = 0; i < args.length - 1; i++) {
        let keyAndValue = args[i].split(' ');
        let obj = {};
        obj[keyAndValue[0]] = keyAndValue[1];
        arr.push(obj);
    }

    let key = args[args.length - 1];
    if(isKeyExist(key)) {
        console.log(searchValue(key));
    } else {
        console.log('None');
    }

    function isKeyExist(key) {
        for (let i = 0; i < arr.length; i++) {
            if(key in arr[i])
                return true
        }

        return false;
    }

    function searchValue(key) {
        let lastFound = "";

        for (let i = 0; i < arr.length; i++) {
            if(key in arr[i])
                lastFound = arr[i][key];
        }

        return lastFound;
    }
}

//solve(['3 bla', '2 alb', '2']);
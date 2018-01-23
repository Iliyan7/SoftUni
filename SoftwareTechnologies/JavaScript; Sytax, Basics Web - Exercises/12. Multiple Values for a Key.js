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
        let arrValues = searchValues(key);
        for (let i = 0; i < arrValues.length; i++) {
            console.log(arrValues[i]);
        }
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

    function searchValues(key) {
        let founded = [];

        for (let i = 0; i < arr.length; i++) {
            if(key in arr[i])
                founded.push(arr[i][key]);
        }

        return founded;
    }
}

//solve(['3 a', '2 b', '2 c', '2']);
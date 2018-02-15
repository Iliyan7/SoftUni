function solve(args) {
    let arr = [args[0]];
    for (let i = 1, j = 1; i < args.length; i++) {
        if(args[i] > arr[j - 1]) {
            arr[j++] = args[i];
        }
    }

    //args.filter(filterBiggest);
    return arr.join('\n');

    function filterBiggest(value, index, arr) {
        if(index == 0)
            return false;

        if(value > arr[index - 1]) {
            return true
        }

        return false;
    }
}

console.log(solve([20, 3, 8, 15]));
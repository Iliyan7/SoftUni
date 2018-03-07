function calcAggregates(arr) {
    function reduce(arr, func) {
        let result = arr[0];
        for (let element of arr.slice(1)) {
            result = func(result, element);
        }
        return result;
    }

    console.log("Sum = " + reduce(arr, (a, b) => Number(a) + Number(b)));
    console.log("Min = " + reduce(arr, (a, b) => Math.min(a, b)));
    console.log("Max = " + reduce(arr, (a, b) => Math.max(a, b)));
    console.log("Prodcut = " + reduce(arr, (a, b) => Number(a) * Number(b)));
    console.log("Join = " + reduce(arr, (a, b) => '' + a + b));
}

calcAggregates(['2', '3', '10', '5'])
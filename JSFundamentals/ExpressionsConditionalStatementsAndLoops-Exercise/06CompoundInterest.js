function solve(arr) {
    let p = arr[0];
    let i = arr[1] / 100;
    let n = 12 / arr[2];
    let t = arr[3];

    return p * Math.pow(1 + i / n, n * t);
}
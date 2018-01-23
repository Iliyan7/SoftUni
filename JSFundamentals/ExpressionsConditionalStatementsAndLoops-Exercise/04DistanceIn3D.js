function solve(arr) {
    let x1 = arr[0], y1 = arr[1], z1 = arr[2], x2 = arr[3], y2 = arr[4], z2 = arr[5];
    let dist = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2) + Math.pow(z1 - z2, 2));
    return dist;
}
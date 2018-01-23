function solve(n) {
    let degree = (n % 400) * 0.9;
    return degree < 0 ? degree + 360 : degree;
}
function solve(args) {
    let day = args[0];
    let month = args[1]; // - 1 < 0 ? 12 : args[1] - 1;
    let year = args[2];

    let date = new Date(year, month - 1, 0);
    return date.getDate();
}
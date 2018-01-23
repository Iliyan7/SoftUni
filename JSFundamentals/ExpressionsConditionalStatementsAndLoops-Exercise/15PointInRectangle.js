function solve(args) {
    let x = args[0];
    let y = args[1];
    let xMin = args[2];
    let xMax = args[3];
    let yMin = args[4];
    let yMax = args[5];

    let a = xMin <= x && x <= xMax;
    let b = yMin <= y && y <= yMax
    if(a && b)
    {
        return 'inside';
    }
    else
    {
        return 'outside';
    }
}

solve([12.5, -1, 2, 12, -3, 3])
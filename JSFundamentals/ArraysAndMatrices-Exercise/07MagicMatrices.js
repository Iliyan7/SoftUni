function solve(matrix) {
    var sum = matrix[0].reduce((a, b) => a + b);
    for (let i = 1; i < matrix.length; i++) {
        if(sum != matrix[i].reduce((a, b) => a + b)) {
            return false;
        }
    }

    let newSum = 0;
    for (let i = 0; i < matrix[0].length; i++) {
        for (let j = 0; j < matrix.length; j++) {
            newSum += matrix[j][i];
        }
        
        if(sum != newSum) {
            return false;
        }

        newSum = 0;
    }

    return true;
}

console.log(solve([[4, 5, 6], [6, 5, 4], [5, 5, 5]]))


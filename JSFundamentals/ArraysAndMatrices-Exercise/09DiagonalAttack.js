function solve(input) {
    let matrix = input.map(r => r.split(' ').map(Number))
    let [mainDiagonalSum, secondaryDiagonalSum] = getBothDiagonalsSum(matrix)
    if(mainDiagonalSum === secondaryDiagonalSum) {
        for(let row = 0; row < matrix.length; row++) {
            for(let col = 0; col < matrix[row].length; col++) {
                let temp = matrix[row][col]
                if (row !== col && col !== matrix[row].length - 1 - row) {
                    matrix[row][col] = mainDiagonalSum
                }

            }
        }
    }

    for(let row = 0; row < matrix.length; row++) {
        console.log(matrix[row].join(' '))
    }

    function getBothDiagonalsSum(matrix) {
        let mainDiagonalSum = 0
        let secondaryDiagonalSum = 0
        for(let row = 0; row < matrix.length; row++) {
            mainDiagonalSum += matrix[row][row]
            secondaryDiagonalSum += matrix[row][matrix[row].length - 1 - row]
        }

        return [mainDiagonalSum, secondaryDiagonalSum]
    }
}
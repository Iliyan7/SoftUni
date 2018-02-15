function solve(matrix, forces) {
    for (let i = 0; i < matrix.length; i++) {
        matrix[i] = matrix[i].split(' ').map(n => Number(n));
    }

    const matrixSize = 5;
    let action = {
        breeze: (index) => {
           for (let i = 0; i < matrixSize; i++) {
               matrix[index][i] = Math.max(0, matrix[index][i] - 15);
           }
        },
        gale: (index) => {
            for (let i = 0; i < matrixSize; i++) {
                matrix[i][index] = Math.max(0, matrix[i][index] - 20);
            }
        },
        smog: (value) => {
            for (let i = 0; i < matrixSize; i++) {
                for (let j = 0; j < matrixSize; j++) {
                    matrix[i][j] += value;
                }
            }
        }
    }

    for (let forceParams of forces) {
        let [force, param] = forceParams.split(' ');
        if(action[force]) {
            action[force](Number(param));
        }
    }
    
    let pollutedAreas = [];
    for (let i = 0; i < matrixSize; i++) {
        for (let j = 0; j < matrixSize; j++) {
            if(matrix[i][j] >= 50) {
                pollutedAreas.push(`[${i}-${j}]`);  
            }
        }
    }

    if(pollutedAreas.length > 0) {
        console.log('Polluted areas: ' + pollutedAreas.join(', '));
    }
    else {
        console.log('No polluted areas');
    }
}

let input1 = [
    "5 7 2 14 4",
    "21 14 2 5 3",
    "3 16 7 42 12",
    "2 20 8 39 14",
    "7 34 1 10 24",
];
let input2 = ["breeze 1", "gale 2", "smog 35"];
solve(input1, input2);
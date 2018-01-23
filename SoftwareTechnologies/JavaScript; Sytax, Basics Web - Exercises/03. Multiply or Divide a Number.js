function solve(args) {
    let num1 = Number(args[0]);
    let num2 = Number(args[1]);

    if(num2 >= num1) {
        console.log(num1 * num2);
    } else {
        console.log(num1 / num2);
    }

}
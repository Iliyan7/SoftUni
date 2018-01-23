function solve(args) {
let nums = args[0].split(' ').map(Number);

console.log(
    sum(nums[0], nums[1], nums[2]) ||
    sum(nums[1], nums[2], nums[0]) ||
    sum(nums[2], nums[0], nums[1]) ||
    'No'
);

function sum(num1, num2, num3) {
    if(num1 + num2 != num3) {
        return false;
    }

    if(num1 > num2) {
        [num1, num2] = [num2, num1];
    }

    return `${num1} + ${num2} = ${num3}`
}
}

//solve(['-5 -3 -2']);
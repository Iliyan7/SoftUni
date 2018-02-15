function solve(args) {
    let i = 1;
    let array = [];
    args.forEach(element => {
        if(element == "add") {
            array.push(i)
        }
        else if (element == "remove")
        {
            array.pop();
        }
        i++;
    });
    if(array.length == 0) {
        return "Empty";
    }
    else {
        return array.join('\n');
    }
    
}

let r = solve(["add", "add"]);
console.log(r);
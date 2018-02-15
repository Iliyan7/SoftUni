function solve(args) {
    let movieTitle = args[0].toLowerCase();
    let day = args[1].toLowerCase();

    if(movieTitle == "the godfather") {
        let prices = {
            "monday": 12,
            "tuesday": 10,
            "wednesday": 15,
            "thursday": 12.50,
            "friday": 15,
            "saturday": 25,
            "sunday": 30,
        }
        if(!prices.hasOwnProperty(day)) {
            return "error";
        }
        else {
            return prices[day];
        }
    } 
    else if (movieTitle == "schindler's list") {
        let prices = {
            "monday": 8.50,
            "tuesday": 8.50,
            "wednesday": 8.50,
            "thursday": 8.50,
            "friday": 8.50,
            "saturday": 15,
            "sunday": 15,
        }
        if(!prices.hasOwnProperty(day)) {
            return "error";
        }
        else {
            return prices[day];
        }
    } 
    else if (movieTitle == "casablanca") {
        let prices = {
            "monday": 8,
            "tuesday": 8,
            "wednesday": 8,
            "thursday": 8,
            "friday": 8,
            "saturday": 10,
            "sunday": 10,
        }
        if(!prices.hasOwnProperty(day)) {
            return "error";
        }
        else {
            return prices[day];
        }
    } 
    else if (movieTitle == "the wizard of oz") {
        let prices = {
            "monday": 10,
            "tuesday": 10,
            "wednesday": 10,
            "thursday": 10,
            "friday": 10,
            "saturday": 15,
            "sunday": 15,
        }
        if(!prices.hasOwnProperty(day)) {
            return "error";
        }
        else {
            return prices[day];
        }
    }
    else {
        return "error";
    }
}

let r = solve(["The Godfather", "Friday"]);
console.log(r);


function formatCurrency(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) {
        return symbol + ' ' + result;
    }
    else {
        return result + ' ' + symbol;
    }
}

function getDollarFormatter(formatCurrency) {
    return function(value) {
        return formatCurrency(',', '$', true, value)
    }
}

let formatter = getDollarFormatter(formatCurrency);
console.log(formatter(5345)); // $5345,00
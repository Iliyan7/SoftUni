function solve(params) {
    const bitcointExchangeRate = 11949.16;
    let totalBitcoins = 0, firstPurchasedBitcoin = 0, totalMoney = 0;
    for (let day = 1; day <= params.length; day++) {
        let diggedGold = Number(params[day-1]);

        if(day % 3 == 0) {
            diggedGold *= 0.7;
        }
        totalMoney += diggedGold * 67.51;

        if(totalMoney >= bitcointExchangeRate)
        {
            let boughtBitcoints = parseInt(totalMoney / bitcointExchangeRate);
            totalMoney-= boughtBitcoints * bitcointExchangeRate;
            totalBitcoins += boughtBitcoints;

            if(!firstPurchasedBitcoin) {
                firstPurchasedBitcoin = day;
            }
        }
    }

    console.log(`Bought bitcoins: ${totalBitcoins}`);
    if(firstPurchasedBitcoin != 0) {
        console.log(`Day of the first purchased bitcoin: ${firstPurchasedBitcoin}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}

let input = ['3124.15', '504.212', '2511.124'];
solve(input);
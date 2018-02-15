function solve(param1, param2) {
    let kingdoms = new Map();

    for (let obj of param1) {
        if(!kingdoms.has(obj.kingdom)) {
            kingdoms.set(obj.kingdom, new Map());
            kingdoms.get(obj.kingdom).set(obj.general, {army: obj.army, wins: 0, losses: 0});
        }
        else {
            if(!kingdoms.get(obj.kingdom).has(obj.general)){
                kingdoms.get(obj.kingdom).set(obj.general, {army: obj.army, wins: 0, losses: 0});
            }
            else {
                kingdoms.get(obj.kingdom).get(obj.general).army += obj.army;
            }
        }
    }

    for (let attackArgs of param2) {
        let [attackingKingdom, attackingGeneral, defendingKingdom, defendingGeneral] = attackArgs;

        if(kingdoms.get(attackingKingdom).has(attackingGeneral) && kingdoms.get(attackingKingdom).has(defendingGeneral)) {
            continue;
        }

        let attackingKingdomObj = kingdoms.get(attackingKingdom).get(attackingGeneral);
        let defendingKingdomObj = kingdoms.get(defendingKingdom).get(defendingGeneral);

        // attackers win / defenders lose
        if(attackingKingdomObj.army > defendingKingdomObj.army) {
            attackingKingdomObj.army = Math.floor(attackingKingdomObj.army * 1.1);
            attackingKingdomObj.wins++;

            defendingKingdomObj.army = Math.floor(defendingKingdomObj.army * 0.9);
            defendingKingdomObj.losses++;
        }
        // defenders win / attackers win
        else if(attackingKingdomObj.army < defendingKingdomObj.army){
            defendingKingdomObj.army = Math.floor(defendingKingdomObj.army * 1.1);
            defendingKingdomObj.wins++;

            attackingKingdomObj.army = Math.floor(attackingKingdomObj.army * 0.9);
            attackingKingdomObj.losses++;
        }
    }

    let winner = new Map(Array.from(kingdoms).sort((a, b) => {
        if(Array.from(a[1])[0][1].wins > Array.from(b[1])[0][1].wins) {
            return -1;
        }
        else if(Array.from(a[1])[0][1].wins < Array.from(b[1])[0][1].wins) {
            return 1;
        }
        else {
            if(Array.from(a[1])[0][1].losses < Array.from(b[1])[0][1].losses) {
                return -1;
            }
            else if(Array.from(a[1])[0][1].losses > Array.from(b[1])[0][1].losses) {
                return 1;
            }
            else {
                if(a[0] > b[0]) {
                    return -1;
                }
                else if(a[0] < b[0]) {
                    return 1;
                }
                return 0;
            }
        }
        
    })).entries().next().value;

    console.log(`Winner: ${winner[0]}`);
    for (let [general, data] of [...winner[1]].sort()) {
        console.log(`/\\general: ${general}`);
        console.log(`---army: ${data.army}`);
        console.log(`---wins: ${data.wins}`);
        console.log(`---losses: ${data.losses}`);
    }

    //console.log(kingdoms)
}

let input1 = 
[ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
  { kingdom: "Stonegate", general: "Ulric", army: 4900 },
  { kingdom: "Stonegate", general: "Doran", army: 70000 },
  { kingdom: "YorkenShire", general: "Quinn", army: 0 },
  { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
  { kingdom: "Maiden Way", general: "Berinon", army: 100000 } ]

let input2 = 
[ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
  ["Stonegate", "Ulric", "Stonegate", "Doran"],
  ["Stonegate", "Doran", "Maiden Way", "Merek"],
  ["Stonegate", "Ulric", "Maiden Way", "Merek"],
  ["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]

solve(input1, input2);
function solve(xmlString) {
    if(xmlString.search(/<svg>[\s\S]+<\/svg>/) > -1) {
        let match = xmlString.match(/<svg><cat><text>[\s\S]+\[(.+)\]<\/text><\/cat>[/s/S.]*<cat>([\s\S]+)<\/cat><\/svg>/);

        if(match != null) {
            let result;
            let regex = /<g>\s*<val>\s*(\d+)\s*<\/val>\s*(\d+)\s*<\/g>/g;
            let totalRating = 0, count = 0;

            while ((result = regex.exec(match[2])) != null) {
                totalRating += Number(result[1]) * Number(result[2]); 
                count += Number(result[2]); 
            }
        
            let averageRating = (totalRating / count).toFixed(2);
            console.log(`${match[1]}: ${parseFloat(averageRating)}`);
        }
        else {
            console.log('Invalid format');
        }
    }
    else {
        console.log('No survey found');
    }
}

let input = '<p>Some random text</p><svg><cat><text>How do you rate our food? [Food - General]</text></cat><cat><g><val>1</val>0</g><g><val>2</val>1</g><g><val>3</val>3</g><g><val>4</val>10</g><g><val>5</val>7</g></cat></svg><p>Some more random text</p>';
solve(input);
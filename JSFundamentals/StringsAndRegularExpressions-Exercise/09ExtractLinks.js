function solve(args) {
    let result = [];
    let regex = /www\.[a-zA-Z0-9-]+(\.[a-z]+){1,}/;
    for (let sentence of args) {
        let match = regex.exec(sentence);
        if(match != null)
        {
            result.push(match[0]);
        } 
    }
    return result.join('\n');
}

function solve1(args) {
    let result = [];
    let regex = /www\.[a-zA-Z0-9-]+(\.[a-z]+){1,}/g;
    for (let sentence of args) {
        let matches = sentence.match(regex);
        if(matches != null)
        {
            result.push(matches[0]);
        } 
    }
    return result.join('\n');
}

let input = ['Join WebStars now for free, at www.web-stars.com',
'You can also support our partners:',
'Internet - www.internet.com',
'WebSpiders - www.webspiders101.com',
'Sentinel - www.sentinel.-ko'];

console.log(solve(input));
function solve(text, word) {
    let regex = new RegExp(`\\b${word}\\b`, 'gi');

    let match, count = 0;
    while((match = regex.exec(text)) != null)
    {
        count++;
    }
    return count;
}
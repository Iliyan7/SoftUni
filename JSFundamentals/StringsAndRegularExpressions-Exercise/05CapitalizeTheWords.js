function solve(string) {
    string = string.replace(/[A-Z]/g, (match, offset, string) => {
        return match.toLowerCase();
    });

    string = string.replace(/\b\w/g, (match, offset, string) => {
        return match.toUpperCase();
    });

    return string;
}

console.log(solve('Was that Easy? tRY thIs onE for SiZe!'));
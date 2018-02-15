function solve(string) {
    return string.match(/\b_[a-zA-Z0-9]+\b/g).map(u => u.substring(1)).join(',');
}
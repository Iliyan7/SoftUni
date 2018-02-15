function solve(array) {
    let html = '<table>\n';
    for (let jsonString of array) {
        let employee = JSON.parse(jsonString);
        html += '\t<tr>\n';
        html += `\t\t<td>${employee['name']}</td>\n`;
        html += `\t\t<td>${employee['position']}</td>\n`;
        html += `\t\t<td>${Number(employee['salary'])}</td>\n`;
        html += '\t<tr>\n';
    }
    html += '</table>'
    return html;
}
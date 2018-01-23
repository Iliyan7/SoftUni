function triangleArea(a, b, c) {
    let sp = (a + b + c) / 2;
    return Math.sqrt(sp * (sp - a) * (sp - b) * (sp - c));
}
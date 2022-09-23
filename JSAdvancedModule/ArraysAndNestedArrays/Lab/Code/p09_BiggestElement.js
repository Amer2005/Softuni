function solve(matrix)
{
    return Math.max(...matrix.map((a) => a = Math.max(...a)));
}

console.log(solve([[20, 50, 10],[8, 33, 145]]));
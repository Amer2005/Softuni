function solve(matrix)
{
    let total = 0;

    for(let row = 0;row < matrix.length;row++)
    {
        for(let col = 0;col < matrix[row].length;col++)
        {
            if(row + 1 < matrix.length && matrix[row + 1][col] == matrix[row][col])
            {
                total++;
            }

            if(col + 1 < matrix[row].length && matrix[row][col + 1] == matrix[row][col])
            {
                total++;
            }
        }
    }

    return total;
}

console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));
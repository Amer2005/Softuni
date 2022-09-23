function solve(matrix)
{
    function printMatrix(m)
    {
        for(let row = 0;row < m.length;row++)
        {
            console.log(m[row].join(' '));
        }
    }

    for(let i = 0;i < matrix.length;i++)
    {
        matrix[i] = matrix[i].split(" ");
    }


    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for(let i = 0;i < matrix.length;i++)
    {
        firstDiagonal += Number(matrix[i][i]);
        secondDiagonal += Number(matrix[i][matrix.length - i - 1]);
    }

    if(firstDiagonal != secondDiagonal)
    {
        printMatrix(matrix);
        return;
    }

    for(let row = 0;row < matrix.length;row++)
    {
        for(let col = 0;col < matrix[row].length;col++)
        {
            if(row == col || row == matrix.length - col - 1)
            {
                continue;
            }

            matrix[row][col] = firstDiagonal;
        }
    }

    printMatrix(matrix);
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);
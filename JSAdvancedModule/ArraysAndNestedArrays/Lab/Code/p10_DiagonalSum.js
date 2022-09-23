function solve(matrix)
{
    let n = matrix.length;

    let diagonal1 = 0;
    let diagonal2 = 0;

    for(let i = 0;i < n;i++)
    {
        diagonal1 += matrix[i][i];
        diagonal2 += matrix[i][matrix.length - 1 - i];
    }

    console.log(diagonal1 + " " + diagonal2);
}

solve([[3, 5, 17],[-1, 7, 14],[1, -8, 89]])
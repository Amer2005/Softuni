function solve(matrix)
{
    let wantedSum = -1;

    for(let row = 0;row < matrix.length; row++)
    {
        let sum = 0;
        for(let col = 0;col < matrix[row].length; col++)
        {
            sum += matrix[row][col];
        }

        if(wantedSum == -1)
        {
            wantedSum = sum;
        }

        if(sum != wantedSum)
        {
            console.log(false);
            return;
        }
    }

    for(let col = 0;col < matrix[0].length; col++)
    {
        let sum = 0;
        for(let row = 0;row < matrix.length; row++)
        {
            sum += matrix[row][col];
        }

        if(sum != wantedSum)
        {
            console.log(false);
            return;
        }
    }

    console.log(true);
    return;
}

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   
   
   );
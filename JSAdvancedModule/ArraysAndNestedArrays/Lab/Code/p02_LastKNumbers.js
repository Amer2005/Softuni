function solve(n, k)
{
    let arr = [];

    arr.length = n;

    arr[0] = 1;

    for(let i = 1;i < n;i++)
    {
        let sum = 0;
        for(let j = i - 1;j >= i - k;j--)
        {
            if(j < 0)
            {
                break;
            }

            sum += arr[j];
        }

        arr[i] = sum;
    }

    return arr;
}

console.log(solve(8, 2));
function solve(arr, n)
{
    n = n % arr.length;

    for(let i = 0;i < n;i++)
    {
        let num = arr.pop();

        arr.unshift(num);
    }

    console.log(arr.join(' '));
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15

);
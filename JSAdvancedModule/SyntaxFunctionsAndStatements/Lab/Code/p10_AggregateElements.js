function solve(array)
{
    let sum = 0;

    for(let i = 0;i < array.length;i++)
    {
        sum += array[i];
    }

    console.log(sum);

    let newArray = [];

    for(let i = 0;i < array.length;i++)
    {
        newArray.push(1 / array[i]);
    }

    sum = 0;

    for(let i = 0;i < newArray.length;i++)
    {
        sum += newArray[i];
    }

    console.log(sum);

    let result = "";

    for(let i = 0;i < array.length;i++)
    {
        result += String(array[i]);
    }

    console.log(result);
}

solve([1,2,3]);
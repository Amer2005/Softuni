function solve(numbers)
{
    let result = [];

    numbers.sort((a, b) => a - b);

    for(let i = 0;i < Math.floor(numbers.length / 2);i++)
    {
        result.push(numbers[i]);
        result.push(numbers[numbers.length - i - 1]);
    }

    if(numbers.length % 2 != 0)
    {
        result.push(numbers[Math.floor(numbers.length / 2)]);
    }

    return result;
}

console.log(solve([1,2,3]));
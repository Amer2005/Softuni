function solve(array)
{
    console.log(array
        .filter((a, i) => i % 2 != 0)
        .map((a) => a = a * 2)
        .reverse()
        .join(' ')
        );
}

solve([10, 15, 20, 25]);
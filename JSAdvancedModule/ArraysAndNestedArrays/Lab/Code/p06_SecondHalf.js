function solve(array)
{
    return array.sort((a, b) => a - b).filter((a, i, arr) => i >= (arr.length / 2 - arr.length % 2));
}

console.log(solve([3, 19, 14, 7, 2, 19, 6]));
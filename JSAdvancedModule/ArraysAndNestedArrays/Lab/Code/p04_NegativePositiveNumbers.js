function solve(array)
{
    return [...array.filter((x) => x < 0).reverse(), ...array.filter((x) => x >= 0)];
}

console.log(solve([3, -2, 0, -1]));
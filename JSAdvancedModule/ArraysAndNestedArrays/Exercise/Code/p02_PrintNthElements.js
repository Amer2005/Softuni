function solve(array, n)
{
    return array.filter((a,i) => i % n == 0);
}
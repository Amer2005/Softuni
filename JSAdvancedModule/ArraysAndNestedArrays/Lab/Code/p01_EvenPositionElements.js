function solve(input)
{
    console.log(input.filter((a, i) => i % 2 == 0).join(' '));
}

solve(['20', '30', '40', '50', '60']);
function solve(pies, firstPie, secondPie)
{
    let goodPies = pies.slice(pies.indexOf(firstPie), pies.indexOf(secondPie) + 1);

    return goodPies;
}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));
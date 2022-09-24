function solve(input)
{
    let towns = [];

    input.shift();

    for(let i = 0;i < input.length;i++)
    {
        let inputString = input[i].substring(2, input[i].length - 2);

        let inputArgs = inputString.split(' | ');

        towns.push({
            Town: inputArgs[0],
            Latitude: Math.round(Number(inputArgs[1]) * 100) / 100,
            Longitude: Math.round(Number(inputArgs[2]) * 100) / 100,
        })
    }

    console.log(JSON.stringify(towns));
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);
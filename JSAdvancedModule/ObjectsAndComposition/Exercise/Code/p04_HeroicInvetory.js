function solve(input)
{
    let result = [];

    for(let i = 0;i < input.length;i++)
    {
        let inputArgs = input[i].split(' / ');

        if(inputArgs.length == 2)
        {
            let hero = {
                name: inputArgs[0],
                level: Number(inputArgs[1]),
                items: []
            }

            result.push(hero);
            continue;
        }

        let hero = {
            name: inputArgs[0],
            level: Number(inputArgs[1]),
            items: inputArgs[2].split(', ')
        }

        result.push(hero);
    }

    console.log(JSON.stringify(result));
}

solve(['Isacc / 25',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);

solve(['Jake / 1000 / Gauss, HolidayGrenade']);
function solve(input)
{
    let towns = input
    .map(x => x.split(' <-> '))
    .map(x => {
       return {name:x[0], population:Number(x[1])};
    })

    let result = {};

    for(let town of towns)
    {
        if(result[town.name] == undefined)
        {
            result[town.name] = town.population;
        }
        else
        {
            result[town.name] += town.population;
        }
    }

    for(let town in result)
    {
        console.log(`${town} : ${result[town]}`);
    }
}

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

)
function solve(input)
{
    let storage = [];

    for(let i = 0;i < input.length;i++)
    {
        let inputArgs = input[i].split(' : ');
        storage.push({
            name: inputArgs[0],
            price: Number(inputArgs[1])
        });
    }

    storage.sort((first, second) => {
        if(first.name > second.name) 
        {
            return 1;
        }
        else if(first.name < second.name) 
        {
            return -1;
        }

        return 0;
    });

    if(storage.length == 0)
    {
        return;
    }

    console.log(storage[0].name[0]);

    console.log(`  ${storage[0].name}: ${storage[0].price}`);

    for(let i = 1;i < storage.length;i++)
    {
        if(storage[i].name[0] != storage[i - 1].name[0])
        {
            console.log(storage[i].name[0]);
        }

        console.log(`  ${storage[i].name}: ${storage[i].price}`)
    }
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);

solve(['Banana : 2',
`Rubic's Cube : 5`,
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']
);
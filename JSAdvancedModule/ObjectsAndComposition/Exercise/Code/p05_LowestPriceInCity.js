function solve(input)
{
    let minPrices = {};

    for(let i = 0;i < input.length;i++)
    {
        let inputArgs = input[i].split(' | ');
        let townName = inputArgs[0];
        let productName = inputArgs[1];
        let price = Number(inputArgs[2]);

        if(minPrices[productName] === undefined)
        {
            minPrices[productName] = {
                price: price,
                town: townName
            }
        }
        else
        {
            if(minPrices[productName].price > price)
            {
                minPrices[productName].price = price;
                minPrices[productName].town = townName;
            }
        }
    }

    for(let product in minPrices)
    {
        console.log(`${product} -> ${minPrices[product].price} (${minPrices[product].town})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);
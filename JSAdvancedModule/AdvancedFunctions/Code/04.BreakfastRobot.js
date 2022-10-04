function solution()
{
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    let recepies = {
        apple: {
            protein: 0,
            carbohydrate: 1,
            fat: 0,
            flavour: 2
        },
        lemonade: {
            protein: 0,
            carbohydrate: 10,
            fat: 0,
            flavour: 20
        },
        burger: {
            protein: 0,
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            carbohydrate: 0,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    return function(commands){
        commands = commands.split(' ');
        
        if(commands[0] == 'restock')
        {
            let ingredient = commands[1];
            let quantity = Number(commands[2]);

            ingredients[ingredient] += quantity;
        }
        else if(commands[0] == 'prepare')
        {
            let recepie = commands[1];
            let quantity = Number(commands[2]);

            for(let ingredient in ingredients)
            {
                let recepieNeeds = recepies[recepie];

                if(ingredients[ingredient] < recepieNeeds[ingredient] * quantity)
                {
                    return `Error: not enough ${ingredient} in stock`;
                }
            }

            for(let ingredient in ingredients)
            {
                ingredients[ingredient] -= recepies[recepie][ingredient] * quantity;
            }
        }
        else
        {
            let result = '';

            for(let ingredient in ingredients)
            {
                result = result + `${ingredient}=${ingredients[ingredient]} `;
            }

            return result.trim();
        }

        return 'Success';
    }
}

let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); 
console.log (manager ("restock carbohydrate 10")); 
console.log (manager ("restock flavour 10")); 
console.log (manager ("prepare apple 1")); 
console.log (manager ("restock fat 10")); 
console.log (manager ("prepare burger 1")); 
console.log(manager ("report"));
function solve(data){
    let brands = {};

    for(let i = 0;i < data.length;i++){
        let currentArgs = data[i].split(' | ');
        let brand = currentArgs[0];
        let model = currentArgs[1];
        let producedCars = Number(currentArgs[2]);

        if(brands[brand] == undefined)
        {
            brands[brand] = {};
        }

        if(brands[brand][model] == undefined)
        {
            brands[brand][model] = 0;
        }

        brands[brand][model] += producedCars;
    }

    for(let brand in brands){
        console.log(brand);
        for(let model in brands[brand]){
            console.log(`###${model} -> ${brands[brand][model]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);
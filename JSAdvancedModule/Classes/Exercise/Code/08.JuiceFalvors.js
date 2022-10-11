function solve(data){
    let juices = {};
    let bottles = {};

    for(let i = 0;i < data.length;i++){
        let currentArgs = data[i].split(' => ');

        let name = currentArgs[0];
        let quantity = Number(currentArgs[1]);

        if(juices[name] == undefined)
        {
            juices[name] = 0;
        }

        juices[name] += quantity;

        if(juices[name] >= 1000){
            if(bottles[name] == undefined)
            {
                bottles[name] = 0;
            }

            bottles[name] += Math.floor(juices[name] / 1000);

            juices[name] %= 1000;
        }
    }

    for(let fruit in bottles)
    {
        console.log(`${fruit} => ${bottles[fruit]}`)
    }
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

);
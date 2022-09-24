function solve(carRequirements)
{
    let car = {
        model: carRequirements.model
    };

    let engine = {};

    if(carRequirements.power <= 90)
    {
        engine = {
            power: 90,
            volume: 1800
        }
    }
    else if(carRequirements.power <= 120)
    {
        engine = {
            power: 120,
            volume: 2400
        }
    }
    else
    {
        engine = {
            power: 200,
            volume: 3500
        }
    }

    car.engine = engine;

    let carriage = {
        type: carRequirements.carriage,
        color: carRequirements.color
    }

    car.carriage = carriage;

    let wheelSize = carRequirements.wheelsize % 2 == 0 ? carRequirements.wheelsize - 1 : carRequirements.wheelsize;

    car.wheels = [wheelSize,wheelSize,wheelSize,wheelSize];

    return car;
}

console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));
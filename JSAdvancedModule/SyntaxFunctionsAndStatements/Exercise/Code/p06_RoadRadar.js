function roadRadar(speed, area)
{
    let maxSpeed = 0;

    switch(area)
    {
        case 'motorway': maxSpeed = 130; break;
        case 'interstate': maxSpeed = 90; break;
        case 'city': maxSpeed = 50; break;
        case 'residential': maxSpeed = 20; break;
    }

    if(maxSpeed >= speed)
    {
        console.log(`Driving ${speed} km/h in a ${maxSpeed} zone`);

        return;
    }

    let speedDiff = speed - maxSpeed;

    let status;

    if(speedDiff <= 20)
    {
        status = 'speeding';
    }
    else if(speedDiff <= 40)
    {
        status = 'excessive speeding';
    }
    else
    {
        status = 'reckless driving';
    }

    console.log(`The speed is ${speedDiff} km/h faster than the allowed speed of ${maxSpeed} - ${status}`)
}

RoadRadar(200, 'motorway');
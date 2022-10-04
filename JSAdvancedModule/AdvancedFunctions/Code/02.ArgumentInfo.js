function solve(...params)
{
    counts = {};

    for(let i = 0;i < params.length;i++)
    {
        let type = typeof params[i];

        if(counts[type] === undefined)
        {
            counts[type] = 1;
        }
        else
        {
            counts[type]++;
        }

        console.log(`${type}: ${params[i]}`);
    }

    countNumbers = [];

    for(let count in counts)
    {
        countNumbers.push({
            name: count,
            count: counts[count]
        })
    }

    countNumbers.sort((a, b) => b.count - a.count);


    console.log(countNumbers.map(x => `${x.name} = ${x.count}`).join('\n'));
}

solve('cat', 42, 52, function () { console.log('Hellsdo world!'); },function () { console.log('Hello world!'); },function () { console.log('Helldsao world!'); });
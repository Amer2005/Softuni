function solve(commands)
{
    let number = 1;
    let arr = [];

    for(let i = 0;i < commands.length;i++)
    {
        if(commands[i] == 'add')
        {
            arr.push(number);
            number++;
        }
        else
        {
            if(arr.length > 0)
            {
                arr.pop();
            }

            number++;
        }
    }

    if(arr.length == 0)
    {
        console.log('Empty');
    }

    for(let i = 0;i < arr.length;i++)
    {
        console.log(arr[i]);
    }
}

solve(['add', 
'add', 
'remove', 
'add', 
'add']
);
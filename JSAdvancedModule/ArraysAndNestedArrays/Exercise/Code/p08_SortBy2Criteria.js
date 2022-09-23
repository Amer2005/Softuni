function solve(arr)
{
    const sortingFunc = function (a, b) 
    {
        if(a.length > b.length)
        {
            return 1;
        }  
        else if(a.length < b.length)
        {
            return -1;
        }

        if(a.toLowerCase() > b.toLowerCase())
        {
            return 1;
        }
        else if(a.toLowerCase() < b.toLowerCase())
        {
            return -1;
        }

        return 0;
    };

    arr.sort(sortingFunc);

    console.log(arr.join('\n'));
}

solve(['test', 
'Deny', 
'omen', 
'Default']


);
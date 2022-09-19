function performActions(number, ...actions)
{
    number = Number(number);

    for(let i = 0;i < actions.length;i++)
    {
        number = performOneAction(number, actions[i]);
        console.log(number);
    }


    function performOneAction(num, action)
    {
        switch(action)
        {
            case 'chop': num /= 2; break;
            case 'dice': num = Math.sqrt(num); break;
            case 'spice': num++; break;
            case 'bake': num *= 3; break;
            case 'fillet': num -= num * 0.2; break;
        }

        return num;
    }
}

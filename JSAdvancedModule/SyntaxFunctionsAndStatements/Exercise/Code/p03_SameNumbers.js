function solve(number)
{
    let firstDigit = number % 10;

    let areSame = true;

    let sum = firstDigit;

    number /= 10;

    number = Math.floor(number);

    while(number != 0)
    {
        let digit = number % 10;

        number /= 10;

        number = Math.floor(number);

        sum += digit;

        if(firstDigit != digit)
        {
            areSame = false;
        }
    }

    console.log(areSame);
    console.log(sum);
}

solve(2222222);
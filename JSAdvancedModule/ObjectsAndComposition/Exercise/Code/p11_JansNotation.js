function solve(input)
{
    let numbers = [];

    for(let i = 0;i < input.length;i++){
        if(typeof(input[i]) != "number")
        {
            if(numbers.length <= 1)
            {
                console.log(`Error: not enough operands!`);
                return;
            }

            let first = numbers.pop();
            let second = numbers.pop();

            let operation = input[i];

            let result;

            switch(operation)
            {
                case '+': result = second + first; break;
                case '-': result = second - first; break;
                case '*': result = second * first; break;
                case '/': result = second / first; break;
            }

            numbers.push(result);
        }
        else
        {
            numbers.push(input[i]);
        }
    }

    if(numbers.length > 1)
    {
        console.log(`Error: too many operands!`);
        return;
    }

    console.log(numbers[0]);
}

solve([5,
    3,
    4,
    '*',
    '-']
   );
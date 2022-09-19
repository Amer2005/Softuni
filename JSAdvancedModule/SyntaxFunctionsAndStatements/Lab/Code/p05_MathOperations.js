function CalculateOperation(number1, number2, operation)
{
    let result;

    switch(operation)
    {
        case '+': result = number1+number2; break;
        case '-': result = number1-number2; break;
        case '*': result = number1*number2; break;
        case '/': result = number1/number2; break;
        case '%': result = number1%number2; break;
        case '**': result = number1**number2; break;
    }

    console.log(result);
}
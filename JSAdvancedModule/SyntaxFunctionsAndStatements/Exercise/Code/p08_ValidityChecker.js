function getValidDistances(x1, y1, x2, y2)
{
    function areValid(X1, Y1, X2, Y2)
    {
        let distance = Math.sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));

        let isValid = Number.isInteger(distance);

        return `{${X1}, ${Y1}} to {${X2}, ${Y2}} is ${isValid ? 'valid' : 'invalid'}`;
    }

    console.log(areValid(x1,y1,0,0));
    console.log(areValid(x2,y2,0,0));
    console.log(areValid(x1,y1,x2,y2));
}

getValidDistances(2, 1, 1, 1);
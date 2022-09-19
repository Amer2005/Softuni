function GetSquareOfStars(size = 5)
{
    for(let row = 0;row < size; row++)
    {
        let rowText = "";

        for(let col = 0;col < size; col++)
        {
            rowText += "* ";
        }
        console.log(rowText);
    }
}

GetSquareOfStars(3);
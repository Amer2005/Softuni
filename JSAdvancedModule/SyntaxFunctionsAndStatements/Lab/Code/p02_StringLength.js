function GetTotalLength(text1, text2, text3)
{
    let totalLength = text1.length + text2.length + text3.length;
    let avarageLength = totalLength / 3;

    console.log(totalLength);
    console.log(Math.floor(avarageLength));
}

GetTotalLength('chocolate', 'ice cream', 'cake');
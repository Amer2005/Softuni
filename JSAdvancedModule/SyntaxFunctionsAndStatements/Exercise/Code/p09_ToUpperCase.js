function toUpperCase(text)
{
    const regex = /\w+/g;
    let matches = text.match(regex);

    let output = "";
    for(let i = 0;i < matches.length - 1; i++)
    {
        matches[i] = matches[i].toUpperCase();

        output += matches[i] + ', ';
    }

    matches[matches.length - 1] = matches[matches.length - 1].toUpperCase();

    output += matches[matches.length - 1];

    console.log(output);
}

toUpperCase('Hi, how are you?');
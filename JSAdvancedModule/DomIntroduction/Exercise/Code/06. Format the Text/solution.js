function solve() {
    let sentances = document.getElementById('input').value.split('.');

    sentances = sentances.filter(x => x.length > 0);

    const paragraphLength = 3;

    let paragraphs = [];

    for(let i = 0;i < sentances.length;i += paragraphLength)
    {
        let paragraph = "";

        for(let j = 0;j < paragraphLength;j++)
        {
            if(i + j >= sentances.length)
            {
                break;
            }

            paragraph += sentances[i + j] + '.';
        }

        paragraphs.push(paragraph);
    }

    let result = paragraphs.map(p => `<p>${p}</p>`).join("");

    document.getElementById("output").innerHTML = result;
}
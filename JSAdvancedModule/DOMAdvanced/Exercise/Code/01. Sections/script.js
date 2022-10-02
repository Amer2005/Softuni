function create(words) {

    let contentDiv = document.getElementById('content');

    for(let i = 0;i < words.length;i++)
    {
        let paragraphDiv = document.createElement('div');
        let paragraph = document.createElement('p');

        paragraph.textContent = words[i];

        paragraph.style.display = 'none';

        paragraphDiv.appendChild(paragraph);

        paragraphDiv.addEventListener('click', (event) => {
            let currentParagraph = event.target.getElementsByTagName('p')[0];

            currentParagraph.style.display = 'block';
        })


        contentDiv.appendChild(paragraphDiv);
    }
}
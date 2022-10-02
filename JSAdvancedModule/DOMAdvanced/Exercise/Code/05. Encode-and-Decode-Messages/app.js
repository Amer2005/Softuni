function encodeAndDecodeMessages() {
    let main = document.getElementById('main');

    let mainDivs = document.getElementsByTagName('div');

    let encodeDiv = mainDivs[1];
    let decodeDiv = mainDivs[2];

    let encodeButton = encodeDiv.getElementsByTagName('button')[0];
    let encodeTextarea =  encodeDiv.getElementsByTagName('textarea')[0];

    let decodeButton = decodeDiv.getElementsByTagName('button')[0];
    let decodeTextarea =  decodeDiv.getElementsByTagName('textarea')[0];

    function ChangeText(text, change)
    {
        let newText = '';
        for(let i = 0;i < text.length;i++)
        {
            newText += String.fromCharCode(text.charCodeAt(i) + change);
        }

        return newText;
    }

    encodeButton.addEventListener('click', () => {
        let text = encodeTextarea.value;
        encodeTextarea.value = '';
        
        decodeTextarea.value  = ChangeText(text, 1);
    })

    decodeButton.addEventListener('click', () => {
        let text = decodeTextarea.value;
        
        decodeTextarea.value  = ChangeText(text, -1);
    })
}
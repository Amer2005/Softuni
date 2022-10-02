function solve() {
    let exerciseDiv = document.getElementById('exercise');

    let buttons = exerciseDiv.getElementsByTagName('button');
    let textAreas = exerciseDiv.getElementsByTagName('textarea');

    let generateButton = buttons[0];
    let generateTextarea = textAreas[0];

    let tableBody = exerciseDiv.getElementsByTagName('tbody')[0];
    let tableRows = tableBody.getElementsByTagName('tr');

    let buyButton = buttons[1];
    let buyTextarea = textAreas[1];
    
    generateButton.addEventListener('click', () => {
        let newFurniture = JSON.parse(generateTextarea.value);

        for(let i = 0;i < newFurniture.length;i++)
        {
            tableBody.innerHTML = tableBody.innerHTML + `<tr><td><img src="${newFurniture[i].img}"></td><td><p>${newFurniture[i].name}</p></td><td><p>${newFurniture[i].price}</p></td><td><p>${newFurniture[i].decFactor}</p></td><td><input type="checkbox"/></td></tr>`
        }
    });

    buyButton.addEventListener('click', () => {
        let furniture = [];

        for(let i = 0;i < tableRows.length;i++)
        {
            let currentFurniture = {};

            let currentCells = tableRows[i].getElementsByTagName('td');

            let cellCheckbox = currentCells[4].getElementsByTagName('input')[0];

            if(cellCheckbox.checked === false)
            {
                continue;
            }

            currentFurniture.name = currentCells[1].innerText;
            currentFurniture.price = Number(currentCells[2].innerText);
            currentFurniture.decFactor = Number(currentCells[3].innerText);

            furniture.push(currentFurniture);
        }

        let result = `Bought furniture: ${furniture.map(f => f.name).join(', ')}` + '\n';
        result += `Total price: ${furniture.map(f => f.price).reduce((partialSum, a) => partialSum + a, 0).toFixed(2)}` + '\n';
        result += `Average decoration factor: ${furniture.map(f => f.decFactor).reduce((a, b) => a + b, 0) / furniture.length}`;
        
        buyTextarea.value = result;
    })
}
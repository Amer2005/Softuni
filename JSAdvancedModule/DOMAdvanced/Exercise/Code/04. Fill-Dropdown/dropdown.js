function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValueElement = document.getElementById('newItemValue');
    let newItemText = newItemTextElement.value;
    let newItemValue = newItemValueElement.value;

    let newOption = document.createElement('option');

    newOption.textContent = newItemText;
    newOption.value = newItemValue;

    let menu = document.getElementById('menu');

    menu.appendChild(newOption);
    newItemTextElement.value = '';
    newItemValueElement.value = '';
}
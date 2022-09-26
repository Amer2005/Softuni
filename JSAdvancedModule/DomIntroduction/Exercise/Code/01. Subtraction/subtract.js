function subtract() {
    let firstNum = Number(document.getElementById("firstNumber").value);
    let secondNum = Number(document.getElementById("secondNumber").value);

    let div = document.getElementById("result");

    div.innerText = firstNum - secondNum;
}
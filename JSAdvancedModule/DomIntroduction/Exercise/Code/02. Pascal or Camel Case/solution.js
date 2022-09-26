function solve() {
    let words = document.getElementById("text").value.split(' ');

    let currentCase = document.getElementById("naming-convention").value;

    let result = "Error!";

    if(currentCase == "Camel Case")
    {
        result = words.map(x => x.toLowerCase()).map(str => str.charAt(0).toUpperCase() + str.slice(1)).join("");

        result = result.charAt(0).toLowerCase() + result.slice(1);
    }
    else if(currentCase == "Pascal Case")
    {
      result = words.map(x => x.toLowerCase()).map(str => str.charAt(0).toUpperCase() + str.slice(1)).join("");
    }

    let resultContainer = document.getElementById("result");

    resultContainer.innerText = result;
}
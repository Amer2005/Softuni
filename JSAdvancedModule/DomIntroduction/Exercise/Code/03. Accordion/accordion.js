function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let extraText = document.getElementById("extra");

    debugger;

    if(button.innerHTML == "More")
    {
        extraText.style.display = "block";
        button.innerHTML = "Less";
    }
    else
    {
        extraText.style.display = "none";
        button.innerHTML = "More";
    }
}
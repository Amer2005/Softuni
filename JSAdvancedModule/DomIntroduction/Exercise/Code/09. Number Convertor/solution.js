function solve() {
    document.getElementsByTagName("button")[0].addEventListener("click", onClick);
    document.getElementById("selectMenuTo").innerHTML = '<option selected value="binary">Binary</option> <option selected value="hexadecimal">Hexadecimal </option>';

    function onClick(){
        function convertToBinary(x) {
            let bin = 0;
            let rem, i = 1, step = 1;
            while (x != 0) {
                rem = x % 2;
                x = parseInt(x / 2);
                bin = bin + rem * i;
                i = i * 10;
            }
            return bin;
        }

        let decimalNumber = Number(document.getElementById("input").value);

        if(document.getElementById("selectMenuTo").value === "binary")
        {
            let binaryNumber = convertToBinary(decimalNumber);

            document.getElementById("result").value = binaryNumber;
        }
        else
        {
            let hexNumber = decimalNumber.toString(16);

            hexNumber = hexNumber.toUpperCase();

            document.getElementById("result").value = hexNumber;
        }
    }
}

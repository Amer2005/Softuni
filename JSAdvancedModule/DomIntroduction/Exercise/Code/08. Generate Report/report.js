function generateReport() {
    let table = document.getElementsByTagName("tbody")[0];
    let rows = table.getElementsByTagName("tr");

    let headers = document.getElementsByTagName("th");

    headers = [...document.getElementsByTagName("th")].map(e => e.getElementsByTagName("input")[0]);

    let result = [];

    for(let i = 0;i < rows.length;i++)
    {
        let cols = rows[i].getElementsByTagName("td");

        let currentObj = {};

        for(let j = 0;j < cols.length;j++)
        {
            if(headers[j].checked == true)
            {
                currentObj[headers[j].getAttribute("name")] = cols[j].innerText;
            }
        }

        result.push(currentObj);
    }

    document.getElementById("output").value = JSON.stringify(result);
}
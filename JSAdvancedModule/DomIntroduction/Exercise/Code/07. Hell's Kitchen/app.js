function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick () {
        let resturantsInfo = JSON.parse(document.getElementsByTagName("textarea")[0].value);

        let resturants = {};

        for(let i = 0;i < resturantsInfo.length;i++)
        {
            let resturantArguments = resturantsInfo[i].split(' - ');

            let resturantName = resturantArguments[0];

            let employees = resturantArguments[1].split(', ');

            for(let j = 0;j < employees.length;j++)
            {
                let employeeArguments = employees[j].split(' ');
                let employeeName = employeeArguments[0];
                let employeeSalary = Number(employeeArguments[1]);

                if(resturants[resturantName] === undefined)
                {
                    resturants[resturantName] = [];
                }

                resturants[resturantName].push({
                    name: employeeName,
                    salary: employeeSalary
                })
            }
        }

        let bestResturantSalary = -1;
        let bestResturantName = "";

        for(let resturant in resturants)
        {
            let avarageSalary = resturants[resturant].reduce((a, b) => a + b.salary, 0) / resturants[resturant].length;

            if(bestResturantSalary == -1 || avarageSalary > bestResturantSalary)
            {
                bestResturantSalary = avarageSalary;
                bestResturantName = resturant;
            }
        }

        let bestResturantBestSalary = Math.max(...resturants[bestResturantName].map(e => e.salary));

        let bestResturantText = `Name: ${bestResturantName} Average Salary: ${bestResturantSalary.toFixed(2)} Best Salary: ${bestResturantBestSalary.toFixed(2)}`;

        document.getElementById("bestRestaurant").getElementsByTagName("p")[0].innerText = bestResturantText;

        let workers = resturants[bestResturantName];

        workers.sort((e1, e2) => e2.salary - e1.salary);

        document.getElementById("workers").getElementsByTagName("p")[0].innerText = workers.map(w => `Name: ${w.name} With Salary: ${w.salary}`).join(" ");
    }
}
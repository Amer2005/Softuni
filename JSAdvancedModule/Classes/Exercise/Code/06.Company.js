class Company {
    constructor(){
        this.departments = {};
    }

    addEmployee(name, salary, position, department){
        if(!name || !salary || !position || !department)
        {
            throw new Error("Invalid input!");
        }

        if(salary < 0)
        {
            throw new Error("Invalid input!");
        }

        if(this.departments[department] == undefined)
        {
            this.departments[department] = [];
        }

        this.departments[department].push({
            name: name,
            salary: salary,
            position: position
        });

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){
        let departmentsArray = [];

        for(let department in this.departments)
        {
            departmentsArray.push({
                employees: this.departments[department],
                name: department
            });
        }

        departmentsArray.sort((emp1, emp2) => {
            return - emp1.employees.reduce((a, b) => a + b.salary, 0) / emp1.employees.length + emp2.employees.reduce((a, b) => a + b.salary, 0) / emp2.employees.length;
        })

        let bestDepartment = departmentsArray[0];

        let result = ``;

        result += (`Best Department is: ${bestDepartment.name}`) + '\n';
        result += (`Average salary: ${(bestDepartment.employees.reduce((a, b) => a + b.salary, 0) / bestDepartment.employees.length).toFixed(2)}`) + '\n';
        
        bestDepartment.employees.sort((a, b) => {
            if(b.salary - a.salary != 0)
            {
                return b.salary - a.salary;
            }

            return a.name.localeCompare(b.name);
        });

        result += bestDepartment.employees.map(x => `${x.name} ${x.salary} ${x.position}`).join('\n');
        return result;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

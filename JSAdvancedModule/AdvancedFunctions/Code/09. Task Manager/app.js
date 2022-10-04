function solve() {
    let addButton = document.getElementById("add");
    let taskInput = document.getElementById("task");
    let descritionTextarea = document.getElementById("description");
    let dateInput = document.getElementById("date");
    let openDiv = document.getElementsByTagName("section")[1].getElementsByTagName("div")[1];
    let inProgressDiv = document.getElementsByTagName("section")[2].getElementsByTagName("div")[1];
    let finishedDiv = document.getElementsByTagName("section")[3].getElementsByTagName("div")[1];
    addButton.setAttribute('type', 'button');

    addButton.addEventListener('click', function(){
        if(taskInput.value === "")
        {
            return;
        }
        if(descritionTextarea.value === "")
        {
            return;
        }
        if(dateInput.value === "")
        {
            return;
        }

        let newArticle = document.createElement('article');

        let taskLabel = taskInput.value;
        let taskDescription = descritionTextarea.value;
        let taskDate = dateInput.value;

        newArticle.innerHTML += `<h3>${taskInput.value}</h3><p>Description: ${descritionTextarea.value}</p><p>Due Date: ${dateInput.value}</p><div class="flex"><button class="green">Start</button><button class="red">Delete</button></div>`;

        openDiv.appendChild(newArticle);
    
        let articles = openDiv.getElementsByTagName('article');
        let currentArticle = articles[articles.length - 1];

        let startButton = currentArticle.getElementsByTagName('button')[0];
        
        startButton.addEventListener('click', function(event){
            event.target.parentElement.parentElement.remove();

            let inProgressArticle = document.createElement('article');
            inProgressArticle.innerHTML =  `<h3>${taskLabel}</h3><p>Description: ${taskDescription}</p><p>Due Date: ${taskDate}</p><div class="flex"><button class="red">Delete</button><button class="orange">Finish</button></div>`;
            inProgressDiv.appendChild(inProgressArticle);

            let inProgressDelete = inProgressArticle.getElementsByTagName('button')[0];

            inProgressDelete.addEventListener('click', function(event){
                event.target.parentElement.parentElement.remove();
            });

            let finishButton = inProgressArticle.getElementsByTagName('button')[1];

            finishButton.addEventListener('click', function(event){
                event.target.parentElement.parentElement.remove();
                let finishedArticle = document.createElement('article');
                finishedArticle.innerHTML =  `<h3>${taskLabel}</h3><p>Description: ${taskDescription}</p><p>Due Date: ${taskDate}</p>`;
                finishedDiv.appendChild(finishedArticle);
            });
        });

        let deleteButton = currentArticle.getElementsByTagName('button')[1];

        deleteButton.addEventListener('click', function(event){
            event.target.parentElement.parentElement.remove();
        });
    });
}
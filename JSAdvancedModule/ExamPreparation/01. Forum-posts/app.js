window.addEventListener("load", solve);

function solve(){
    let titleInput = document.getElementById('post-title');
    let categoryInput = document.getElementById('post-category');
    let contentTextArea = document.getElementById('post-content');
    let reviewUl = document.getElementById('review-list');
    let publishedUl = document.getElementById('published-list');
    let clearButton = document.getElementById('clear-btn');

    let publishButton = document.getElementById('publish-btn');

    publishButton.addEventListener('click', () => {
        let title = titleInput.value;
        let category = categoryInput.value;
        let content = contentTextArea.value;

        if(title.trim().length == 0 || category.trim().length == 0 || content.trim().length == 0){
            return;
        }

        let currentLi = document.createElement('li');

        currentLi.innerHTML = `<article><h4>${title}</h4><p>Category: ${category}</p><p>Content: ${content}</p></article><button class="action-btn edit">Edit</button><button class="action-btn approve">Approve</button>`

        currentLi.classList.add('rpost');

        reviewUl.appendChild(currentLi);
        
        titleInput.value = '';
        categoryInput.value = '';
        contentTextArea.value = '';

        let buttons = currentLi.getElementsByClassName('action-btn');

        let editButton = buttons[0];
        let approveButton = buttons[1];

        editButton.addEventListener('click', () => {
            console.log('editClicked');

            titleInput.value = title;
            categoryInput.value = category;
            contentTextArea.value = content;

            currentLi.remove();
        });

        approveButton.addEventListener('click', () => {
            currentLi.remove();

            currentLi = document.createElement('li');

            currentLi.classList.add('rpost');

            currentLi.innerHTML = `<article><h4>${title}</h4><p>Category: ${category}</p><p>Content: ${content}</p></article>`

            publishedUl.appendChild(currentLi);
        })
    });

    clearButton.addEventListener('click', () => {
        let allPublishedPosts = publishedUl.getElementsByTagName('li');

        for(let i = 0;i < allPublishedPosts.length;i++){
            allPublishedPosts[i].remove();
            i--;
        }
    })
}
window.addEventListener("load", solve);

function solve() {
    let publishButton = document.getElementById('form-btn');
    let firstNameInput = document.getElementById('first-name');
    let lastNameInput = document.getElementById('last-name');
    let ageInput = document.getElementById('age');
    let titleInput = document.getElementById('story-title');
    let genreInput = document.getElementById('genre');
    let storyInput = document.getElementById('story');
    let preview = document.getElementById('preview-list');
    let mainDiv = document.getElementById('main');

    publishButton.addEventListener('click', () => {
        let firstName =  firstNameInput.value;
        let lastName =  lastNameInput.value;
        let age = ageInput.value;
        let title = titleInput.value;
        let genre = genreInput.value;
        let story = storyInput.value;

        if(!firstName || !lastName || !age || !title || !genre || !story){
            return;
        }

        preview.innerHTML = `<h3>Preview</h3><li class="story-info"><article><h4>Name: ${firstName + ' ' + lastName}</h4><p>Age: ${age}</p><p>Title: ${title}</p><p>Genre: ${genre}</p><p>${story}</p></article><button class="save-btn">Save Story</button><button class="edit-btn">Edit Story</button><button class="delete-btn">Delete Story</button></li>`
        
        firstNameInput.value = '';
        lastNameInput.value = '';
        ageInput.value = '';
        titleInput.value = '';
        storyInput.value = '';

        publishButton.disabled = true;

        let saveButton = document.getElementsByClassName('save-btn')[0];
        let editButton = document.getElementsByClassName('edit-btn')[0];
        let deleteButton = document.getElementsByClassName('delete-btn')[0];

        saveButton.addEventListener('click', () => {
            mainDiv.remove();
            let newH1 = document.createElement('h1');
            newH1.innerText = "Your scary story is saved!";

            document.body.appendChild(newH1);
        });

        editButton.addEventListener('click', () => {
            preview.innerHTML = '<h3>Preview</h3>';

            publishButton.disabled = false;

            firstNameInput.value = firstName;
            lastNameInput.value = lastName;
            ageInput.value = age;
            titleInput.value = title;
            genreInput.value = genre;
            storyInput.value = story;
        });

        deleteButton.addEventListener('click', () => {
            preview.innerHTML = '<h3>Preview</h3>';

            publishButton.disabled = false;
        });
    });
}

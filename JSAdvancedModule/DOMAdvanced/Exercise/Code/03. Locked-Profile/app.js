function lockedProfile() {
    let profiles = document.getElementsByClassName('profile');

    for(let i = 0;i < profiles.length;i++){
        let showMoreButton = profiles[i].getElementsByTagName('button')[0];

        showMoreButton.addEventListener('click', (event) => {
            let parentNode = event.target.parentNode;
            let isLocked = parentNode.getElementsByTagName('input')[0].checked;

            if(isLocked){
                return;
            }

            let hideDiv = parentNode.getElementsByTagName('div')[0];

            if(event.target.innerText == 'Show more')
            {
                hideDiv.style.display = 'block';
                event.target.innerText = 'Hide it';
            }
            else
            {
                hideDiv.style.display = 'none';
                event.target.innerText = 'Show more';
            }
        })
    }
}
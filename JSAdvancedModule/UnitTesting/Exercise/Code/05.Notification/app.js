function notify(message) {
    let notificationDiv = document.getElementById('notification');

    notificationDiv.innerText = message;

    notificationDiv.style.display = 'block';

    notificationDiv.addEventListener('click', () => {
        notificationDiv.style.display = 'none';
    });
}
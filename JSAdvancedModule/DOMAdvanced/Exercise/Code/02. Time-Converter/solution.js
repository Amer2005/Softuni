function attachEventsListeners() {
    let mainDiv = document.getElementsByTagName('main')[0];

    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondsInput = document.getElementById('seconds');

    mainDiv.addEventListener('click', (event) => {
        if(event.target.type !== "button")
        {
            return;
        }

        let seconds = 0;

        let daysInput = document.getElementById('days');
        let hoursInput = document.getElementById('hours');
        let minutesInput = document.getElementById('minutes');
        let secondsInput = document.getElementById('seconds');

        switch(event.target.id)
        {
            case 'daysBtn': seconds = Number(daysInput.value) * 24 * 60 * 60; break;
            case 'hoursBtn': seconds = Number(hoursInput.value) * 60 * 60; break;
            case 'minutesBtn': seconds = Number(minutesInput.value) * 60; break;
            case 'secondsBtn': seconds = Number(secondsInput.value); break;
        }

        daysInput.value = (seconds / 24 / 60 / 60);
        hoursInput.value = (seconds / 60 / 60);
        minutesInput.value = (seconds / 60);
        secondsInput.value = (seconds);
    })
}
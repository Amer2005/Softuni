function validate() {
    let emailInput = document.getElementById('email');

    emailInput.addEventListener('change', () => {
        let email = emailInput.value;

        emailInput.classList.remove('error');

        let emailREGEX = /^[a-z]+@[a-z]+.[a-z]+$/; 
        let valid = emailREGEX.test(email);

        if(valid !== true){
            emailInput.classList.add('error');
        }
    })
}
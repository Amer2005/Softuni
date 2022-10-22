function validate() {
    function MakeBorderRed(elementToChange){
        elementToChange.style.border = '';
        elementToChange.style.borderColor = 'red';
    }

    function MakeBorderNormal(elementToChange){
        elementToChange.style.border = 'none';
    }

    function IsUsernameValid(){
        let username = usernameInput.value;

        if(username.length < 3 || username.length > 20){
            return false;
        }

        let regex = /[a-zA-Z0-9]+/;

        if(!regex.test(username)){
            return false;
        }

        return true;
    }

    function IsPasswordVlaid(password){

        if(password.length < 5 || password.length > 15){
            return false;
        }

        let regex = /\w+/;

        if(!regex.test(password)){
            return false;
        }

        return true;
    }

    function isEmailValid(){
        let email = emailInput.value;
        let atSymbolFound = false;

        for(let i = 0;i < email.length;i++){
            if(email[i] == '@'){
                atSymbolFound = true;
            }
            else if(email[i] == '.'){
                return true;
            }
        }

        return false;
    }

    

    let validationButton = document.getElementById('submit');
    let usernameInput = document.getElementById('username');
    let passwordInput = document.getElementById('password');
    let confirmPasswordInput = document.getElementById('confirm-password');
    let emailInput = document.getElementById('email');
    let checkBoxInput = document.getElementById('company');
    let companyInfo = document.getElementById('companyInfo');
    let companyNumberInput = document.getElementById('companyNumber');
    let isValidDiv = document.getElementById('valid');

    MakeBorderNormal(usernameInput);
    MakeBorderNormal(passwordInput);
    MakeBorderNormal(confirmPasswordInput);
    MakeBorderNormal(emailInput);
    MakeBorderNormal(companyNumberInput);

    checkBoxInput.addEventListener('change', () => {
        if(checkBoxInput.checked){
            companyInfo.style.display = 'block';
        }
        else{
            companyInfo.style.display = 'none';
        }
    });

    validationButton.addEventListener('click', (event) => {
        event.preventDefault();
        let isValid = true;

        if(!IsUsernameValid()){
            isValid = false;

            //alert(usernameInput.style.border);
            MakeBorderRed(usernameInput);
        }
        else{
            MakeBorderNormal(usernameInput);
        }

        if(!IsPasswordVlaid(passwordInput.value)){
            isValid = false;

            //alert(usernameInput.style.border);
            MakeBorderRed(passwordInput);
        }
        else{
            MakeBorderNormal(passwordInput);
        }

        if(!IsPasswordVlaid(confirmPasswordInput.value)){
            isValid = false;

            //alert(usernameInput.style.border);
            MakeBorderRed(confirmPasswordInput);
        }
        else{
            MakeBorderNormal(confirmPasswordInput);
        }

        if(!isEmailValid()){
            isValid = false;

            //alert(usernameInput.style.border);
            MakeBorderRed(emailInput);
        }
        else{
            MakeBorderNormal(emailInput);
        }

        if(passwordInput.value != confirmPasswordInput.value){
            MakeBorderRed(confirmPasswordInput);
        }

        if(checkBoxInput.checked){
            let companyNumber = Number(companyNumberInput.value);
            if(companyNumber < 1000 || companyNumber > 9999){
                isValid = false;

                MakeBorderRed(companyNumberInput);
            }
            else{
                MakeBorderNormal(companyNumberInput);
            }
        }

        if(isValid){
            isValidDiv.style.display = 'block';
        }
        else {
            isValidDiv.style.display = 'none';
        }
    });
}

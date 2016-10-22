function validate() {
    $('#submit').on('click', submitData);
    $('#company').on('change', showHideCompanyField);


    function submitData(event) {
        function checkUsername(username, usernameRegex) {
            if (usernameRegex.test(username.val())) {
                removeWarnFromField(username);
                return true;
            } else {
                setWarningToField(username);
                return false;
            }
        }

        function checkEmail(email, emailRegex) {
            if (emailRegex.test(email.val())) {
                removeWarnFromField(email);
                return true;
            } else {
                setWarningToField(email);
                return false;
            }
        }

        function checkPassword(password, confirmPassword, passwordRegex) {
            if (password.val() == confirmPassword.val() &&
                passwordRegex.test(password.val()) && passwordRegex.test(confirmPassword.val())) {
                removeWarnFromField(password);
                removeWarnFromField(confirmPassword);
                return true;
            } else {
                setWarningToField(password);
                setWarningToField(confirmPassword);
                return false;
            }
        }

        function checkCompanyNumber(companyNumber, companyNumberRegex) {
            if($('#company').is(':checked')) {
                if(companyNumberRegex.test(companyNumber.val())) {
                    removeWarnFromField(companyNumber);
                    return true;
                } else {
                    setWarningToField(companyNumber);
                    return false;
                }
            }

            return true;
        }

        function setWarningToField(field) {
            field.css('border-color', 'red');
        }

        function removeWarnFromField(field) {
            field.css('border', 'none');
        }

        let username = $('#username');
        let email = $('#email');
        let password = $('#password');
        let confirmPassword = $('#confirm-password');
        let companyNumber = $('#companyNumber');

        let usernameRegex = /^[a-zA-Z0-9]{3,20}$/;
        let emailRegex = /^(.*)@(.*)\.(.*)$/;
        let passwordRegex = /^[\w]{5,15}$/;
        let companyNumberRegex = /^[1-9][0-9]{3}$/;

        let usernameResult = checkUsername(username, usernameRegex);
        let emailResult = checkEmail(email, emailRegex);
        let passwordResult = checkPassword(password, confirmPassword, passwordRegex);
        let companyNumberCheck = checkCompanyNumber(companyNumber,companyNumberRegex);

        if(usernameResult && emailResult && passwordResult && companyNumberCheck) {
            $('#valid').show();
        } else {
            $('#valid').css('display', 'none');
        }

        event.preventDefault();
    }

    function showHideCompanyField() {
        if ($(this).is(':checked')) {
            $('#companyInfo').show();
        }
        else {
            $('#companyInfo').css('display', 'none');
        }
    }
}
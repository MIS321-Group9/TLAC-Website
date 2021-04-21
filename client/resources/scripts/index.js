function checkPasswordMatch() {
    var password = $("#password").val();
    var confirmPassword = $("#confirmpassword").val();

    if (password != confirmPassword)
        $("#divCheckPasswordMatch").html("Passwords do not match!").addClass('text-danger').removeClass('text-success');

    else
        $("#divCheckPasswordMatch").html("Passwords match.").addClass('text-success').removeClass('text-danger');
}

function checkEmailMatch() {
    var email = $("#email").val();
    var confirmEmail = $("#confirmemail").val();

    if (email != confirmEmail)
        $("#divCheckEmailMatch").html("Emails do not match!").addClass('text-danger').removeClass('text-success');

    else
        $("#divCheckEmailMatch").html("Emails match.").addClass('text-success').removeClass('text-danger');
}
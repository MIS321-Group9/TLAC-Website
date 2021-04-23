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

//jquery
$(document).ready(function() {
    $('#datepicker').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: "m/d/yy"
    });
});

var Trainer1 = {
    ID: 1,
    TrainerFName: 'Jared',
    TrainerLName: 'Haynie',
    TrainerBalance: 100,
    TrainerPhoneNo: 6509193256,
    TrainerEmail: 'jghaynie@crimson.ua.edu',
    TrainerPassword: "password1",
    IsCertified: true,
}

var Trainer2 = {
    ID: 2,
    TrainerFName: 'Jeff',
    TrainerLName: 'Haynie',
    TrainerBalance: 100,
    TrainerPhoneNo: 6509193256,
    TrainerEmail: 'jghaynie01@gmail.com',
    TrainerPassword: "password1",
    IsCertified: true,
}

var date1 = new Date();
var date2 = new Date()+1;

var Session1  = {
    SessionID: 1,
    IsCanceled: false,
    DateCreated: date1,
    DateOfSession: date1,
    PriceOfSession: 50,
    SessionLength: 30,
    SessionDescription: "test description 1",
    TrainerID: 1,
    CustomerID: 0,
    AdminID: 0
};

var Session2  = {
    SessionID: 1,
    IsCanceled: false,
    DateCreated: date2,
    DateOfSession: date2,
    PriceOfSession: 100,
    SessionLength: 30,
    SessionDescription: "test description 2",
    TrainerID: 2,
    CustomerID: 0,
    AdminID: 0
};

var Sessions = [Session1, Session2];
var Trainers = [Trainer1, Trainer2];

function getFullName(FName, LName) {
    return FName + " " + LName;
}

function dateToYMD(date) {
    var d = date.getDate();
    var m = date.getMonth() + 1; //Month from 0 to 11
    var y = date.getFullYear();
    return '' + y + '-' + (m<=9 ? '0' + m : m) + '-' + (d <= 9 ? '0' + d : d);
}

function selectedSession() {
    document.getElementById("s_date").placeholder=dateToYMD(Session1.DateOfSession);
    document.getElementById("s_price").placeholder="$"+Session1.PriceOfSession;
    document.getElementById("s_trainer").placeholder=getFullName(Trainer1.TrainerFName, Trainer1.TrainerLName);
    document.getElementById("s_description").placeholder=Session1.SessionDescription;
}

function displaySession() {
    
}

// function displaySessionsByID() {}
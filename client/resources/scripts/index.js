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
        onSelect: function(date) {
            getSessionsByDate(date)
         },
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: "mm/d/yy",
        minDate: new Date()
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
    SessionID: 2,
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

var Session3  = {
    SessionID: 3,
    IsCanceled: false,
    DateCreated: date1,
    DateOfSession: new Date(2021,5,26,0,0,0,0),
    PriceOfSession: 100,
    SessionLength: 30,
    SessionDescription: "test description 2",
    TrainerID: 2,
    CustomerID: 0,
    AdminID: 0
};

var Sessions = [Session1, Session2, Session3];
var Trainers = [Trainer1, Trainer2];

function getFullName(FName, LName) {
    return FName + " " + LName;
}

function dateToYMD(cDate) {
    date = new Date(cDate);
    var d = date.getDate();
    var m = date.getMonth() + 1; //Month from 0 to 11
    var y = date.getFullYear();
    return '' + (m<=9 ? '0' + m : m) + '/' + (d <= 9 ? '0' + d : d) + '/' + y;
}

function selectedSession(SessionID) {
    // var index = Sessions.findIndex(session => session.id === SessionID);
    Sessions.forEach(function(session){
        if (session.SessionID == SessionID){
            document.getElementById("s_date").placeholder=dateToYMD(session.DateOfSession);
            document.getElementById("s_price").placeholder="$"+session.PriceOfSession;
            document.getElementById("s_trainer").placeholder=getFullName(Trainer1.TrainerFName, Trainer1.TrainerLName);
            document.getElementById("s_description").placeholder=session.SessionDescription;
        }});
}

// var jsDate = $('#your_datepicker_id').datepicker('getDate');
// if (jsDate !== null) { // if any date selected in datepicker
//     jsDate instanceof Date; // -> true
//     jsDate.getDate();
//     jsDate.getMonth();
//     jsDate.getFullYear();
// }

function getSessions(){
    var Today = new Date();
    // var html = "<div class=\"card-group\">";
    var html = "";
    var count = 0;
    Sessions.forEach(function(session){
        if (checkDate(session, Today)){
            html+=newSession(session);
            count++;
        }});
    if (count == 0) {
        html="There are no sessions available";
    }
    // html += "</div>";
    document.getElementById('sessionTable').innerHTML = html;
}

function displayToday(){
    var Today = new Date();
    document.getElementById('datepicker').placeholder = dateToYMD(Today);
    getSessions();
}

function newSession(session){
    return "<div class=\"card card-signin\"><div class=\"card-body\"><h5 class=\"card-title\">"+ "Session " + session.SessionID +"</h5><h6 class=\"card-subtitle mb-2 text-muted\">"+ "Trainer: " + getFullName(Trainer1.TrainerFName, Trainer1.TrainerLName) +"</h6><p class=\"card-text\">"+ session.SessionDescription +"</p></div><div class=\"card-footer\"><p class=\"card-text\">"+ "Added on " + dateToYMD(session.DateCreated) +"<button class=\"btn btn-outline-primary\" onclick=\"selectedSession("+ session.SessionID +")\">Select</button></p></div></div>"
}

function checkDate(Session, Date){
    var day = getDay(Session.DateOfSession)
    var month = getMonth(Session.DateOfSession)
    var year = getYear(Session.DateOfSession)
    var _day = getDay(Date)
    var _month = getMonth(Date)
    var _year = getYear(Date)
    if (day == _day && year == _year && month == _month){
        return true;
    } else {
        return false;
    }
}

function getDay(date){
    newDate = new Date(date);
    return newDate.getDate();
}

function getMonth(date){
    newDate = new Date(date);
    return newDate.getMonth();
}

function getYear(date){
    newDate = new Date(date);
    return newDate.getFullYear();
}

function getSessionsByDate(date) {
    // var html = "<div class=\"card-group\">";
    var html = "";
    Sessions.forEach(function(session){
        if (checkDate(session, date)){
            html+=newSession(session);
        }});
    // html += "</div>";
    document.getElementById('sessionTable').innerHTML = html;
}



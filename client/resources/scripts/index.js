var Sessions = [];
var Trainers = [];

function checkPasswordMatch() {
    var password = $("#password").val();
    var confirmPassword = $("#confirmpassword").val();
    if (password != confirmPassword) {
        $("#divCheckPasswordMatch").html("Passwords do not match!").addClass('text-danger').removeClass('text-success');
    } else {
        $("#divCheckPasswordMatch").html("Passwords match.").addClass('text-success').removeClass('text-danger');
    }
}

function checkEmailMatch() {
    var email = $("#email").val();
    var confirmEmail = $("#confirmemail").val();
    if (email != confirmEmail) {
        $("#divCheckEmailMatch").html("Emails do not match!").addClass('text-danger').removeClass('text-success');
    } else {
        $("#divCheckEmailMatch").html("Emails match.").addClass('text-success').removeClass('text-danger');
    }
}

// jquery
$(document).ready(function() {
    $('#datepicker').datepicker({
        onSelect: function(date) {
            console.log(date);
            getSessionsByDate(date);
         },
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: "mm/d/yy",
        // minDate: new Date(),
        autoclose: true, 
        todayHighlight: true
        });
});

// var Trainer1 = {
//     ID: 1,
//     TrainerFName: 'Jared',
//     TrainerLName: 'Haynie',
//     TrainerBalance: 100,
//     TrainerPhoneNo: 6509193256,
//     TrainerEmail: 'jghaynie@crimson.ua.edu',
//     TrainerPassword: "password1",
//     IsCertified: true,
// }

// var Trainer2 = {
//     ID: 2,
//     TrainerFName: 'Jeff',
//     TrainerLName: 'Haynie',
//     TrainerBalance: 100,
//     TrainerPhoneNo: 6509193256,
//     TrainerEmail: 'jghaynie01@gmail.com',
//     TrainerPassword: "password1",
//     IsCertified: true,
// }

// var date1 = new Date();
// var date2 = new Date()+1;

// var Session1  = {
//     SessionID: 1,
//     IsCanceled: false,
//     DateCreated: date1,
//     DateOfSession: date1,
//     PriceOfSession: 50,
//     SessionLength: 30,
//     SessionDescription: "test description 1",
//     TrainerID: 1,
//     CustomerID: 0,
//     AdminID: 0
// };

// var Session2  = {
//     SessionID: 2,
//     IsCanceled: false,
//     DateCreated: date2,
//     DateOfSession: date2,
//     PriceOfSession: 100,
//     SessionLength: 30,
//     SessionDescription: "test description 2",
//     TrainerID: 2,
//     CustomerID: 0,
//     AdminID: 0
// };

// var Session3  = {
//     SessionID: 3,
//     IsCanceled: false,
//     DateCreated: date1,
//     DateOfSession: new Date(2021,5,26,0,0,0,0),
//     PriceOfSession: 100,
//     SessionLength: 30,
//     SessionDescription: "test description 2",
//     TrainerID: 2,
//     CustomerID: 0,
//     AdminID: 0
// };

// function populateArrays() {
//     Trainers = populateTrainersArray();
//     console.log(Trainers);
//     Sessions = populateSessionsArray();
// }

// function populateTrainersArray() {
//     const uri = 'https://localhost:5001/api/trainers';
//     fetch(uri).then(function(response){
//         return response.json();
//     }).then(function(json){
//         count=0;
//         json.forEach((trainer)=>{
//             trainer = {
//                 ID: trainer.ID,
//                 TrainerFName: trainer.trainerFName,
//                 TrainerLName: trainer.trainerLName,
//                 TrainerBalance: trainer.trainerBalance,
//                 TrainerPhoneNo: trainer.trainerPhoneNo,
//                 TrainerEmail: trainer.trainerEmail,
//                 TrainerPassword: trainer.trainerPassword,
//                 IsCertified: trainer.isCertified,
//             };
//         })
//     }).catch(function(error){
//         console.log(error);
//     });
// }


// function populateSessionsArray() {
//     const uri = 'https://localhost:5001/api/sessions';
//     fetch(uri).then(function(response){
//         return response.json();
//     }).then(function(json){
//         json.forEach((session)=>{
//             session = {
//                 SessionID: session.sessionID,
//                 IsCanceled: session.isCanceled,
//                 DateCreated: session.dateCreated,
//                 DateOfSession: session.dateOfSession,
//                 PriceOfSession: session.priceOfSession,
//                 SessionLength: session.sessionLength,
//                 SessionDescription: session.sessionDescription,
//                 TrainerID: session.trainerID,
//                 CustomerID: session.customerID,
//                 AdminID: session.adminID,
//             };
//             console.log(session);
//         })
//     }).catch(function(error){
//         console.log(error);
//     });
// }

// var Sessions = [Session1, Session2, Session3];
// var Trainers = [Trainer1, Trainer2];

function getFullName(FName, LName) {
    return FName + " " + LName;
}

function dateToYMD(inputDate) {
    date = new Date(inputDate);
    var d = date.getDate();
    var m = date.getMonth() + 1; //Month from 0 to 11
    var y = date.getFullYear();
    return '' + (m<=9 ? '0' + m : m) + '/' + (d <= 9 ? '0' + d : d) + '/' + y;
}

// function selectedSession(SessionID) {
//     var fname = "";
//     const uri = 'https://localhost:5001/api/sessions';
//     fetch(uri).then(function(response){
//         return response.json();
//     }).then(function(json)d{
//         json.forEach((session)=>{
//         if (session.SessionID == SessionID){
//             Trainers.forEach(function(trainer){
//                 if (trainer.ID == session.TrainerID){
//                     fname = getFullName(trainer.TrainerFName, trainer.TrainerLName);
//                 }}));
//             document.getElementById("s_date").placeholder=dateToYMD(session.DateOfSession);
//             document.getElementById("s_price").placeholder="$"+session.PriceOfSession;
//             document.getElementById("s_trainer").placeholder=fname;
//             document.getElementById("s_description").placeholder=session.SessionDescription;
//         }}});
//     }
// }

function selectedSession(SessionID){
    var fname = "";
    const allSessionsURI = 'https://localhost:5001/api/sessions';
    const allTrainersURI = 'https://localhost:5001/api/trainers';
    fetch(allSessionsURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.forEach((session)=>{
            if(session.sessionID==SessionID){
                fetch(allTrainersURI).then(function(response){
                    return response.json();
                }).then(function(json){
                    json.forEach(function(trainer){
                        if (trainer.id == session.trainerID){
                            fname = getFullName(trainer.trainerFName, trainer.trainerLName);
                            document.getElementById("s_date").placeholder=dateToYMD(session.dateOfSession);
                            document.getElementById("s_trainer").placeholder=fname;
                            document.getElementById("s_price").placeholder="$"+session.priceOfSession;
                            document.getElementById("s_description").placeholder=session.sessionDescription;
                        }
                    })
                })
            }
        })
    })
}

// var jsDate = $('#your_datepicker_id').datepicker('getDate');
// if (jsDate !== null) { // if any date selected in datepicker
//     jsDate instanceof Date; // -> true
//     jsDate.getDate();
//     jsDate.getMonth();
//     jsDate.getFullYear();
// }

// function getSessions(){
//     var Today = new Date();
//     // var ;html = "<div class=\"card-group\">";
//     var html = "";
//     var count = 0;
//     const sessionsURI = 'https://localhost:5001/api/sessions';
//     fetch(sessionsURI).then(function(response){
//         return response.json();
//     }).then(function(json){
//         json.forEach((session)=>{
//         if (checkDate(session, Today)){
//             html+=newSession(session);
//             count++;
//         })
//     });
//     if (count == 0) {
//         html="<p class=\"text-center\">There are no sessions available</p>";
//     }
//     // html += "</div>";
//     document.getElementById('sessionTable').innerHTML = html;
// }}

function getSessions(){
    var Today = new Date();
    var count = 0;
    let html = "";
    const allSessionsURI = 'https://localhost:5001/api/sessions';
    // const allTrainersURI = 'https://localhost:5001/api/trainers';
    fetch(allSessionsURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.forEach((session)=>{
            if(checkDate(session, Today))
            html+=newSession(session);
            count++;
        })
        if (count==0) {
            html="<p class=\"text-center\">There are no sessions available</p>";
        }
    })
    document.getElementById('sessionTable').innerHTML = html;
}

function displayToday(){
    var Today = new Date();
    document.getElementById('datepicker').placeholder = dateToYMD(Today);
    getSessions();
    populateAccountPage();
}

function newSession(session){
    var fname = "";
    const allTrainersURI = 'https://localhost:5001/api/trainers';
    fetch(allTrainersURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.forEach((trainer)=>{
            if(trainer.id == session.trainerID){
                fname = getFullName(trainer.trainerFName, trainer.trainerLName)
            }
        });
    })
    return "<div class=\"card card-signin\"><div class=\"card-body\"><h5 class=\"\">"+ "Session " + session.sessionID +"<h6 class=\"card-subtitle mb-2 text-muted\">"+ getSessionHours(session) +"</h6></h5><button class=\"btn btn-outline-primary btn-block\" onclick=\"selectedSession("+ session.sessionID +")\">Select</button></div></div>"
}

function checkDate(Session, Date){
    var day = getDay(Session.dateOfSession)
    var month = getMonth(Session.dateOfSession)
    var year = getYear(Session.dateOfSession)
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

function getHour(date){
    newDate = new Date(date);
    return newDate.getHours();
}

function getSessionsByDate(date) {
    // var html = "<div class=\"card-group\">";
    const allSessionsURI = 'https://localhost:5001/api/sessions';
    var html="";
    var count=0;
    fetch(allSessionsURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.forEach((session)=>{
            console.log("checking session dates for a match");
            console.log("session date:" + session.dateOfSession);
            console.log("date to check:" + date);
            if(checkDate(session,date)){
                html+=newSession(session);
                console.log("session found");
                count++
            }
        });
        if (count==0){
            console.log("no sessions found");
            html="<p class=\"text-center\">There are no sessions available</p>";
        }
        document.getElementById('sessionTable').innerHTML = html;
    })
}

function getSessionHours(session){
    var startingHour = getHour(session.dateOfSession)%12||12;
    var endingHour = startingHour+1%12||12;
    var sAMPM = (startingHour < 12 || startingHour === 24) ? "AM" : "PM";
    var eAMPM = (endingHour < 12 || endingHour === 24) ? "AM" : "PM";
    return startingHour+":00 "+sAMPM+" - "+endingHour+":00 "+eAMPM;
}

// function getTrainerNameFromID(TrainerID){
//     Trainers.forEach(function(trainer){
//         if (trainer.ID == TrainerID){
//             var fname = getFullName(trainer.TrainerFName, trainer.TrainerLName);
//             return fname;
//         }});
// }

// </h5><button class=\"btn btn-outline-primary\" onclick=\"selectedSession("+ session.sessionID +")\">Select</button>


//login functions

function checkButton() {
    console.log("populating button info");
    console.log(localStorage.getItem('userType'));
    if (localStorage.getItem('userType')==1) {
        console.log("customer account");
        const singleCustomersURI = 'https://localhost:5001/api/customers/'+localStorage.getItem('userLogin');
        fetch(singleCustomersURI).then(function(response){
            return response.json();
        }).then(function(customer){
            document.getElementById('signup-link').innerHTML="Logout";
            document.getElementById('signup-link').onclick=logoutButton;
            //document.getElementById('login-link').style.display="none";
            document.getElementById('login-link').innerHTML="Welcome, "+getFullName(customer.customerFName, customer.customerLName);
            document.getElementById('login-link').href="account.html";
        })
    } else if (localStorage.getItem('userType')==2) {
        const singleTrainersURI = 'https://localhost:5001/api/trainers/'+localStorage.getItem('userLogin');
        fetch(singleTrainersURI).then(function(response){
            return response.json();
        }).then(function(trainer){
            document.getElementById('signup-link').innerHTML="Logout";
            document.getElementById('signup-link').onclick=logoutButton;
            //document.getElementById('login-link').style.display="none";
            document.getElementById('login-link').innerHTML="Welcome, "+getFullName(trainer.trainerFName, trainer.trainerLName);
            document.getElementById('login-link').href="account.html";
        })
    } else if (localStorage.getItem('userType')==3) {
        const singleAdminsURI = 'https://localhost:5001/api/admins/'+localStorage.getItem('userLogin');
        fetch(singleAdminsURI).then(function(response){
            return response.json();
        }).then(function(admin){
            document.getElementById('signup-link').innerHTML="Logout";
            document.getElementById('signup-link').onclick=logoutButton;
            //document.getElementById('login-link').style.display="none";
            document.getElementById('login-link').innerHTML="Admin Dashboard";
            document.getElementById('login-link').href="account.html";
        })
    }
}

function logoutButton(){
    dLoginFunction();
    checkButton();
}
function indexStart(){
    checkButton();
}
function scheduleStart(){
    checkButton();
    displayToday();
}
function accountStart(){
    loginCheck();
    checkButton();
}
function aboutStart(){
    checkButton();
}

function loginCheck(){
    if (localStorage.getItem('userLogin') == 0){
        alert("Error: You are not logged in. Redirecting to Login page.")
        window.location.href = "login.html";
    } else {
        populateAccountPage();
    }
}

function tryLogin(){
    var user = document.getElementById('email-input-login').value;
    var password = document.getElementById('password-input-login').value;
    const allCustomersURI = 'https://localhost:5001/api/customers';
    const allTrainersURI = 'https://localhost:5001/api/trainers';
    const allAdminsURI = 'https://localhost:5001/api/admins';
    fetch(allCustomersURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.some((customer)=>{
            console.log(user+" "+password);
            console.log(customer.customerEmail+" "+customer.customerPassword);
            if (user == customer.customerEmail && password == customer.customerPassword){
                console.log("logging in as customer");
                cLoginFunction(customer);
                return true;
            } else {
                console.log("not logging in as customer");
                fetch(allTrainersURI).then(function(response){
                    return response.json();
                }).then(function(json){
                    json.some((trainer)=>{
                        if (user == trainer.trainerEmail && password == trainer.trainerPassword){
                            console.log("logging in as trainer");
                            tLoginFunction(trainer);
                            return true;
                        } else {
                            console.log("not logging in as trainer");
                            fetch(allAdminsURI).then(function(response){
                                return response.json();
                            }).then(function(json){
                                json.some((admin)=>{
                                    if(user == admin.adminEmail && password == admin.adminPassword){
                                        console.log("logging in as admin");
                                        aLoginFunction(admin);
                                        return true;
                                    }
                                })
                            })
                        }
                    })
                })
            }
        })
    })
}
// dLoginFunction logs the user into a default account (is used to log the user out whenever they click "logout")
function dLoginFunction(){
    localStorage.setItem('userLogin', 0);
    localStorage.setItem('userType', 0);
    window.location.href = "index.html";
}

function cLoginFunction(user){
    console.log("logged in as " +user.customerEmail);
    localStorage.setItem('userLogin', user.id);
    localStorage.setItem('userType', 1);
    window.location.href = "account.html";
    // alert("logged in as "+user.customerFName+", "+user.customerEmail);
}

function tLoginFunction(user){
    console.log("logged in as " +user.trainerEmail);
    localStorage.setItem('userLogin', user.id);
    localStorage.setItem('userType', 2);
    window.location.href = "account.html";
}

function aLoginFunction(user){
    console.log("logged in as " +user.adminEmail);
    localStorage.setItem('userLogin', user.id);
    localStorage.setItem('userType', 3);
    window.location.href = "account.html";
}   

function populateAccountPage(){
    console.log("populating account info");
    console.log(localStorage.getItem('userType'));
    if (localStorage.getItem('userType')==1) {
        console.log("customer account");
        document.getElementById('a_type').innerHTML="Customer Account";
        const singleCustomersURI = 'https://localhost:5001/api/customers/'+localStorage.getItem('userLogin');
        fetch(singleCustomersURI).then(function(response){
            return response.json();
        }).then(function(customer){
            document.getElementById('a_fname').placeholder=customer.customerFName;
            document.getElementById('a_lname').placeholder=customer.customerLName;
            document.getElementById('a_balance').placeholder="$"+customer.customerBalance;
            document.getElementById('a_phoneno').placeholder=phoneNoFormat(customer.customerPhoneNo);
            document.getElementById('a_email').placeholder=customer.customerEmail;
            
            // document.getElementById('login-link').style.display="none";
            // document.getElementById('signup-link').innerHTML="Welcome, "+getFullName(customer.customerFName, customer.customerLName);
            // document.getElementById('signup-link').href="account.html";
        })
    } else if (localStorage.getItem('userType')==2) {
        document.getElementById('a_type').innerHTML="Trainer Account";
            const singleTrainersURI = 'https://localhost:5001/api/trainers/'+localStorage.getItem('userLogin');
            fetch(singleTrainersURI).then(function(response){
                return response.json();
            }).then(function(trainer){
                document.getElementById('a_fname').placeholder=trainer.trainerFName;
                document.getElementById('a_lname').placeholder=trainer.trainerLName;
                document.getElementById('a_balance').placeholder="$"+trainer.trainerBalance;
                document.getElementById('a_phoneno').placeholder=phoneNoFormat(trainer.trainerPhoneNo);
                document.getElementById('a_email').placeholder=trainer.trainerEmail;
                
                // document.getElementById('login-link').style.display="none";
                // document.getElementById('signup-link').innerHTML="Welcome, "+getFullName(trainer.trainerFName, trainer.trainerLName);
                // document.getElementById('signup-link').href="account.html";
            })
    } else if (localStorage.getItem('userType')==3) {
        document.getElementById('a_type').innerHTML="Admin Account";
            const singleAdminsURI = 'https://localhost:5001/api/admins/'+localStorage.getItem('userLogin');
            fetch(singleAdminsURI).then(function(response){
                return response.json();
            }).then(function(admin){
                document.getElementById('a_fname').style.display="none";
                document.getElementById('a_lname').style.display="none";
                document.getElementById('a_balance').style.display="none";
                document.getElementById('a_phoneno').style.display="none";
                document.getElementById('_fname').style.display="none";
                document.getElementById('_lname').style.display="none";
                document.getElementById('_balance').style.display="none";
                document.getElementById('_phoneno').style.display="none";
                document.getElementById('a_email').placeholder=admin.adminEmail;
                
                // document.getElementById('login-link').style.display="none";
                // document.getElementById('signup-link').innerHTML="Admin Dashboard";
                // document.getElementById('signup-link').href="account.html";
            })
        }
}

function phoneNoFormat(phoneNo) {
    phoneNo = phoneNo.replace(/[^\d]/g, "");
    if (phoneNo.length == 10) {
        return phoneNo.replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3");
    }
    return null;
}

function passwordToggle(){
    if (document.getElementById('password-input-login').type=="text"){
        document.getElementById('password-input-login').type="password"
    } else if (document.getElementById('password-input-login').type=="password"){
        document.getElementById('password-input-login').type="text";
    }
}
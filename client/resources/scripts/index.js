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
        minDate: new Date(),
        autoclose: true, 
        todayHighlight: true
        });
    $('#datepicker-trainer').datepicker({
        onSelect: function(date) {
            console.log(date);
            trainerSessions(date);
            },
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: "mm/d/yy",
        minDate: new Date(),
        autoclose: true, 
        todayHighlight: true
        });
    $('.ts_time').timepicker({
        // timeFormat: 'h:mm p',
        interval: 60,
        minTime: '8:00am',
        maxTime: '5:00pm',
        defaultTime: '8:00am',
        startTime: '8:00am',
        dynamic: true,
        dropdown: true,
        scrollbar: true
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
                            if(localStorage.getItem('userType')==2){
                                fname = getFullName(trainer.trainerFName, trainer.trainerLName);
                                // document.getElementById('ts-time').placeholder=getSessionHours(session);
                                document.getElementById('ts_price').placeholder=session.priceOfSession;
                                document.getElementById('ts_description').placeholder=session.sessionDescription;
                                document.getElementById("postsession-button").onclick = postSession(SessionID);
                                document.getElementById("cancelsession-button").onclick = cancelSession(SessionID);
                            } else {
                                fname = getFullName(trainer.trainerFName, trainer.trainerLName);
                                document.getElementById("s_date").placeholder=dateToYMD(session.dateOfSession);
                                document.getElementById("s_trainer").placeholder=fname;
                                document.getElementById("s_price").placeholder="$"+session.priceOfSession;
                                document.getElementById("s_description").placeholder=session.sessionDescription;
                                document.getElementById("booksession-button").onclick = bookSession(SessionID);
                            }
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
    if (localStorage.getItem('userType')==2) {
        document.getElementById('datepicker-trainer').placeholder = dateToYMD(Today);
    } else {
        document.getElementById('datepicker').placeholder = dateToYMD(Today);
    }
    getSessions();
    if(document.URL.includes="account.html"){
        populateAccountPage();
    }
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
    if(localStorage.getItem('userLogin') == 2){
        document.getElementById('time-alert').style.visibility = 'hidden';
        trainerSessionsToday();
    }
    checkScheduleType();
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

// CREATES A CUSTOMER ACCOUNT
function postCustomer(){
    const postCustApiUrl="https://localhost:5001/api/customers";
    const customerFName = document.getElementById("fname").value;
    const customerLName = document.getElementById("lname").value;
    const customerPhoneNo = document.getElementById("phonenumber").value;
    const customerEmail = document.getElementById("email").value;
    const customerPassword = document.getElementById("password").value;

    fetch(postCustApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            customerfname: customerFName,
            customerlname: customerLName,
            customerphoneno: customerPhoneNo,
            customeremail: customerEmail,
            customerpassword: customerPassword
        })
    })
    .then((response)=>{
        console.log(response);
        tryCustomerLogin(customerEmail, customerPassword);
    })
}

function postTrainer(){
    const postTrainerApiUrl="https://localhost:5001/api/trainers";
    const trainerFName = document.getElementById("fname").value;
    const trainerLName = document.getElementById("lname").value;
    const trainerPhoneNo = document.getElementById("phonenumber").value;
    const trainerEmail = document.getElementById("email").value;
    const trainerPassword = document.getElementById("password").value;

    // Check box for iscertified
    var trainerIsCertified = false;
    var isCertifiedCheckBox = document.getElementById("traineriscertified");
    if (isCertifiedCheckBox.checked == true)
    {
        trainerIsCertified = true;
    }

    fetch(postTrainerApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            trainerfname: trainerFName,
            trainerlname: trainerLName,
            trainerphoneno: trainerPhoneNo,
            traineremail: trainerEmail,
            trainerpassword: trainerPassword,
            isCertified: trainerIsCertified
        })

    })
    .then((response)=>{
        console.log(response);
        tryTrainerLogin(trainerEmail, trainerPassword);
    })
}
function tryCustomerLogin(inputEmail, inputPassword){
    const allCustomersURI = "https://localhost:5001/api/customers";
    fetch(allCustomersURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.some((customer)=>{
            // console.log(inputEmail+" "+inputPassword);
            // console.log(customer.customerEmail+" "+customer.customerPassword);
            if (inputEmail == customer.customerEmail && inputPassword == customer.customerPassword){
                console.log("logging in as customer");
                cLoginFunction(customer);
                return true;
            }
        })
    })
}
function tryTrainerLogin(inputEmail, inputPassword){
    const allTrainersURI = 'https://localhost:5001/api/trainers';
    fetch(allTrainersURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.some((trainer)=>{
            //console.log(inputEmail+" "+inputPassword);
            //console.log(trainer.trainerEmail+" "+trainer.trainerPassword);
            if (inputEmail == trainer.trainerEmail && inputPassword == trainer.trainerPassword){
                console.log("logging in as trainer");
                tLoginFunction(trainer);
                return true;
            }
        })
    })
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
            // console.log(user+" "+password);
            // console.log(customer.customerEmail+" "+customer.customerPassword);
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
        if (document.URL.includes("account.html")){
            document.getElementById('a_type').innerHTML="Customer Account";
        }
        const singleCustomersURI = 'https://localhost:5001/api/customers/'+localStorage.getItem('userLogin');
        fetch(singleCustomersURI).then(function(response){
            return response.json();
        }).then(function(customer){
            if (document.URL.includes("account.html")){
                document.getElementById('a_fname').placeholder=customer.customerFName;
                document.getElementById('a_lname').placeholder=customer.customerLName;
                document.getElementById('a_balance').placeholder="$"+customer.customerBalance;
                document.getElementById('a_phoneno').placeholder=phoneNoFormat(customer.customerPhoneNo);
                document.getElementById('a_email').placeholder=customer.customerEmail;
                document.getElementById('a_iscertified').style.display="none";
                document.getElementById('_iscertified').style.display="none";
            }
            
            // document.getElementById('login-link').style.display="none";
            // document.getElementById('signup-link').innerHTML="Welcome, "+getFullName(customer.customerFName, customer.customerLName);
            // document.getElementById('signup-link').href="account.html";
        })
    } else if (localStorage.getItem('userType')==2) {
        if (document.URL.includes("account.html")){
            document.getElementById('a_type').innerHTML="Trainer Account";
        }
            const singleTrainersURI = 'https://localhost:5001/api/trainers/'+localStorage.getItem('userLogin');
            fetch(singleTrainersURI).then(function(response){
                return response.json();
            }).then(function(trainer){
                if (document.URL.includes("account.html")){
                    document.getElementById('a_fname').placeholder=trainer.trainerFName;
                document.getElementById('a_lname').placeholder=trainer.trainerLName;
                document.getElementById('a_balance').placeholder="$"+trainer.trainerBalance;
                document.getElementById('a_phoneno').placeholder=phoneNoFormat(trainer.trainerPhoneNo);
                document.getElementById('a_email').placeholder=trainer.trainerEmail;
                document.getElementById('a_iscertified').placeholder=booleanFormat(trainer.isCertified);
                }
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
                document.getElementById('a_iscertified').style.display="none";
                document.getElementById('_iscertified').style.display="none";
                
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

function booleanFormat(booleanValue){
    var value = "False";
    if (booleanValue == 1)
    {
        value = "True";
    }
    return value;
}

function passwordToggle(){
    if (document.getElementById('password-input-login').type=="text"){
        document.getElementById('password-input-login').type="password"
    } else if (document.getElementById('password-input-login').type=="password"){
        document.getElementById('password-input-login').type="text";
    }
}

// createSession base function


// scheduling functions - logic
function bookSession(SessionID){
    const sessionID = SessionID;
    const customerID = localStorage.getItem('userLogin');
    const bookSessionUrl="https://localhost:5001/api/booksessions/"+sessionID+"/"+customerID;

    fetch(bookSessionUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
    })
    .then((response)=>{
        console.log(response);
        getSessions();
    })
}

function checkScheduleType(){
    console.log("checking schedule type");

    document.getElementById('trainer-schedule').style.visibility = 'hidden';
    document.getElementById('admin-schedule').style.visibility = 'hidden';
    document.getElementById('customer-schedule').style.visibility = 'hidden';
    document.getElementById('booksession-button').disabled = false;

    console.log(localStorage.getItem('userType'));

    if (localStorage.getItem('userType')==null) {
        console.log('no user');
        document.getElementById('booksession-button').disabled = true;
        document.getElementById('customer-schedule').style.visbility = 'visible';
    }

    if (localStorage.getItem('userType')==0) {
        console.log('no user');
        document.getElementById('booksession-button').disabled = true;
        document.getElementById('customer-schedule').style.visbility = 'visible';
    }
    
    if (localStorage.getItem('userType')==1) {
        console.log('client user');
        document.getElementById('customer-schedule').style.visibility = 'visible';
    }
    
    if (localStorage.getItem('userType')==2) {
        console.log('trainer user');
        document.getElementById('trainer-schedule').style.visibility = 'visible';
    }
    
    if (localStorage.getItem('userType')==3) {
        console.log('admin user');
        document.getElementById('admin-schedule').style.visibility = 'visible';
    }
}

function postSession(){
    const postSessionApiUrl="https://localhost:5001/api/sessions";

    date = document.getElementById("datepicker-trainer").value;
    console.log(date);

    var sessionLength = 1;
    var priceOfSession = document.getElementById("ts_price").value;
    var sessionDesc = document.getElementById("ts_description").value;
    var trainerID = localStorage.getItem('userLogin')
    var adminID = 0;
    // 2021-04-19 21:13:32
    // var dateString = (getYear(new Date(date))+"-"+(getMonth(new Date(date)))+"-"+getDay(new Date(date))+"T"+document.getElementById('time-selector').value+":00"+":00");
    // newDate = new Date(dateString);
    // console.log(newDate)

    var time_selector = document.getElementById('time-selector').value;
    console.log(time_selector); 
    var stringDate = (newDate.getFullYear()+'-'+(newDate.getMonth()+1)+'-'+newDate.getDate()+"T"+time_selector+":00Z")
    console.log(stringDate);

    fetch(postSessionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            sessionlength: parseInt(sessionLength),
            dateofsession: stringDate,
            priceofsession: parseFloat(priceOfSession),
            sessiondescription: sessionDesc,
            trainerid: parseInt(trainerID),
            adminid: parseInt(adminID)
        })
    }).then((response)=>{
        console.log(response);
    })
}

function trainerSessions(date) {
    console.log("trainer sessions by date")
    document.getElementById('ts_date').placeholder=dateToYMD(date);
    var count = 0;
    let html = ""; 
    const allSessionsURI = 'https://localhost:5001/api/sessions/';
    // const allTrainersURI = 'https://localhost:5001/api/trainers';
    fetch(allSessionsURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.forEach((session)=>{
            if(checkDate(session, date)) {
                console.log(session.sessionID);
                console.log(localStorage.getItem('userLogin'))
                if(session.id=localStorage.getItem('userLogin')){
                    html+=newSession(session);
                    count++;
                }
            }
        });
        if (count==0){
            console.log("no sessions found");
            html="<p class=\"text-center\">You have no sessions scheduled today.</p>";
        }
        document.getElementById('trainerSessionTable').innerHTML = html;
    })
}

function trainerSessionsToday(){
    console.log("trainer sessions today")
    var Today = new Date();
    document.getElementById('ts_date').placeholder=dateToYMD(Today);
    var count = 0;
    let html = "";
    const allSessionsURI = 'https://localhost:5001/api/sessions';
    fetch(allSessionsURI).then(function(response){
        return response.json();
    }).then(function(json){
        json.forEach((session)=>{
            if(checkDate(session, Today)) {
                if(session.sessionID=localStorage.getItem('userLogin')){
                    html+=newSession(session);
                    count++;
                }
            }
        });
        if (count==0) {
            console.log("no sessions found");
            html="<p class=\"text-center\">You have no sessions scheduled today.</p>";
        }
        document.getElementById('trainerSessionTable').innerHTML = html;
    })
}

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

function cancelSession(SessionID){

}

function timeLeft() {
    if (document.getElementById('time-selector').placeholder == "Choose a starting time"){
        document.getElementById('time-selector').placeholder = '8:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '8:00'){
        document.getElementById('time-warning').innerHTML = timeWarning;
        return;
    }
    if (document.getElementById('time-selector').placeholder == '9:00'){
        document.getElementById('time-selector').placeholder = '8:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '10:00'){
        document.getElementById('time-selector').placeholder = '9:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '11:00'){
        document.getElementById('time-selector').placeholder = '10:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '12:00'){
        document.getElementById('time-selector').placeholder = '11:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '1:00'){
        document.getElementById('time-selector').placeholder = '12:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '2:00'){
        document.getElementById('time-selector').placeholder = '1:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '3:00'){
        document.getElementById('time-selector').placeholder = '2:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '4:00'){
        document.getElementById('time-selector').placeholder = '3:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '5:00'){
        document.getElementById('time-selector').placeholder = '4:00'
        return;
    }
}

function timeRight(){
    if (document.getElementById('time-selector').placeholder == "Choose a starting time"){
        document.getElementById('time-selector').placeholder = '8:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '5:00'){
        document.getElementById('time-warning').innerHTML = timeWarning;
        return;
    }
    if (document.getElementById('time-selector').placeholder == '8:00'){
        document.getElementById('time-selector').placeholder = '9:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '9:00'){
        document.getElementById('time-selector').placeholder = '10:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '10:00'){
        document.getElementById('time-selector').placeholder = '11:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '11:00'){
        document.getElementById('time-selector').placeholder = '12:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '12:00'){
        document.getElementById('time-selector').placeholder = '1:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '1:00'){
        document.getElementById('time-selector').placeholder = '2:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '2:00'){
        document.getElementById('time-selector').placeholder = '3:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '3:00'){
        document.getElementById('time-selector').placeholder = '4:00'
        return;
    }
    if (document.getElementById('time-selector').placeholder == '4:00'){
        document.getElementById('time-selector').placeholder = '5:00'
        return;
    }
}

function timeEnter() {
    if (document.getElementById('time-selector').placeholder == '8:00') {
        (document.getElementById('time-selector').value = '8:00');
        return;
    }   
    if (document.getElementById('time-selector').placeholder == '9:00') {
        (document.getElementById('time-selector').value = '9:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '10:00') {
        (document.getElementById('time-selector').value = '10:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '11:00') {
        (document.getElementById('time-selector').value = '11:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '12:00') {
        (document.getElementById('time-selector').value = '12:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '1:00') {
        (document.getElementById('time-selector').value = '1:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '2:00') {
        (document.getElementById('time-selector').value = '2:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '3:00') {
        (document.getElementById('time-selector').value = '3:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '4:00') {
        (document.getElementById('time-selector').value = '4:00');
        return;
    }
    if (document.getElementById('time-selector').placeholder == '5:00') {
        (document.getElementById('time-selector').value = '5:00');
        return;
    }
}

var timeWarning = "<div class=\"alert alert-danger alert-dismissible fade show\" role=\"alert\"><strong>Error:</strong> We are only open between 8:00 AM-5:00 PM.<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button></div>"

function cancelSession(SessionID){
    const sessionID = SessionID
    const cancelSessionUrl="https://localhost:5001/api/cancelsessions/"+sessionID;

    fetch(cancelSessionUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            id: parseInt(sessionID),
        })
    })
    .then((response)=>{
        console.log(response);
        getSessions();
    })
}

function bookSession(SessionID){
    var sessionID = SessionID
    var customerID = localStorage.getItem('userLogin');
    const bookSessionUrl="https://localhost:5001/api/booksessions/"+sessionID+"/"+customerID;

    fetch(bookSessionUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
    })
    .then((response)=>{
        console.log(response);
        getSessions();
        // postTransactionCustomer(sessionID, customerID);
        // postTransactionTrainer(sessionID);
    })
}

function postTransactionCustomer(sessionID, customerID){
    const postTransApiUrl="https://localhost:5001/api/transactions";
    var priceOfSess =0;
    const trainerId =1;
    var custBalance =0;
    
    var custId =0;

    const readCustApiUrl="https://localhost:5001/api/customers/"+customerID;
    fetch(readCustApiUrl).then(function(response){
        return response.json();
    }).then(function(customer){
        custBalance = parseFloat(customer.customerBalance),
        custId = parseInt(customer.ID)
    });

    const readSessionApiUrl="https://localhost:5001/api/sessions/"+sessionID;
    fetch(readSessionApiUrl).then(function(response){
        return response.json();
    }).then(function(session){
        priceOfSess = parseFloat(session.priceOfSession * -1),
        sessionId = parseInt(session.sessionID)
    });

    fetch(postTransApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            currentbalance: custBalance,
            price: priceOfSess,
            sessionid: parseInt(sessionID),
            //cardid: null,//paraseInt(cardID),
            customerid: parseInt(customerID),
            trainerid: parseInt(trainerId)
            //discountid: null //parseInt(discountID)
        })
    })
    .then((response)=>{
        console.log(response);
    });
}

function postTransactionTrainer(sessionID){
    var postTransApiUrl="https://localhost:5001/api/transactions";
    var priceOfSess = 0;
    var trainerId = 0;
    var trainerBalance = 0;
    var custID = 4;

    const readSessionApiUrl="https://localhost:5001/api/sessions/"+sessionID;
    fetch(readSessionApiUrl).then(function(response){
        return response.json();
    }).then(function(session){
        priceOfSess = parseFloat(session.priceOfSession),
        trainerId = session.trainerID
        const readTrainerApiUrl="https://localhost:5001/api/trainers/"+trainerId;
            fetch(readTrainerApiUrl).then(function(response){
                return response.json();
            }).then(function(trainer){
                trainerBalance = parseFloat(trainer.trainerBalance)
            });
    });

    

    fetch(postTransApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            currentbalance: trainerBalance,
            price: priceOfSess,
            sessionid: parseInt(sessionID),
            //cardid: null,//paraseInt(cardID),
            customerid: custID,
            trainerid: parseInt(trainerId)
            //discountid: null //parseInt(discountID)
        })
    })
    .then((response)=>{
        console.log(response);
    });
}

function download(filename, text) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    element.setAttribute('download', filename);

    element.style.display = 'none';
    document.body.appendChild(element);

    element.click();

    document.body.removeChild(element);
}

document.getElementById("download-button").addEventListener("click", function(){
    
    var text = "";
    if (localStorage.getItem('userType')==3){
        var sessionsURL="https://localhost:5001/api/transactions";
        var trainersURL="https://localhost:5001/api/transactions";
        var customersURL="https://localhost:5001/api/transactions";
        fetch(sessionsURL).then(function(response){
            return response.json();
        }).then(function(json){
            json.forEach((session)=>{
                text+="ID:"+session.sessionID+", IS CANCELLED:"+session.isCanceled+", DATE CREATED:"+session.dateCreated+", DATE OF SESSION"+session.dateOfSession+", PRICE OF SESSION"+session.priceOfSession+", TRAINER ID:"+session.trainerID+"\n";
            })
        })
        fetch(trainersURL).then(function(response){
            return response.json();
        }).then(function(json){
            json.forEach((trainer)=>{
                text+="TrainerFName:"+trainer.trainerFName+", TrainerLName "+trainer.trainerLName+", Trainer Balance:"+trainer.trainerBalance+", IS CERTIFIED:"+trainer.isCertified+"\n";
            })
        })
        fetch(customersURL).then(function(response){
            return response.json();
        }).then(function(json){
            json.forEach((customer)=>{
                text+="CustomerFName:"+customer.customerFName+", CustomerLName "+customer.trainerLName+", Customer Balance:"+customer.customerBalance+"\n";
            })
        })
    } else if (localStorage.getItem('userType')==2){
        fetch(sessionsURL).then(function(response){
            return response.json();
        }).then(function(json){
            json.forEach((session)=>{
                if(session.trainerID == localStorage.getItem('userType')) {
                    text+="ID:"+session.sessionID+", IS CANCELLED:"+session.isCanceled+", DATE CREATED:"+session.dateCreated+", DATE OF SESSION"+session.dateOfSession+", PRICE OF SESSION"+session.priceOfSession+", TRAINER ID:"+session.trainerID+"\n";
                }
            })
        })
    } else if ((localStorage.getItem('userType')==1)) {
        fetch(sessionsURL).then(function(response){
            return response.json();
        }).then(function(json){
            json.forEach((session)=>{
                if(session.customerID == localStorage.getItem('userType')) {
                    text+="ID:"+session.sessionID+", IS CANCELLED:"+session.isCanceled+", DATE CREATED:"+session.dateCreated+", DATE OF SESSION"+session.dateOfSession+", PRICE OF SESSION"+session.priceOfSession+", TRAINER ID:"+session.trainerID+"\n";
                }
            })
        })
    }


    var filename = "admin_reports.txt";
    
    download(filename, text);
}, false);
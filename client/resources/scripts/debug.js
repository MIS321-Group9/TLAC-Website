function getAdmins(){
    const allAdminsUrl="https://localhost:5001/api/admins";

    fetch(allAdminsUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html="<ul>";
        json.forEach((admin)=>{
            html+="<li>"+"ID : "+admin.id+" | Email : " +admin.adminEmail+ " | Password : "+admin.adminPassword+"</li>"
        });
        html+="</ul>";
        document.getElementById("admins").innerHTML=html;
    }).catch(function(error){
        console.log(error);
    });
}
function getSessions(){
    const allSessionsUrl="https://localhost:5001/api/sessions";

    fetch(allSessionsUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html="<ul>";
        json.forEach((session)=>{
            html+="<li>"+"SessionID : "+session.sessionID+" | CustomerID : " +session.customerID+ " | TrainerID : "+session.trainerID+"</li>"
        });
        html+="</ul>";
        document.getElementById("sessions").innerHTML=html;
    }).catch(function(error){
        console.log(error);
    });
}

function getCustomers(){
    const allCustomersUrl="https://localhost:5001/api/customers";

    fetch(allCustomersUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html="<ul>";
        json.forEach((customer)=>{
            html+="<li>"+"CustomerID : "+customer.id+" | FName : " +customer.customerFName+ " | LName : "+customer.customerLName+" | Phone Number : "+customer.customerPhoneNo+" | Email : " +customer.customerEmail+ " | Password : "+customer.customerPassword+"</li>"
        });
        html+="</ul>";
        document.getElementById("customers").innerHTML=html;
    }).catch(function(error){
        console.log(error);
    });
}

function cancelSession(){
    const sessionID = document.getElementById("sessionid").value;
    const cancelSessionUrl="https://localhost:5001/api/sessions/"+sessionID+"/cancel";

    fetch(cancelSessionUrl, {
        method: "cancelSession",
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
    })
}

// CREATES A SESSION
function postSession(){
    const postSessionApiUrl="https://localhost:5001/api/sessions";

    const sessionLength = document.getElementById("length").value;
    const dateOfSession = document.getElementById("date").value;
    const priceOfSession = document.getElementById("price").value;
    const sessionDesc = document.getElementById("description").value;
    const trainerID = document.getElementById("trainerid").value;
    const adminID = document.getElementById("adminid").value;


    fetch(postSessionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            sessionlength: parseInt(sessionLength),
            dateofsession: new Date(dateOfSession),
            priceofsession: parseFloat(priceOfSession),
            sessiondescription: sessionDesc,
            trainerid: parseInt(trainerID),
            adminid: parseInt(adminID)
            
        })
    })
    .then((response)=>{
        console.log(response);
    })
}
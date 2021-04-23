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

function cancelSession(){
    const sessionID = document.getElementById("id1").value;
    const cancelSessionUrl="https://localhost:5001/api/sessions/"+sessionID;

    fetch(cancelSessionUrl, {
        method: "put",
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
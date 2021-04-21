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
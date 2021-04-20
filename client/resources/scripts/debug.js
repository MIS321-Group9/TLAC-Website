function getAdmins(){
    const allAdminsUrl="https://localhost:5001/api/Admin";

    fetch(allAdminsUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html="<ul>";
        json.forEach((admin)=>{
            html+="<li>"+"ID : "+admin.ID+" | Email : " +admin.AdminEmail+ " | Password : "+admin.AdminPassword+"</li>"
        });
        html+="</ul>";
        document.getElementById("Admin").innerHTML=html;
    }).catch(function(error){
        console.log(error);
    });
}
let missions = [];
getdata();
let connection = null;
setupSignalR();
let  missionrNametoupdate=-1;
async function getdata() {
    fetch('http://localhost:25601/Mission/')
        .then(x => x.json())
        .then(y => {
            missions = y;
           /* console.log(missions);*/
            displayMission();
        });
}


function displayMission() {
    document.getElementById('resularea').innerHTML = "";
    missions.forEach(t => {
        document.getElementById('resularea').innerHTML +=
            "<tr><td>" + t.missionId + "</td>" +
            "<td>" + t.spaceshipId + "</td>" +
            "<td>" + t.name + "</td>" +
            "<td>" + t.budgetMDollar + "</td>" +
            "<td>" + t.objective + "</td>" +
            "<td>" + t.launchYear + "</td>" +
        "<td><button type='button' onclick='remove(" + t.missionId + ")'>Delete</button></td>" +
        "<td><button type='button' onclick='showupdate(" + t.missionId + ")'>Update</button></td>" +
        
        
            "</tr>";
        console.log(t.name);
    });
}

function remove(id) {
    fetch('http://localhost:25601/Mission/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}




function create1() {
    let name = document.getElementById('missionname').value;
    let sid = document.getElementById('sid').value;
    let cost = document.getElementById('cost').value;
    let obj = document.getElementById('obj').value;
    let year = document.getElementById('year').value;
    
    fetch('http://localhost:25601/Mission/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                spaceshipId: sid,
                budgetMDollar: cost,
                objective: obj,
                launchYear: year
                
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
   

}

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:25601/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("MissionCreated", (user, message) => {
        getdata();
    });

    connection.on("MissionDeleted", (user, message) => {
        getdata();
    });
    connection.on("MissionUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
function showupdate(id) {
    document.getElementById('missionrNametoupdate').value = missions.find(t => t['id'] == id)['name'];
    document.getElementById('Objectiveupdate').value = missions.find(t => t['id'] == id)['objective'];
    document.getElementById('updateformdiv').style.display = 'flex';
    missionIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name1 = document.getElementById('missionname1').value;
    let obj1 = document.getElementById('obj1').value;
    
    fetch('http://localhost:25601/Mission/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name1,
                objective: obj1, missionId: missionIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

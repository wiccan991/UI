let spacehsips = [];
getdata();
let connection = null;
setupSignalR();
let SpaceshiprNametoupdate = -1;
async function getdata() {
    fetch('http://localhost:25601/Spaceship/')
        .then(x => x.json())
        .then(y => {
            spacehsips = y;
          console.log(spacehsips);
            displaySpaceship();
        });
}


function displaySpaceship() {
    document.getElementById('resularea').innerHTML = "";
    spacehsips.forEach(t => {
        document.getElementById('resularea').innerHTML +=
            "<tr><td>" + t.id + "</td>" +
            
            "<td>" + t.name + "</td>" +
        "<td>" + t.speed + "</td>" +
        "<td>" + t.makeYear + "</td>" +
          
            "<td><button type='button' onclick='remove(" + t.id + ")'>Delete</button></td>" +
            "<td><button type='button' onclick='showupdate(" + t.id + ")'>Update</button></td>" +


            "</tr>";
        console.log(t.speed);
    });
}

function remove(id) {
    fetch('http://localhost:25601/Spaceship/' + id, {
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
    let name = document.getElementById('Spaceshipname').value;
    let speed = document.getElementById('speed').value;
    let year = document.getElementById('year').value;
   

    fetch('http://localhost:25601/Spaceship/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                speed: speed,
                makeYear: year,
             

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

    connection.on("SpaceshipCreated", (user, message) => {
        getdata();
    });

    connection.on("SpaceshipDeleted", (user, message) => {
        getdata();
    });
    connection.on("SpaceshipUpdated", (user, message) => {
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
    document.getElementById('Spaceshipname1').value = spacehsips.find(t => t['id'] == id)['name'];
    document.getElementById('speed1').value = spacehsips.find(t => t['id'] == id)['speed'];
    document.getElementById('year1').value = spacehsips.find(t => t['id'] == id)['makeYear'];
    document.getElementById('updateformdiv').style.display = 'flex';
    SpaceshipIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name1 = document.getElementById('Spaceshipname1').value;
    let speed1 = document.getElementById('speed1').value;
    let year1 = document.getElementById('speed1').value;

    fetch('http://localhost:25601/Spaceship/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name1,
                speed: speed1, year1: year1, id:SpaceshipIdToUpdate
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

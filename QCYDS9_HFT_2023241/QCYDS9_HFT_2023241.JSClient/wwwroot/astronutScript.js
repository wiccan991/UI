let astronauts = [];
let astronautIdToUpdate = null; // Változó inicializálása


getdata();
let connection = null;
setupSignalR();

async function getdata() {
    fetch('http://localhost:25601/Astronaut')
        .then(x => x.json())
        .then(y => {
            astronauts = y;
            displayAstronaut(); // Függvény nevének javítása
        });
}

function displayAstronaut() { // Függvény nevének javítása
    document.getElementById('resularea').innerHTML = "";
    astronauts.forEach(t => {
        document.getElementById('resularea').innerHTML +=
            "<tr><td>" + t.astronautId + "</td>" +
            "<td>" + t.name + "</td>" +
            "<td>" + t.country + "</td>" +
            "<td>" + t.age + "</td>" +
            "<td><button type='button' onclick='remove(" + t.astronautId + ")'>Delete</button></td>" +
            "<td><button type='button' onclick='showupdate(" + t.astronautId + ")'>Update</button></td>" +
            "</tr>";
    });
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

function remove(id) {
    fetch('http://localhost:25601/Astronaut/' + id, {
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

function create() {
    let name = document.getElementById('Asrtonautname').value;
    let country = document.getElementById('country').value;
    let age = document.getElementById('age').value;

    fetch('http://localhost:25601/Astronaut/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            name: name,
            age: age,
            country: country
        })
    })
        .then(response => response.json()) // Válasz JSON formátumra való átalakítása
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:25601/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AsrtonautCreated", (user, message) => {
        getdata();
    });

    connection.on("AsrtonautDeleted", (user, message) => {
        getdata();
    });
    connection.on("AstronautUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

function showupdate(id) {
    astronautIdToUpdate = id;
    document.getElementById('Asrtonautname1').value = astronauts.find(t => t.astronautId == id)['name'];
    document.getElementById('country1').value = astronauts.find(t => t.astronautId == id)['country'];
    document.getElementById('age1').value = astronauts.find(t => t.astronautId == id)['age'];
    document.getElementById('updateformdiv').style.display = 'flex';
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name1 = document.getElementById('Asrtonautname1').value;
    let country1 = document.getElementById('country1').value;
    let age1 = document.getElementById('age1').value;

    fetch('http://localhost:25601/Astronaut/' + astronautIdToUpdate, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name1,
                country: country1,
                age: age1,
                astronautId: astronautIdToUpdate
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

getdata()

async function getdata() {

    await fetch('http://localhost:25601/Extrainfo')
        .then(x => x.json())
        .then(y => {
            drivers = y;
            //console.log(drivers);
            display();
        });
}
function GetAstronautsByMissionId() {
        document.getElementById('resultId').innerHTML = '';
        const alma = document.getElementById('ide').value;
        console.log(alma);
        fetch('http://localhost:25601/Extrainfo/GetAstronautsByMissionId/2')
            .then(response => response.text())
            .then(data => {
                const resultDiv = document.getElementById('resultId');
                resultDiv.innerHTML = `<p>${data}</p>`;
            })
            .catch(error => {
                console.error('Error:', error);
                const resultDiv = document.getElementById(resultId);
                resultDiv.innerHTML = '<p>An error occurred while fetching data</p>';
            });
    }
function GetAmericansCountInfo() {
    document.getElementById('resultId').innerHTML = '';
    fetch('http://localhost:25601/Extrainfo/GetAmericansCountInfo')
        .then(response => response.text())
        .then(data => {
            const resultDiv = document.getElementById('resultId');
            resultDiv.innerHTML = `<p>${data}</p>`;
        })
        .catch(error => {
            console.error('Error:', error);
            const resultDiv = document.getElementById(resultId);
            resultDiv.innerHTML = '<p>An error occurred while fetching data</p>';
        });
}

function removeNonCrudResult() {
    document.getElementById('resultId').innerHTML = '';
}

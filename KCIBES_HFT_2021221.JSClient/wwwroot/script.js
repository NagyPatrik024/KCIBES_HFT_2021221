let log = console.log;

let drivers = [];
let teams = [];
let motors = [];
let connection;
getMotor();
getDriver();
getTeam();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:17873/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamCreated", (user, message) => {
        getTeam();
    });
    connection.on("TeamDeleted", (user, message) => {
        getTeam();
    });

    connection.on("DriverCreated", (user, message) => {
        getDriver();
    });
    connection.on("DriverDeleted", (user, message) => {
        getDriver();
    });

    connection.on("MotorCreated", (user, message) => {
        getMotor();
    });
    connection.on("MotorDeleted", (user, message) => {
        getMotor();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        log("SignalR Connected.");
    } catch (err) {
        log(err);
        setTimeout(start, 5000);
    }
};



async function getMotor() {
    log('getMotor');
    await fetch('http://localhost:17873/motor')
        .then(x => x.json())
        .then(y => {
            motors = y;
            motordisplay();
        });
}

async function getDriver() {
    log('getDriver');
    await fetch('http://localhost:17873/driver')
        .then(x => x.json())
        .then(y => {
            drivers = y;
            driverdisplay();
        });
}
async function getTeam() {
    log('getTeam');
    await fetch('http://localhost:17873/team')
        .then(x => x.json())
        .then(y => {
            teams = y;
            teamdisplay();
        });
}


function driverdisplay() {
    document.getElementById('resultareadriver').innerHTML = "";
    drivers.forEach(t => {
        log(t);
        document.getElementById('resultareadriver').innerHTML += "<tr><td>" + t.id + `</td><td><input type="text" id="drivername_${t.id}" value="${t.name}">` + `</td><td><input type="text" "drivername_${t.id}" value="${t.age}">` + `</td><td><input type="text" "drivername_${t.id}" value="${t.motorId}">` + `</td><td><input type="text" "drivername_${t.id}" value="${t.teamId}">` + `</td><td><input type="text" "drivername_${t.id}" value="${t.wins}">` + `</td><td><button type="button" onclick="driverremove(${t.id});">Delete</button><button type="button" onclick="driverupdate(${t.id});">Update</button></td></tr>`;
    });
}

function teamdisplay() {
    document.getElementById('resultareateam').innerHTML = "";
    teams.forEach(t => {
        log(t);
        document.getElementById('resultareateam').innerHTML += "<tr><td>" + t.id + `</td><td><input type="text" id="teamname_${t.id}" value="${t.id}">` + `</td><td><input type="text" id="teamname_${t.id}" value="${t.name}">` + `</td><td><input type="text" id="teamname_${t.id}" value="${t.motorId}">` + `</td><td><input type="text" id="teamname_${t.id}" value="${t.team_Chief}">` + `</td><td><button type="button" onclick="teamremove(${t.id});">Delete</button><button type="button" onclick="teamupdate(${t.id});">Update</button></td></tr>`;
    });
}

function motordisplay() {
    document.getElementById('resultareamotor').innerHTML = "";
    motors.forEach(t => {
        log(t);
        document.getElementById('resultareamotor').innerHTML += "<tr><td>" + t.id + `</td><td><input type="text" id="motortype_${t.id}" value="${t.type}">` + `</td><td><button type="button" onclick="motorremove(${t.id});">Delete</button><button type="button" onclick="motorupdate(${t.id});">Update</button></td></tr>`;
    });
}


function drivercreate() {
    let name = document.getElementById('drivername').value;
    let age = document.getElementById('driverage').value;
    let motorid = document.getElementById('drivermotorid').value;
    let teamid = document.getElementById('driverteamid').value;
    let wins = document.getElementById('driverwins').value;
    fetch('http://localhost:17873/driver/', {
        method: 'POST',
        headers: { 'Content-Type': "application/json" },
        body: JSON.stringify({ Name: name, Age: age, MotorId: motorid, TeamId: teamid, Wins: wins }),
    })
        .then(response => response)
        .then(data => {
            log("DriverCreated");
            getDriver();
        })
        .catch((error) => { log("Error: ", error); });
}

function driverremove(id) {
    fetch('http://localhost:17873/driver/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': "application/json" },
        body: null,
    })
        .then(response => response)
        .then(data => {
            log("DriverDeleted");
            getDriver();
        })
        .catch((error) => { log("Error: ", error); });
}


function driverupdate(id) {
    log("UpdateDriver" + id);
    let name = document.getElementById('drivername_'+ id).value;
    let age = document.getElementById('driverage_' + id).value;
    let motorid = document.getElementById('drivermotorid_' + id).value;
    let teamid = document.getElementById('driverteamid_' + id).value;
    let wins = document.getElementById('driverwins_' + id).value;

    fetch('http://localhost:17873/driver/', {
        method: 'PUT',
        headers: { 'Content-Type': "application/json" },
        body: JSON.stringify({ CountryID: id, CountryName: name, StateForm: statform }),
    })
        .then(response => response)
        .then(data => {
            log("Country updated");
            getDriver();
        })
        .catch((error) => { log("Error: ", error); });
}
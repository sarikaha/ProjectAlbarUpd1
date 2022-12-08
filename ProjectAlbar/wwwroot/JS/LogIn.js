function login() {
    let userName = document.getElementById("userName").value;
    let password = document.getElementById("password").value;
    fetch('../api/user/Login/' + userName + "/" + password)
        .then(response => {
            if (response.ok && response.status == 200)
                return response.json();
        })
        .then(data => {
            if (data) {
                //window.location.href = "../HTML/helloUser.html";
                window.location.href = "../HTML/Product.html";
                sessionStorage.setItem('user', JSON.stringify(data));
            }
            else {
                alert("Error, try to login or sign in");
            }
        })
}

function newUser() {
    window.location.href = "NewUser.html";
}

function create() {
    fetch('../api/user/CreateUser', {
        headers: {
            'Content-Type': 'application/json',
        },
        method: 'POST',
        body: JSON.stringify({
            UserName: document.getElementById("userName").value,
            Password: document.getElementById("pw").value,
        }),
    })
        .then(response => response.json())
        .then(data => {
            if (data)
                window.location.href = "Product.html";
        });
}

function name() {
    document.getElementById("hello").innerHTML = "welcome to: " + JSON.parse(sessionStorage.getItem('user')).userName;
}

function update() {
    window.location.href = "updateDetails.html"

}

function onLoudeUpdateUser() {
    document.getElementById("userName").value = JSON.parse(sessionStorage.getItem('user')).userName;
    document.getElementById("pwu").value = JSON.parse(sessionStorage.getItem('user')).password;
}

function saveChange() {
    let Userid = JSON.parse(sessionStorage.getItem('user')).userId;
    fetch('../api/User/' + Userid, {
        headers: {
            'Content-Type': 'application/json',
        },
        method: 'PUT',
        body: JSON.stringify({
            
            userName: document.getElementById("userName").value,
            Password: document.getElementById("pwu").value//s, 
        }),
    })
        .then(response => response.json())
        .then(data => {
            if (data)
                sessionStorage.setItem('user', JSON.stringify(data));
            window.location.href = "helloUser.html";
        });
}
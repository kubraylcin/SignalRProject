
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7087/SignalRHub").build()
document.getElementById("sendMessage").disabled = true;
connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date(); //aktif saati alacak currenttime
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.innerText = user + ": "; // Kullanýcý adý kalýn þekilde
    li.appendChild(span);
    li.innerHTML += `${message}-${currentHour}: ${currentMinute}`;
    document.getElementById("messageList").appendChild(li);

});
connection.start().then(function () {
    document.getElementById("sendMessage").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("sendMessage").addEventListener("click", function (event) {
    const user = document.getElementById("userInput").value.trim();
    const message = document.getElementById("messageInput").value.trim();
    if (user && message) {
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        document.getElementById("messageInput").value = "";
    } else {
        alert("Ýsim ve mesaj boþ olamaz!");
    }
    event.preventDefault();
});
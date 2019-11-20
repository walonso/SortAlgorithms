"use strict";

// Creates the connection to the Hub
//var connection = new signalR.HubConnectionBuilder().withUrl("/clientHub").build();
var connection = new signalR.HubConnectionBuilder().withUrl("/SortHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
connection.on("ReceiveMessage", function (time, value) {
    //console.log('llego:', user, message); 
    var text = time + " - " + value;
    var li = document.createElement("li");
    li.textContent = text;
    document.getElementById("NumbersList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("idBubleSort").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

/*document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});*/

document.getElementById("idBubleSort").addEventListener("click", function (event) {   
    //connection.invoke("SendMessage", user, message).catch(function (err) {
    connection.invoke("StartBubleSort").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
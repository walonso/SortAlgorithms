"use strict";

/*$(document).ready(function () {
    var data = new google.visualization.DataTable();
});*/



// Creates the connection to the Hub
//var connection = new signalR.HubConnectionBuilder().withUrl("/clientHub").build();
var connection = new signalR.HubConnectionBuilder().withUrl("/SortHub").build();
//connection.hub.logging = true;
//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
connection.on("ReceiveProgressAscSortBubble", function (time, value) {
    addBubbleItem(time, value);    
});

connection.on("ReceiveProgressAscSortSelection", function (time, value) {
    addSelectionItem(time, value);
});

connection.on("ReceiveProgressAscSortInsertion", function (time, value) {
    addInsertionItem(time, value);
});

connection.on("ReceiveProgressAscSortShell", function (time, value) {
//    console.log('receive..', time, value)
    addShellItem(time, value);
});

connection.on("ReceiveProgressAscSortQuick", function (time, value) {
    console.log('receive..', time, value)
    addQuickItem(time, value);
});

connection.start().then(function () {
    document.getElementById("idBubleSort").disabled = false;
    document.getElementById("idSelectionSort").disabled = false;
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




"use strict";

/*$(document).ready(function () {
    var data = new google.visualization.DataTable();
});*/


// Creates the connection to the Hub
//var connection = new signalR.HubConnectionBuilder().withUrl("/clientHub").build();
var connection = new signalR.HubConnectionBuilder().withUrl("/SortHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
connection.on("ReceiveProgressSortBubble", function (time, value) {
    //console.log('llego:', user, message); 
    updateChartBubble(time, value);
   /* var text = time + " - " + value;
    var li = document.createElement("li");
    li.textContent = text;
    document.getElementById("NumbersSortBubble").appendChild(li);*/
});

connection.on("ReceiveProgressSortSelection", function (time, value) {
    updateChartSelection(time, value);
});

connection.on("ReceiveProgressSortInsertion", function (time, value) {
    updateChartInsertion(time, value);
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

document.getElementById("idBubleSort").addEventListener("click", function (event) {   
    //connection.invoke("SendMessage", user, message).catch(function (err) {
    var amount = document.getElementById("idAmount").value;
    connection.invoke("StartBubleSort", amount).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}); 
document.getElementById("idSelectionSort").addEventListener("click", function (event) {
    //connection.invoke("SendMessage", user, message).catch(function (err) {
    var amount = document.getElementById("idAmount").value;
    connection.invoke("StartSelectionSort", amount).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
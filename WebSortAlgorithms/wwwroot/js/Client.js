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
    initBubbleSort();
    initIntervalRenderingBubbleSort();
    var amount = document.getElementById("idAmount").value;
    $.get("/Sort/RunBubbleSortAscending/" + amount).catch(function (err) {
        return console.error(err.toString());
    }).then(() => {
       // finishIntervalRenderingBubbleSort();
        console.log("finish");
    });
    event.preventDefault();
}); 

document.getElementById("idSelectionSort").addEventListener("click", function (event) {
    initSelectionSort();
    initIntervalRenderingSelectionSort();
    var amount = document.getElementById("idAmount").value;
    $.get("/Sort/RunSelectionSortAscending/" + amount).catch(function (err) {
        return console.error(err.toString());
    }).then(() => {
       // finishIntervalRenderingSelectionSort();
        console.log("finish");
    });
    event.preventDefault();
});
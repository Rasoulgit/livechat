"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var user = "";
var roomId = 1;


$(document).ready(function () {
    $("#sendButton").prop('disabled', true);

    connection.on("DisplayValidation", function (isValid, message) {

        if (!isValid) {

            alert(message);

            user = prompt("Enter your Username:");

            ValidateUser(user);

        } else {

            loadRoom(roomId);
            $("#sendButton").prop('disabled', false);
        }

    });

    connection.on("DisplayRoom", function (messages) {

        $("#messagesList").empty();

        for (var i = 0; i < messages.length; i++) {

            var p = document.createElement("p");
            p.textContent = messages[i];
            $("#messagesList").append(p);
        }

    });

    connection.on("ReceiveMessage", function (user, roomId, message) {

        var activeRoom = parseInt($("button.active").attr('data-roomId'));

        if (roomId !== activeRoom) {
            return;
        }

        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = user + ": " + msg;
        var p = document.createElement("p");
        p.textContent = encodedMsg;
        $("#messagesList").append(p);
    });

    connection.start().then(function () {

        $("#sendButton").prop('disabled', true);

        user = prompt("Enter your Username:");

        ValidateUser(user);

    }).catch(function (err) {
        return console.error(err.toString());
    });

    $("#sendButton").on('click', function () {

        var message = $("#messageInput").val();

        connection.invoke("SendMessage", user, roomId, message).catch(function (err) {
            return console.error(err.toString());
        });

        event.preventDefault();

        $("#messageInput").val('');
    });

    $(".room-button").on('click', function () {

        $(".room-button").removeClass('active');

        roomId = parseInt($(this).attr('data-roomId'));

        $(this).addClass('active');

        loadRoom(roomId);
    });

});



function loadRoom(roomId) {
    connection.invoke("LoadRoomMessages", roomId).catch(function (err) {
        return console.error(err.toString());
    });
}

function ValidateUser(username) {
    connection.invoke("ValidateUser", username).catch(function (err) {
        return console.error(err.toString());
    });
}
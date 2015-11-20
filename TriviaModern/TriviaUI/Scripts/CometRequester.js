var clientGuid

$(document).ready(function() {
    var str = window.location.href;
    if (str.indexOf("?") < 0)
        Connect();
});

$(window).unload(function() {      // Unload -means when close the page 
    var str = window.location.href;
    if (str.indexOf("?") < 0)
        Disconnect();
});

function SendRequest() {
    var url = './CometAsyncHandler.ashx?cid=' + clientGuid;
    $.ajax({
        type: "POST",
        url: url,
        success: ProcessResponse,
        error: SendRequest
    });
}

function Connect() {
    var url = './CometAsyncHandler.ashx?cpsp=CONNECT';
    $.ajax({
        type: "POST",
        url: url,
        success: OnConnected,
        error: ConnectionRefused
    });
}

function Disconnect() {
    var url = './CometAsyncHandler.ashx?cpsp=DISCONNECT';
    $.ajax({
        type: "POST",
        url: url
    });
}

function ProcessResponse(transport) {
    $("#contentWrapper").html(transport);
    SendRequest();
}

function OnConnected(transport) {
    clientGuid = transport;
    SendRequest();
}

function ConnectionRefused() {
    $("#contentWrapper").html("Unable to connect to Comet server. Reconnecting in 5 seconds...");
    setTimeout(Connect(), 5000);
}
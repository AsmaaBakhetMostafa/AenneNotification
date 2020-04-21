//const connection = new signalR.HubConnectionBuilder()
//   // .withUrl("/chatHub")
//    .withUrl("http://doaaberam2020-001-site1.htempurl.com/chatHub")
//    .build();

////This method receive the message and Append to our list
//connection.on("ReceiveMessage", (user, message) => {
//    alert("dodosuccess");
//    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    const encodedMsg = user + " :: " + msg;
//    const li = document.createElement("li");
//    li.textContent = encodedMsg;
//    document.getElementById("messagesList").appendChild(li);
//});

//connection.start().catch(err => console.error(err.toString()));

//Send the message

//document.getElementById("sendMessage").addEventListener("click", event => {
//    const user = document.getElementById("userName").value;
//    const message = document.getElementById("userMessage").value;
//    //connection.invoke("GetMatchedDriver", 5,2,2 ,0,0).catch(err => console.error(err.toString()));
//    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));

//    event.preventDefault();
//});


//const connection = new signalR.HubConnectionBuilder()http://localhost:6715/AdminNotification
//    .withUrl("http://doaaberam2020-001-site1.htempurl.com/tripNotification")
//    .build();
let connection = new signalR.HubConnectionBuilder()
    .withUrl("http://doaaberam2020-001-site1.htempurl.com/AdminNotification",
        { skipNegotiation: true, transport: signalR.HttpTransportType.WebSockets })
    //.configureLogging(LogLevel.Information)
    .build();
connection.start()
    .then(res => {
        alert("stared");
        var userID = 25;
        var UserType = 3;
        console.log('connection started assssssss');
        alert(connection.id);
        debugger;
        //const userID = document.getElementById("userID").value;
        //const userIdTo = document.getElementById("UserType").value;
        connection.invoke('OnConnectedAsync', userID, UserType);
    })
    .catch(err => {
        console.error(err);
    });
//connection.on("userConnected", (UserID, connectionId) => {
//    console.log("UserID: " + UserID + "connectionId: " + connectionId)
//});
//connection.on("CatchConnectionIds", (LstConnIDs, Client_Id,Driver_Id) => {
//    console.log("LstConnIDs: " +" "+ LstConnIDs + " "+"Client_Id: " + " "+Client_Id +" "+ "Driver_Id :" +""+ Driver_Id)
//});
//connection.on("CatchListbeforSendToDriver", (list1, list2, Client_Id) => {
//    console.log("BeforGeneralListMatchedDriver: " + " " + list1 + " " + "ListMatchedDriver: " + " " + list1 + " " + "Client_Id :" + "" + Client_Id)
//});
//connection.on("CatchListAfterSendToDriver", (list1, list2, Client_Id) => {
//    console.log("AfterGeneralListMatchedDriver: " + " " + list1 + " " + "ListMatchedDriver: " + " " + list1 + " " + "Client_Id :" + "" + Client_Id)
//});
//This method receive the message and Append to our list
connection.on("NotifiedCurrentLongAndLattForDriver", (Client_Id, Client_Pickup_Long, Client_Pickup_Latt, Trip_Destination_Long, Trip_Destination_Latt, Healty_number, Handicapped_Number, Trip_Time) => { //Driver 
    alert("Listen Client_ID " + Client_Id + " " + "Lang:" + Client_Pickup_Long + " " + "Lat:" + Client_Pickup_Latt + "  " + "Trip_Destination_Long:" + Trip_Destination_Long + " " + "Trip_Destination_Latt:" + Trip_Destination_Latt
        + " " + "Healty_number:" + Healty_number + " " + "Handicapped_Number:" + Handicapped_Number + "" + "Trip_Time:" + Trip_Time );
    console.log("lat:" + Client_Pickup_Latt + "Long:" + Client_Pickup_Long);
    //Doaa Mahmoud: driver location , 
    connection.invoke("GetCurrentLongAndLattForDriver", 78, Client_Pickup_Long, Client_Pickup_Latt,25, 31.4035379, 31.0740967).then(res => {
        console.log('connection Resul');
        alert("send to driver to get his long and latt ");
    })
        .catch(err => console.error(err.toString()));
    //const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //const encodedMsg = user + " :: " + msg;
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});
                                                          
connection.on("NotifiedNearestDriverLongAndLattForDriver", (Client_Id1, Client_Pickup_Long1, Client_Pickup_Latt1) => { //Driver 
   // alert("");
    alert("Nearst  ClientID:"+Client_Id1+" lat:" + Client_Pickup_Latt1 + "Long:" + Client_Pickup_Long1);
   
    //const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //const encodedMsg = user + " :: " + msg;
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});
//
//connection.start(r=>alert("started")).catch(err => console.error(err.toString()));

//connection.start().then(function () {
//    debugger;
//    alert("started");
//});
//Send the message

document.getElementById("sendMessage").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
  

    connection.invoke("GetMatchedDriver", 78, 3, 3, 31.393918333333332, 31.059498333333334, 31.393918333333332, 31.059498333333334, 0).then(res=>
        {
        alert("send to GetMatchedDriver ");
        });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));

    event.preventDefault();
});


document.getElementById("AcceptTrip").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("StatusTripFromDriver", 78, 27, 1, 31.393918333333332, 31.059498333333334,"1:20:0").then(res => {
        alert("accepted trip ");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});


connection.on("NotifiedForClientByNearestDriver", (Driver_Id, Vehicle_Id, StartTime, Driver_Pickup_Long, Driver_Pickup_Latt) => { //Driver 
    // alert("");
    alert("push to client Driver_Id:" + Driver_Id + "Vehicle_Id=" + Vehicle_Id + " " +"StartTime :" + StartTime);

    //const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //const encodedMsg = user + " :: " + msg;
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});
//

document.getElementById("CancelTrip").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("StatusTripFromDriver", 78, 27, 2, 31.393918333333332, 31.059498333333334, "1:10:00", 31.393918333333332, 31.059498333333334).then(res => {
        alert("cancel  trip ");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});


connection.on("NotifiedNearestDriverLongAndLattForDriver", (Client_Id1, Client_Pickup_Long1, Client_Pickup_Latt1) => { //Driver 
    // alert("");
    alert("push to driver :" + Client_Id1 + " lat:" + Client_Pickup_Latt1 + "Long:" + Client_Pickup_Long1);

    //const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //const encodedMsg = user + " :: " + msg;
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});

document.getElementById("EndTrip").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("EndedTripForClient", 78).then(res => {
        alert("end  trip ");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});




document.getElementById("ClientCancelTrip").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("NotifiClientCancleTrip", 25, "1:00:00", "1:30:00").then(res => {
        alert("client cancel trip ");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});

document.getElementById("DriverCancelTrip").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("NotifiDriverCancleTrip", 78, "1:00:00", "1:30:00").then(res => {
        alert("Driver cancel trip ");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});
document.getElementById("GetRuchHour").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("RequestRashHour", 3,25).then(function (result) {
        //if (result) {
            //alert("Price_Per_KilloMeter_RashHour : " + result.Price_Per_KilloMeter_RashHour);
       // };
    });

    //catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});
connection.on("NotifiedDriverRashHour", (result) => { //Driver 
    // alert("");
    debugger;
    alert("push to   client with Price_Per_KilloMeter_RashHour:" + result.price_Per_KilloMeter_RashHour + " " + "RashHour_1_To : " + result.rashHour_1_To);

});

document.getElementById("GetTripCost").addEventListener("click", event => {
    debugger
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    var obj = new Object();
    obj.Trip_ID = 4845;
    obj.NormalKM = 92.15567598816251;
    obj.RusKM = 0;
    obj.TotalWaitingMinutes = 0;
    obj.TotalMinutes = "20";

    obj.IsAdditionalFees = true;
    obj.PickUpTime = "10:48:46";
    obj.DropOffTime = "10:49:1";
    obj.WeekDay = 4;

    connection.invoke("RequestPriceCost", obj, 50,25).then(function (result) {
      
            alert("Trip Cost for driver: " + result);
        
    });
  
    //catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});

connection.on("NotifiedClientTripCost", (TripCost, TotalWaitingMinutes, NormalKM, RusKM, TotalMinutes) => { //Driver 
    // alert("");
    alert("push to   client with trip cost:" + TripCost + " " + "TotalWaitingMinutes : " + TotalWaitingMinutes + "TotalMinutes :" + TotalMinutes);

});
connection.on("NotifiedDriverTripCost", (TripCost) => { //Driver 
    // alert("");
    alert("push to   Driver  with trip cost:" + TripCost );
});
connection.on("NotifiedDriverClientCancleTrip", (Driver_Id) => { //Driver 
    // alert("");
    alert("push to driver client cancel trip:" + Driver_Id);

    //const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //const encodedMsg = user + " :: " + msg;
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});


document.getElementById("SendTripIdToDriver").addEventListener("click", event => {

    connection.invoke("NotifiClientSaveTrip", 25,5,"assuit","cario").then(function (result) {

       alert("Trip id  for driver: ");
    });
    event.preventDefault();
});


connection.on("NotifiedDriverTripId", (Trip_Id, Trip_Pickup, Trip_Destination) => { //Driver 
    // alert("");
    alert("push to  Driver that  trip id :" + Trip_Id + "" + "Trip_Pickup:" + Trip_Pickup + " " + "Trip_Destination:" + Trip_Destination) ;
});




connection.on("NotifiedClientDriverCancleTrip", (DoorOpenCost) => { //Driver 
    // alert("");
    alert("push to  client that driver cancel trip:" + DoorOpenCost);

    //const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //const encodedMsg = user + " :: " + msg;
    //const li = document.createElement("li");
    //li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
});
document.getElementById("ClientArrived").addEventListener("click", event => {
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("NotifiDriverArrived", 78).then(res => {
        alert("driver arrived  ");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});


connection.on("NotifiedClientDriverArrived", (Client_Id) => { //Driver 
    // alert("");
    alert("push to  client driver arrived:" + Client_Id);

});
///////////////// test admin notification 
document.getElementById("DriverEmergency").addEventListener("click", event => {
    debugger;
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("AdminNotifications", 1,"Driver",1,2).then(res => {
        alert("Driver make emergency");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});

document.getElementById("ClientComplaint").addEventListener("click", event => {
    debugger;
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("AdminNotifications", 3, "Client", 2, 1).then(res => {
        alert("Client make Complaint");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});
document.getElementById("ClientSchudleTrip").addEventListener("click", event => {
    debugger;
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    connection.invoke("AdminNotifications", 1, "Client", 40, 3).then(res => {
        alert("Client make Complaint");
    });//catch(err => console.error(err.toString()));
    // connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});

connection.on("NotifiedAssignDriverToVehicle", (DriverID, VehicleID) => { //Driver 
    // alert("");
    alert("push to   driver that is assied:" + DriverID + " " + "VehicleID : " + VehicleID );

});


connection.on("NotifiedUnAssignDriverToVehicle", (DriverID, VehicleID) => { //Driver 
    // alert("");
    alert("push to   driver that is UnAssign:" + DriverID + " " + "VehicleID : " + VehicleID);

});
connection.on("NotifiedAssignDriverToScheduledTrip", (DriverID, TripeId, TripScheduleId) => { //Driver 
    // alert("");
    alert("push to   driver that is assied:" + DriverID + " " + "TripeId : " + TripeId + "" + "TripScheduleId:" + TripScheduleId);

});


connection.on("NotifiedUnAssignDriverToScheduledTrip", (DriverID, TripeId, TripScheduleId) => { //Driver 

    alert("push to   driver that is UnAssign:" + DriverID + " " + "TripeId : " + TripeId + "" + "TripScheduleId:" + TripScheduleId);

});

///////////////////////Trip_Chat
document.getElementById("TripChat").addEventListener("click", event => {
    debugger;
    const userIdFrom = document.getElementById("userIdFrom").value;
    const userIdTo = document.getElementById("userIdTo").value;

    const userName = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;
    const userType = document.getElementById("userType").value; 
   
    connection.invoke("SendMessage", 3123, 50, 25, "دعاء", "دعاء", 1,2,"1:10:0").catch(err => console.error(err.toString()));
    event.preventDefault();
});
//This method receive the message and Append to our list
connection.on("ReceiveMessage", (Trip_Id, User_Id_From, UserId_To, Message, UserName, UserTypeFrom, UserTypeTo, MessageTime) => {
  
    const msg = Message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    const encodedMsg = UserName + " :: " + msg;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

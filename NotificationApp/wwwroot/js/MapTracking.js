    let connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:6715/tripNotification",
                {skipNegotiation: true, transport: signalR.HttpTransportType.WebSockets })
               .build();

connection.start()
    .then(res => {
        alert("stared");
        connection.invoke('GetClientId', 135, 31.0740905000, 31.4035418000);
        connection.on('NotifiedGetClientId', (Client_Id, Driver_Pickup_Latt, Driver_Pickup_Long) => {
            DisplayGoogleMap(Driver_Pickup_Latt, Driver_Pickup_Long);
            connection.invoke('OnConnectedAsync', Client_Id, 4).then(res => {
                alert("dodo");
                connection.on("NotifiedCurrenDriverLocationForClient", (Driver_Id, Driver_Pickup_Long, Driver_Pickup_Latt) => {
                    DisplayGoogleMap(Driver_Pickup_Latt, Driver_Pickup_Long);
                });
            });
        })
    })
    .catch(err => {
        console.error(err);
    });

//connection.on("NotifiedClientLocationUrl", (LocationUrl) => { //Driver 

//    alert("push to client LocationUrl:" + LocationUrl);
//});
function DisplayDriverLocation() {
    connection.invoke("GetCurrentLongAndLattForSpecificDriver", 135, 30, 31.2796255000, 27.0338426000).then
        (res => {
            alert("driver location");
        })
}
directionsService = new google.maps.DirectionsService();
directionsDisplay = new google.maps.DirectionsRenderer();
function DisplayGoogleMap(Lat, Long) {

    //  var Lat = document.getElementById("txtLat").value;
    //  var Long = document.getElementById("txtLong").value;
    //27.0338426000, 31.2796255000
    //Set the Latitude and Longitude of the Map
    var myAddress = new google.maps.LatLng(Lat, Long);
    var dropoff = new google.maps.LatLng(30.0655972414, 31.3419559970);
    //Create Options or set different Characteristics of Google Map
    var mapOptions = {
        center: myAddress,
        zoom: 15,
        minZoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    //Display the Google map in the div control with the defined Options
    var map = new google.maps.Map(document.getElementById("myMap"), mapOptions);

    //Set Marker on the Map
    var marker = new google.maps.Marker({
        position: myAddress,
        animation: google.maps.Animation.BOUNCE,
        //icon:"https://img.icons8.com/plasticine/2x/car.png",
    });

    directionsDisplay.setMap(map);
    marker.setMap(map);
    //calRoute();
    //getRoute(myAddress, dropoff);
}
function calRoute() {
    var pickUp = new google.maps.LatLng(31.0740905000, 31.4035418000);
    var dropoff = new google.maps.LatLng(30.0655972414, 31.3419559970);
    var request = {
        origin: pickUp,
        destination: dropoff,
        travelMode: google.maps.TravelMode.DRIVING
    };
    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
        }
    });
}
function getRoute(pickUp, dropOff) {
    directionsService = new google.maps.DirectionsService();
    var mapOptions = {
        zoom: 15
    };
    map = new google.maps.Map(document.getElementById('myMap'), mapOptions);
    var rendererOptions = {
        map: map,
        suppressMarkers: true
    };

    directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);

    var request = {
        origin: pickUp,
        destination: dropOff,
        travelMode: google.maps.TravelMode.DRIVING
    };
    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
            var leg = response.routes[0].legs[0];
         //   makeMarker(leg.start_location, "pickup location");
          //  makeMarker(leg.end_location, "dropoff location");
        }
    });
}
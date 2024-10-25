import { Component, OnInit } from '@angular/core';

// declare const google: any;

// interface Marker {
// lat: number;
// lng: number;
// label?: string;
// draggable?: boolean;
// }


@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  selectedTab = 'listview';
  data: any[] = [];

  constructor() { }

  ngOnInit() {
    this.loadData();

    //var myLatlng = new google.maps.LatLng(40.748817, -73.985428);
    // var mapOptions = {
    //     zoom: 13,
    //     center: myLatlng,
    //     scrollwheel: false, //we disable de scroll over the map, it is a really annoing when you scroll through page
    //     styles: [{
    //         "elementType": "geometry",
    //         "stylers": [{
    //           "color": "#1d2c4d"
    //         }]
    //       },
    //       {
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#8ec3b9"
    //         }]
    //       },
    //       {
    //         "elementType": "labels.text.stroke",
    //         "stylers": [{
    //           "color": "#1a3646"
    //         }]
    //       },
    //       {
    //         "featureType": "administrative.country",
    //         "elementType": "geometry.stroke",
    //         "stylers": [{
    //           "color": "#4b6878"
    //         }]
    //       },
    //       {
    //         "featureType": "administrative.land_parcel",
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#64779e"
    //         }]
    //       },
    //       {
    //         "featureType": "administrative.province",
    //         "elementType": "geometry.stroke",
    //         "stylers": [{
    //           "color": "#4b6878"
    //         }]
    //       },
    //       {
    //         "featureType": "landscape.man_made",
    //         "elementType": "geometry.stroke",
    //         "stylers": [{
    //           "color": "#334e87"
    //         }]
    //       },
    //       {
    //         "featureType": "landscape.natural",
    //         "elementType": "geometry",
    //         "stylers": [{
    //           "color": "#023e58"
    //         }]
    //       },
    //       {
    //         "featureType": "poi",
    //         "elementType": "geometry",
    //         "stylers": [{
    //           "color": "#283d6a"
    //         }]
    //       },
    //       {
    //         "featureType": "poi",
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#6f9ba5"
    //         }]
    //       },
    //       {
    //         "featureType": "poi",
    //         "elementType": "labels.text.stroke",
    //         "stylers": [{
    //           "color": "#1d2c4d"
    //         }]
    //       },
    //       {
    //         "featureType": "poi.park",
    //         "elementType": "geometry.fill",
    //         "stylers": [{
    //           "color": "#023e58"
    //         }]
    //       },
    //       {
    //         "featureType": "poi.park",
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#3C7680"
    //         }]
    //       },
    //       {
    //         "featureType": "road",
    //         "elementType": "geometry",
    //         "stylers": [{
    //           "color": "#304a7d"
    //         }]
    //       },
    //       {
    //         "featureType": "road",
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#98a5be"
    //         }]
    //       },
    //       {
    //         "featureType": "road",
    //         "elementType": "labels.text.stroke",
    //         "stylers": [{
    //           "color": "#1d2c4d"
    //         }]
    //       },
    //       {
    //         "featureType": "road.highway",
    //         "elementType": "geometry",
    //         "stylers": [{
    //           "color": "#2c6675"
    //         }]
    //       },
    //       {
    //         "featureType": "road.highway",
    //         "elementType": "geometry.fill",
    //         "stylers": [{
    //           "color": "#9d2a80"
    //         }]
    //       },
    //       {
    //         "featureType": "road.highway",
    //         "elementType": "geometry.stroke",
    //         "stylers": [{
    //           "color": "#9d2a80"
    //         }]
    //       },
    //       {
    //         "featureType": "road.highway",
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#b0d5ce"
    //         }]
    //       },
    //       {
    //         "featureType": "road.highway",
    //         "elementType": "labels.text.stroke",
    //         "stylers": [{
    //           "color": "#023e58"
    //         }]
    //       },
    //       {
    //         "featureType": "transit",
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#98a5be"
    //         }]
    //       },
    //       {
    //         "featureType": "transit",
    //         "elementType": "labels.text.stroke",
    //         "stylers": [{
    //           "color": "#1d2c4d"
    //         }]
    //       },
    //       {
    //         "featureType": "transit.line",
    //         "elementType": "geometry.fill",
    //         "stylers": [{
    //           "color": "#283d6a"
    //         }]
    //       },
    //       {
    //         "featureType": "transit.station",
    //         "elementType": "geometry",
    //         "stylers": [{
    //           "color": "#3a4762"
    //         }]
    //       },
    //       {
    //         "featureType": "water",
    //         "elementType": "geometry",
    //         "stylers": [{
    //           "color": "#0e1626"
    //         }]
    //       },
    //       {
    //         "featureType": "water",
    //         "elementType": "labels.text.fill",
    //         "stylers": [{
    //           "color": "#4e6d70"
    //         }]
    //       }
    //     ]
    // };
    // var map = new google.maps.Map(document.getElementById("map"), mapOptions);

    // var marker = new google.maps.Marker({
    //     position: myLatlng,
    //     title: "Hello World!"
    // });

    // To add the marker to the map, call setMap();
    //marker.setMap(map);

  }

  private loadData(){
    this.data.push({"beachId":1, "timeCollectedMsg": "Older than 2 months", "beachName": "Palm Beach", "safeMessage": "Safe", "safeValue": 85});
    this.data.push({"beachId":2, "timeCollectedMsg": "Older than 3 months", "beachName": "Playas de Rosarito", "safeMessage": "Warning", "safeValue": 65});
    this.data.push({"beachId":3, "timeCollectedMsg": "Older than 4 months", "beachName": "Playas de Tijuana", "safeMessage": "Danger", "safeValue": 35});
  }

  getStyle(value: number)
  {
    const successColor = '#43f94a';
    const warningColor = '#ffe047'
    const dangerColor = '#fb297b';
    
    var selectedColor = successColor;
    
    if (value < 70) selectedColor = warningColor;
    if (value < 50) selectedColor = dangerColor;


    return {'--clr' : selectedColor, '--i': value};
  }

  getClass(value:number) {
    var className = '';

    if (value < 50) className = "less";

    return className;
  }

  getColor(value:number) {

    const successColor = 'success'; 
    const warningColor = 'warning'
    const dangerColor = 'danger';
    
    var selectedColor = successColor;
    
    if (value < 70) selectedColor = warningColor;
    if (value < 50) selectedColor = dangerColor;


    return selectedColor;

  }

  onSelectedBeach(id: any) {
    console.log('beach selected...', id);
  }


}


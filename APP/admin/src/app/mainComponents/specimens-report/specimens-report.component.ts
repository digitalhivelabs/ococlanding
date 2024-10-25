import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { filterDataModel } from '../../_models/filterDataModel';
import { DashboardServiceService } from '../../_services/dashboard-service.service';

@Component({
  selector: 'app-specimens-report',
  templateUrl: './specimens-report.component.html',
  styleUrl: './specimens-report.component.css'
})
export class SpecimensReportComponent implements OnInit{
  @Output() newItemEvent = new EventEmitter<any>();
  
  _data: any[] = [];
  _allData: any[] = [];
  _filteredData: any[] = [];
  _filters: any;
  
  _currentFilter: filterDataModel = new filterDataModel("", "", "", "");

  constructor(private _service: DashboardServiceService) {

    this._service.getDashboardInfo().subscribe({
      next: response => { 
        //console.log(response);
        this._allData = response; //this.getAllData(); //response 
        this._filteredData = this._allData;
        this._filters = this.getFilters(this._allData);
        //console.log(this._filters);
      }
    });

  }

  ngOnInit(): void {
    //console.log("All Data in report", this._allData);
    //this._allData = this.getAllData();
    //this._filteredData = this._allData
    //this._filters = this.getFilters();

    //console.log("about to send on init ", this._filteredData);
    //this.newItemEvent.emit(this._filteredData);    
  }

  onChangeFilter(filterName: any)
  {
    //console.log('filter selected: ', filterName);

    var data = this.applyFilter(this._currentFilter);

    if (filterName == 'year')
    {
      this._currentFilter.laboratory = '',
      this._currentFilter.location = '',
      this._currentFilter.parameter = ''

      const labs = data.map(item => item.laboratory)
        .filter((value, index, self) => self.indexOf(value) === index)
      this._filters.laboratories = labs;

      const locs = data.map(item => item.point)
        .filter((value, index, self) => self.indexOf(value) === index)
      this._filters.points = locs;

      const params = data.map(item => item.parameter)
        .filter((value, index, self) => self.indexOf(value) === index)
      this._filters.parameters = params;

    }

    if (filterName == 'lab')
    {
      this._currentFilter.location = '',
      this._currentFilter.parameter = ''

      const locs = data.map(item => item.point)
        .filter((value, index, self) => self.indexOf(value) === index)
      this._filters.points = locs;

      const params = data.map(item => item.parameter)
        .filter((value, index, self) => self.indexOf(value) === index)
      this._filters.parameters = params;
      
    }

    if (filterName == 'loc')
    {
      this._currentFilter.parameter = ''

      const params = data.map(item => item.parameter)
        .filter((value, index, self) => self.indexOf(value) === index)
      this._filters.parameters = params;

    }
            

    // const key = 'laboratory';
    // const arrayUniqueByKey = [...new Map(data.map(item =>
    // [item[key], item])).values()];


  }

  onApplyFilter() {
    //console.log(this._currentFilter);
    this._filteredData = this.applyFilter(this._currentFilter);
    this.newItemEvent.emit(this._filteredData);
  }

  onClearFilters() {
    this._currentFilter = new filterDataModel("","","","");
    this._filteredData = this.applyFilter(this._currentFilter);
    this._filters = this.getFilters(this._filteredData);
  }

  applyFilter(filterValue: filterDataModel) {

    var data = this._allData;

    if (filterValue.year != "") {
      data = data.filter((specimen) => specimen.specimenDate.includes(filterValue.year));
    }

    if (filterValue.laboratory != "") {
      data = data.filter((specimen) => specimen.laboratory.includes(filterValue.laboratory));
    }

    if (filterValue.location != "") {
      data = data.filter((specimen) => specimen.point.includes(filterValue.location));
    }

    if (filterValue.parameter != "") {
      data = data.filter((specimen) => specimen.parameter.includes(filterValue.parameter));
    }

    return data;

 }

  getFilters(data: any[]) {

    //var dates = Object.keys(data.reduce((r,{specimenDate}) => (r[specimenDate]='', r) , {}));

    var dates = Object.keys(data.reduce((r,{specimenDate}) => (r[new Date(specimenDate).getFullYear()]='', r) , {}));
    var parameters = Object.keys(data.reduce((r,{parameter}) => (r[parameter]='', r) , {}));
    var points = Object.keys(data.reduce((r,{point}) => (r[point]='', r) , {}));
    var laboratories = Object.keys(data.reduce((r,{laboratory}) => (r[laboratory]='', r) , {}));

    var filters = {
      "years": dates,
      "laboratories": laboratories,
      "locations": points,
      "parameters": parameters
    }

    // var filters = {
    //   "years": [2023,2024],
    //   "laboratories": ["CESPT", "PFEA", "SD County"],
    //   "points": ["Playas de Tijuana frente a rampa de acceso","Playas de Tijuana El Vigia", "Cañada Azteca", "El Faro"],
    //   "parameters": ["Coliformes Fecales", "Enterococos"]
    // }

    return filters;

  }

  // getAllData() {

  //   var data: any[] = [];

  //   data.push({
  //     "specimenDate": "01/02/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Coliformes Fecales",
  //     "value": 2400,
  //     "tendency": "",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/02/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Enterococos",
  //     "value": 110,
  //     "tendency": "Warning",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/02/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vigia",
  //     "parameter": "Coliformes Fecales",
  //     "value": 460,
  //     "tendency": "Warning",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/02/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vijua",
  //     "parameter": "Enterococos",
  //     "value": 171,
  //     "tendency": "Warning",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/08/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Coliformes Fecales",
  //     "value": 2400,
  //     "tendency": "Danger",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/08/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Enterococos",
  //     "value": 460,
  //     "tendency": "Warning",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-up",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/08/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vigia",
  //     "parameter": "Coliformes Fecales",
  //     "value": 2400,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-up",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/08/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vijua",
  //     "parameter": "Enterococos",
  //     "value": 359,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-up",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/15/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Coliformes Fecales",
  //     "value": 2400,
  //     "tendency": "Danger",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/15/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Enterococos",
  //     "value": 399,
  //     "tendency": "Warning",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/15/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vigia",
  //     "parameter": "Coliformes Fecales",
  //     "value": 2400,
  //     "tendency": "Danger",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/15/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vijua",
  //     "parameter": "Enterococos",
  //     "value": 52,
  //     "tendency": "Safe",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/22/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Coliformes Fecales",
  //     "value": 2400,
  //     "tendency": "Danger",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/22/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Enterococos",
  //     "value": 12997,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-up",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/22/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vigia",
  //     "parameter": "Coliformes Fecales",
  //     "value": 2400,
  //     "tendency": "Danger",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/22/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vijua",
  //     "parameter": "Enterococos",
  //     "value": 24196,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-up",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/29/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Coliformes Fecales",
  //     "value": 1100,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/29/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana frente a rampa de acceso",
  //     "parameter": "Enterococos",
  //     "value": 211,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "01/29/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vigia",
  //     "parameter": "Coliformes Fecales",
  //     "value": 240,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });
    
  //   data.push({
  //     "specimenDate": "01/29/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vijua",
  //     "parameter": "Enterococos",
  //     "value": 52,
  //     "tendency": "Safe",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "02/20/2024",
  //     "laboratory": "CESPT",
  //     "point": "Playas de Tijuana El Vijua",
  //     "parameter": "Enterococos",
  //     "value": 52,
  //     "tendency": "Safe",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });


  //   data.push({
  //     "specimenDate": "12/07/2023",
  //     "laboratory": "PFEA",
  //     "point": "Cañada Azteca",
  //     "parameter": "Enterococo",
  //     "value": 146,
  //     "tendency": "",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/07/2023",
  //     "laboratory": "PFEA",
  //     "point": "El Faro",
  //     "parameter": "Enterococo",
  //     "value": 146,
  //     "tendency": "",
  //     "tendencyIcon": "",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/14/2023",
  //     "laboratory": "PFEA",
  //     "point": "Cañada Azteca",
  //     "parameter": "Enterococo",
  //     "value": 41,
  //     "tendency": "SAFE",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/14/2023",
  //     "laboratory": "PFEA",
  //     "point": "El Faro",
  //     "parameter": "Enterococo",
  //     "value": 31,
  //     "tendency": "SAFE",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/21/2023",
  //     "laboratory": "PFEA",
  //     "point": "Cañada Azteca",
  //     "parameter": "Enterococo",
  //     "value": 2174,
  //     "tendency": "Danger",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-up",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/21/2023",
  //     "laboratory": "PFEA",
  //     "point": "El Faro",
  //     "parameter": "Enterococo",
  //     "value": 897,
  //     "tendency": "Warning",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-up",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/28/2023",
  //     "laboratory": "PFEA",
  //     "point": "Cañada Azteca",
  //     "parameter": "Enterococo",
  //     "value": 1081,
  //     "tendency": "Warning",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/28/2023",
  //     "laboratory": "PFEA",
  //     "point": "El Faro",
  //     "parameter": "Enterococo",
  //     "value": 1000,
  //     "tendency": "SAFE",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   data.push({
  //     "specimenDate": "12/28/2023",
  //     "laboratory": "SD County",
  //     "point": "Imperial Beach",
  //     "parameter": "Enterococo",
  //     "value": 1000,
  //     "tendency": "SAFE",
  //     "tendencyIcon": "fa-solid fa-arrow-trend-down",
  //     "validRange": "100 - 500"
  //   });

  //   return data;
  // }
  
}

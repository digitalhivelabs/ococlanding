import { Component, Input } from '@angular/core';
import { filterDataModel } from '../../_models/filterDataModel';
import { DatePipe } from '@angular/common';
import { range } from 'rxjs';
import { DashboardServiceService } from '../../_services/dashboard-service.service';

@Component({
  selector: 'app-specimen-summary',
  templateUrl: './specimen-summary.component.html',
  styleUrl: './specimen-summary.component.css'
})
export class SpecimenSummaryComponent {
  @Input() set dataFromFilter(data: any) {
    if (data) {
      //console.log('data received: ', data);
      this._summaryData[0] = this.getDataSummaryForLab("CESPT", data);
      this._summaryData[1] = this.getDataSummaryForLab("PFEA", data);
      this._summaryData[2] = this.getDataSummaryForLab("SD County", data);
    }
  }

  _summaryData: any[] = new Array(3);
  _currentLab = "";

  constructor(private _service: DashboardServiceService) {
    this._service.getDashboardInfo().subscribe({
      next: response => { 
        var allData = response; //this.getAllData(); //response 
        //console.log("summary ", allData);
        this._summaryData[0] = this.getDataSummaryForLab("CESPT", allData);
        this._summaryData[1] = this.getDataSummaryForLab("PFEA", allData);
        this._summaryData[2] = this.getDataSummaryForLab("SD County", allData);
    
      }
    });

    /*
    this._summaryData[0] = this.getDataSummaryForLab("CESPT", this.getAllData());
    this._summaryData[1] = this.getDataSummaryForLab("PFEA", this.getAllData());
    this._summaryData[2] = this.getDataSummaryForLab("SD County", this.getAllData());
    */
  }

  getDataSummaryForLab(lab: any, data: any) {
    var result: any;

    var filteredData = this.applyFilter(data, new filterDataModel("", lab, "", ""));

    if (filteredData.length <= 0)
      return null;

    var places = Object.keys(filteredData.reduce((r,{point}) => (r[point]='', r) , {})).length;
    var parameters = Object.keys(filteredData.reduce((r,{parameter}) => (r[parameter]='', r) , {}));
    var rangeDates = Object.keys(filteredData.reduce((r,{specimenDate}) => (r[specimenDate]='', r) , {}));
    
    var displayParameter = "";
    if (parameters.length > 1) 
      displayParameter = parameters.length + " Parameters";
    else
      displayParameter = parameters[0];

    var firstDate = rangeDates[0].substring(5,7) + "/01/" + rangeDates[0].substring(0,4);
    var lastDate = rangeDates[rangeDates.length-1].substring(5,7) + "/01/" + rangeDates[rangeDates.length-1].substring(0,4);

    var displayDate: any;

    if (firstDate == lastDate) {
      const datepipe: DatePipe = new DatePipe('en-US')
      displayDate = datepipe.transform(firstDate, 'MMM YYYY')
    }
    else {
      const datepipe: DatePipe = new DatePipe('en-US')
      displayDate = datepipe.transform(lastDate, 'MMM YYYY');
      displayDate = displayDate + " - ";
      displayDate = displayDate + datepipe.transform(firstDate, 'MMM YYYY');
    }

    result = {
      "id": 1,
      "title": lab,
      "place": places + " place(s)",
      "month": displayDate,
      "samples": filteredData.length + " specimens collected",
      "parameter": displayParameter,
    };

    //console.log(result);

    return result;
  }

  applyFilter(allData: any[], filterValue: filterDataModel) {

    var data = allData;

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


  getSummaryData() {

    var data: any[] = [];

    data.push({
      "id": 1,
      "title": "PFEA",
      "place": "3 Puntos (Tijuana)",
      "month": "Dec 2023",
      "samples": 4,
      "cvalue": 860.5,
      "parameter": "Enterococos",
      "percentage": 20,
      "legend": "Danger",
      "icon": ""
    });

    data.push({
      "id": 2,
      "title": "PFEA",
      "place": "El Faro",
      "month": "Dec 2023",
      "samples": 4,
      "cvalue": 368.5,
      "parameter": "Enterococos",
      "percentage": 40,
      "legend": "Danger",
      "icon": "fa-solid fa-arrow-trend-up"
    });

    data.push({
      "id": 3,
      "title": "CESPT",
      "place": "Playas de Tijuana frente a rampa",
      "month": "Ene 2024",
      "samples": 5,
      "cvalue": 2487.7,
      "parameter": "+1 Parameter",
      "percentage": 68,
      "legend": "Warning",
      "icon": "fa-solid fa-arrow-trend-up"
    });

    // data.push({
    //   "id": 4,
    //   "title": "CESPT",
    //   "place": "Playas de Tijuana El Vigia",
    //   "month": "Ene 2024",
    //   "samples": 5,
    //   "cvalue": 3273,
    //   "parameter": "+1 Parameter",
    //   "percentage": 95,
    //   "legend": "Safe",
    //   "icon": "fa-solid fa-arrow-trend-up"
    // });


    return data;

  }

  getAllData() {

    var data: any[] = [];

    data.push({
      "dateCollected": "01/02/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Coliformes Fecales",
      "value": 2400,
      "tendency": "",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/02/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Enterococos",
      "value": 110,
      "tendency": "Warning",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/02/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vigia",
      "parameter": "Coliformes Fecales",
      "value": 460,
      "tendency": "Warning",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/02/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vijua",
      "parameter": "Enterococos",
      "value": 171,
      "tendency": "Warning",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/08/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Coliformes Fecales",
      "value": 2400,
      "tendency": "Danger",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/08/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Enterococos",
      "value": 460,
      "tendency": "Warning",
      "tendencyIcon": "fa-solid fa-arrow-trend-up",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/08/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vigia",
      "parameter": "Coliformes Fecales",
      "value": 2400,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-up",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/08/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vijua",
      "parameter": "Enterococos",
      "value": 359,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-up",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/15/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Coliformes Fecales",
      "value": 2400,
      "tendency": "Danger",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/15/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Enterococos",
      "value": 399,
      "tendency": "Warning",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/15/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vigia",
      "parameter": "Coliformes Fecales",
      "value": 2400,
      "tendency": "Danger",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/15/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vijua",
      "parameter": "Enterococos",
      "value": 52,
      "tendency": "Safe",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/22/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Coliformes Fecales",
      "value": 2400,
      "tendency": "Danger",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/22/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Enterococos",
      "value": 12997,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-up",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/22/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vigia",
      "parameter": "Coliformes Fecales",
      "value": 2400,
      "tendency": "Danger",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/22/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vijua",
      "parameter": "Enterococos",
      "value": 24196,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-up",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/29/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Coliformes Fecales",
      "value": 1100,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/29/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana frente a rampa de acceso",
      "parameter": "Enterococos",
      "value": 211,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "01/29/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vigia",
      "parameter": "Coliformes Fecales",
      "value": 240,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });
    
    data.push({
      "dateCollected": "01/29/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vijua",
      "parameter": "Enterococos",
      "value": 52,
      "tendency": "Safe",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "02/20/2024",
      "responsible": "CESPT",
      "location": "Playas de Tijuana El Vijua",
      "parameter": "Enterococos",
      "value": 52,
      "tendency": "Safe",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });


    data.push({
      "dateCollected": "12/07/2023",
      "responsible": "PFEA",
      "location": "Cañada Azteca",
      "parameter": "Enterococo",
      "value": 146,
      "tendency": "",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/07/2023",
      "responsible": "PFEA",
      "location": "El Faro",
      "parameter": "Enterococo",
      "value": 146,
      "tendency": "",
      "tendencyIcon": "",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/14/2023",
      "responsible": "PFEA",
      "location": "Cañada Azteca",
      "parameter": "Enterococo",
      "value": 41,
      "tendency": "SAFE",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/14/2023",
      "responsible": "PFEA",
      "location": "El Faro",
      "parameter": "Enterococo",
      "value": 31,
      "tendency": "SAFE",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/21/2023",
      "responsible": "PFEA",
      "location": "Cañada Azteca",
      "parameter": "Enterococo",
      "value": 2174,
      "tendency": "Danger",
      "tendencyIcon": "fa-solid fa-arrow-trend-up",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/21/2023",
      "responsible": "PFEA",
      "location": "El Faro",
      "parameter": "Enterococo",
      "value": 897,
      "tendency": "Warning",
      "tendencyIcon": "fa-solid fa-arrow-trend-up",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/28/2023",
      "responsible": "PFEA",
      "location": "Cañada Azteca",
      "parameter": "Enterococo",
      "value": 1081,
      "tendency": "Warning",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/28/2023",
      "responsible": "PFEA",
      "location": "El Faro",
      "parameter": "Enterococo",
      "value": 1000,
      "tendency": "SAFE",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    data.push({
      "dateCollected": "12/28/2023",
      "responsible": "SD County",
      "location": "Imperial Beach",
      "parameter": "Enterococo",
      "value": 1000,
      "tendency": "SAFE",
      "tendencyIcon": "fa-solid fa-arrow-trend-down",
      "validRange": "100 - 500"
    });

    return data;
  }
  

}

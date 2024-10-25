import { Component, Input, OnInit } from '@angular/core';

import Chart, { ChartType } from 'chart.js/auto';
import { filterDataModel } from '../../_models/filterDataModel';
import { DatePipe } from '@angular/common';
import { DashboardServiceService } from '../../_services/dashboard-service.service';

@Component({
  selector: 'app-specimen-charts',
  templateUrl: './specimen-charts.component.html',
  styleUrl: './specimen-charts.component.css'
})
export class SpecimenChartsComponent {
  @Input() set dataFromFilter(data: any) {
    if (data) {
      //console.log('Data was setted: ', data, data.length);

      this._dataReceived =data;
      this.calculateSpecimenPoints("CESPT", data);
      this.createFinalChart("CESPT", data);

      this.calculateSpecimenPoints("PFEA", data);
      this.createFinalChart("PFEA", data);

      this.calculateSpecimenPoints("SD County", data);
      this.createFinalChart("SD County", data);

    }
  }

  _dataReceived: any[] = new Array(3);
  _yearsLab01: any[] = new Array(3);
  _specimenPoints: any = new Array(3);
  _currentFilterPoint: any = new Array(3);

  //public _charType1: ChartType = 'bar';
  _charType1: ChartType = 'bar';
  _charType2: ChartType = 'bar';
  _charType3: ChartType = 'bar';

  _chartTypes: ChartType[] = [ this._charType1, this._charType2, this._charType3];

  public chart: any;
  public chart02: any;
  public chart03: any;
  colors = ['#76c1ff', '#FFCCB6', '#ABDEE6', '#CBAACB', 'pink', 'cyan', 'orange', 'black', 'brown'];


  constructor(private _service: DashboardServiceService) {
    this._service.getDashboardInfo().subscribe({
      next: response => { 
        var allData = response; //this.getAllData(); //response 
        //console.log("charts ", allData);
        var lab = "CESPT";
        this.calculateSpecimenPoints(lab, allData);
        this._yearsLab01[0] = this.calculateFinalDate(lab, allData);
        this.prepareDataForChart(lab, allData);
        this._dataReceived = allData;
         this.createFinalChart(lab, allData);
    
        lab = "PFEA";
        this.calculateSpecimenPoints(lab, allData);
        this._yearsLab01[1] = this.calculateFinalDate(lab, allData);
        this.prepareDataForChart(lab, allData);
        this._dataReceived = allData;
        this.createFinalChart(lab, allData);
    
        var lab = "SD County";
        this.calculateSpecimenPoints(lab, allData);
        this._yearsLab01[2] = this.calculateFinalDate(lab, allData);
        this.prepareDataForChart(lab, allData);
        this._dataReceived = allData;
        this.createFinalChart(lab, allData);
    
      }
    });

  }

/*
  ngOnInit(): void {
    
    var data = this.getAllData();

    var lab = "CESPT";
    this.calculateSpecimenPoints(lab, data);
    this._yearsLab01[0] = this.calculateFinalDate(lab, data);
    this.prepareDataForChart(lab, data);
    this._dataReceived = data;
    this.createFinalChart(lab, data);


    lab = "PFEA";
    this.calculateSpecimenPoints(lab, data);
    this._yearsLab01[1] = this.calculateFinalDate(lab, data);
    this.prepareDataForChart(lab, data);
    this._dataReceived = data;
    this.createFinalChart(lab, data);

    var lab = "SD County";
    this.calculateSpecimenPoints(lab, data);
    this._yearsLab01[2] = this.calculateFinalDate(lab, data);
    this.prepareDataForChart(lab, data);
    this._dataReceived = data;
    this.createFinalChart(lab, data);


  }
*/
  onPointChanged(lab: string) {

    // console.log('Cambio punto de acceso');

    var currentPoint = "";

    if (lab == "CESPT")
    {
      currentPoint = this._currentFilterPoint[0];
      console.log("Data CESPT before filter: ", this._dataReceived);
      var dataCespt = this.applyFilter(this._dataReceived, new filterDataModel("", "CESPT", currentPoint, ""));
      console.log("Data CESPT after filter: ", dataCespt);
      this._yearsLab01[0] = this.calculateFinalDate("CESPT", dataCespt);
      var dataChart = this.getDataForChart(dataCespt);
      console.log("R124 : Data for CEST ", dataChart);
      var objsForChart = this.getArraysForChart(dataChart);
  
      this.createChart(objsForChart, "chardata01");
    }

    if (lab == "PFEA")
      {
        currentPoint = this._currentFilterPoint[1];
  
        var dataLab = this.applyFilter(this._dataReceived, new filterDataModel("", "PFEA", currentPoint, ""));
        this._yearsLab01[1] = this.calculateFinalDate("PFEA", dataLab);
        var dataChart = this.getDataForChart(dataLab);
        var objsForChart = this.getArraysForChart(dataChart);
    
        this.createChart(objsForChart, "chardata02");
      }

      if (lab == "SD County")
        {
          currentPoint = this._currentFilterPoint[2];
    
          var dataLab = this.applyFilter(this._dataReceived, new filterDataModel("", "SD County", currentPoint, ""));
          this._yearsLab01[1] = this.calculateFinalDate("SD County", dataLab);
          var dataChart = this.getDataForChart(dataLab);
          var objsForChart = this.getArraysForChart(dataChart);
      
          this.createChart(objsForChart, "chardata03");
        }
        
  }

  createFinalChart(lab: any, data: any[]) {

    var currentPoint = "";

    if (lab == "CESPT")
      currentPoint = this._currentFilterPoint[0];
    if (lab == "PFEA")
      currentPoint = this._currentFilterPoint[1];
    if (lab == "SD County")
      currentPoint = this._currentFilterPoint[2];

    var dataLab = this.applyFilter(data, new filterDataModel("", lab, currentPoint, ""));
    //var dataChart = this.getDataForChart(dataLab);
    //console.log("get data for chart ", dataLab);
    var objsForChart = this.getArraysForChart(dataLab);
    

    //console.log("current lab:", lab, objsForChart);
    if (lab == "CESPT")
      this.createChart(objsForChart, "chardata01");
    if (lab == "PFEA")
      this.createChart(objsForChart, "chardata02");
    if (lab == "SD County")
      this.createChart(objsForChart, "chardata03");

  }

  calculateSpecimenPoints(lab: any, data: any[])
  {
    //console.log("calculando points ", lab);
    if (lab == "CESPT")
    {
      this._specimenPoints[0] = this.getSpecimenPoints(lab, data);
      this._currentFilterPoint[0] = this._specimenPoints[0][0];  
    }
    if (lab == "PFEA")
    {
      this._specimenPoints[1] = this.getSpecimenPoints(lab, data);
      this._currentFilterPoint[1] = this._specimenPoints[1][0];  
    }
    if (lab == "SD County")
    {
        this._specimenPoints[2] = this.getSpecimenPoints(lab, data);
        this._currentFilterPoint[2] = this._specimenPoints[2][0];  
    }
    
    //console.error("Calculados:", lab, this._specimenPoints, this._currentFilterPoint);
    
  }

  calculateFinalDate(lab: any, data: any[]): string {

    var filteredData = this.applyFilter(data, new filterDataModel("", lab, "", ""));

    //console.log("Calculando final data", data, filteredData, lab);

    var rangeDates = Object.keys(filteredData.reduce((r,{specimenDate}) => (r[specimenDate]='', r) , {}));

    if (rangeDates.length <= 0)
      return "";
    
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

    return displayDate;


  }

  getSpecimenPoints(lab: any, data: any[]) {

    var filteredData = this.applyFilter(data, new filterDataModel("", lab, "", ""));
    //console.warn("filtered data on point ", lab, filteredData);
    var points = Object.keys(filteredData.reduce((r,{point}) => (r[point]='', r) , {}));

    //console.warn('POINTS', data, filteredData, points);

    return points;
  }

  createChart(data: any, chartId: string){

    //console.log('Chart id', chartId, this.chart);

    if (chartId == "chardata01")
    {
      //console.log('Contruyendo el chart 1');

      if (this.chart)
      {
          //console.log("destruyendo...");
          this.chart.destroy();
      }
        
  
      this.chart = new Chart(chartId, {
        type: this._chartTypes[0], //this denotes tha type of chart
  
        data: {// values on X-Axis
          labels: data.labels,
          datasets: data.datasets 
        },
        options: {
          aspectRatio:2.5,
          responsive: true
        }
        
      });
    }


    if (chartId == "chardata02")
    {
      //console.log('Contruyendo el chart 2');
      if (this.chart02)
        this.chart02.destroy();
  
      this.chart02 = new Chart(chartId, {
        type: this._chartTypes[1], //this denotes tha type of chart
  
        data: {// values on X-Axis
          labels: data.labels,
          datasets: data.datasets 
        },
        options: {
          aspectRatio:2.5,
          responsive: true
        }
        
      });
    }

    if (chartId == "chardata03")
      {
        //console.log('Contruyendo el chart 3', this._chartTypes[2], data);
        if (this.chart03)
          this.chart03.destroy();
    
        this.chart03 = new Chart(chartId, {
          type: this._chartTypes[2], //this denotes tha type of chart
    
          data: {// values on X-Axis
            labels: data.labels,
            datasets: data.datasets 
          },
          options: {
            aspectRatio:2.5,
            responsive: true
          }
          
        });
      }
  

    // this.chart02 = new Chart("chardata02", {
    //   type: 'bar', //this denotes tha type of chart

    //   data: {// values on X-Axis
    //     labels: ['2024-01-02', '2024-01-08', '2024-01-15','2024-01-22','2024-01-29' ], 
	  //      datasets: [
    //       {
    //         label: "Playas de Tij Frente a rampa",
    //         data: ['110','460', '399', '12997', '211'],
    //         backgroundColor: '#76c1ff'
    //       },
    //       {
    //         label: "Playas de Tij. El vigia",
    //         data: ['171', '359', '52', '24196', '52'],
    //         backgroundColor: '#2c5271'
    //       }  
    //     ]
    //   },
    //   options: {
    //     aspectRatio:2.5
    //   }
      
    // });

    // this.chart03 = new Chart("chardata03", {
    //   type: 'bar', //this denotes tha type of chart

    //   data: {// values on X-Axis
    //     labels: ['2024-01-02', '2024-01-08', '2024-01-15','2024-01-22','2024-01-29' ], 
	  //      datasets: [
    //       {
    //         label: "Playas de Tij Frente a rampa",
    //         data: ['110','460', '399', '12997', '211'],
    //         backgroundColor: '#76c1ff'
    //       },
    //       {
    //         label: "Playas de Tij. El vigia",
    //         data: ['171', '359', '52', '24196', '52'],
    //         backgroundColor: '#2c5271'
    //       }  
    //     ]
    //   },
    //   options: {
    //     aspectRatio:2.5
    //   }
      
    // });

  }

  prepareDataForChart(lab: any, data: any) {
    //var filter = new filterDataModel("2023", "PFEA", "", "");
    var filter = new filterDataModel("", lab, "", "");
    var resultData = this.applyFilter(data, filter);
    return this.getArraysForChart(resultData);
    //var dataChart = this.getDataForChart(resultData);
    //return this.getArraysForChart(dataChart);
  }

  getArraysForChart(data: any[]) {

    var results = {
      "labels": new Array(),
      "datasets": new Array(),
    }

    //console.log('before get arrays', data);

    if (data.length == 1) {
      results.labels = new Array();
      results.labels[0] = data[0].specimenDate;
    }
    else {
      results.labels = Object.keys(data.reduce((r,{specimenDate}) => (r[specimenDate]='', r) , {}));
    }
    
    //console.log("results labels", results, results.labels.length);
    if (results.labels.length > 6)
      results.labels = results.labels.slice(0, 6);

    var params = new Array();
    
    if (data.length == 1) {
      params = new Array(1);
      params[0] = data[0].parameter;
    } else {
      params = Object.keys(data.reduce((r,{parameter}) => (r[parameter]='', r) , {}));
    }

    //console.log('parameteros', params);

    for(let i=0;i<params.length ;i++){ 
      //console.log('parameter: ', params[i]);

      var filteredGroup = this.applyFilter(data, new filterDataModel("","","", params[i]));
      //console.log('Group: expected 5: ', filteredGroup);

      var values = new Array();
      
      if (data.length == 1) {
        values = new Array(1);
        values[0] = data[0].value;
      } else {
        values = Object.keys(data.reduce((r,{value}) => (r[value]='', r) , {}));
      }
      
      var values = filteredGroup.map(a => a.value);
      if (values.length > 6)
        values = values.slice(0,6);

      //console.log("Values expected 5: ", values, values.length);

      results.datasets.push({

          "label": params[i],
          "data": values,
          "backgroundColor": this.colors[i]

      });

      console.log("Values for char: ", results.datasets);

      
    }


    //console.log("reducido y simplificado: ", results);

    return results;

  }


  getDataForChart(data: any[]) {

    console.log("Reducing...", data);
    // if (data.length == 1)
    //   return data;

    //var result = Object.keys(data.reduce((r,{parameter}) => (r[parameter]='', r) , {}));


    const result = [...data.reduce((r, o) => {
      const key = o.specimenDate + '-' + o.parameter;
  
      const item = r.get(key) || Object.assign({}, o, {
        value: 0,
        instances: 0
      });
  
      item.value += o.value;
      item.instances += 1;

      return r.set(key, item);
      }, new Map).values()];

    result.forEach(function(itm) {
      itm.value = itm.value / itm.instances;
    });

    //console.log("Que estaba regresando: ", result);

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

  /*
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
*/

}

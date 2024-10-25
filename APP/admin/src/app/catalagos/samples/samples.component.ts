import { Component, OnInit } from '@angular/core';
import { DocumentsService } from '../../_services/documents.service';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-samples',
  templateUrl: './samples.component.html',
  styleUrl: './samples.component.css'
})
export class SamplesComponent implements OnInit{
  _currentOperation = "catalog";
  chart: any;
  chartLine: any;
  chartDonut: any;
  chartArea: any;
  charPolar: any;

  configPolar = {
    type: 'polarArea',
    data: {
      labels: [
        'Red',
        'Green',
        'Yellow',
        'Grey',
        'Blue'
      ],
      datasets: [{
        label: 'My First Dataset',
        data: [11, 16, 7, 3, 14],
        backgroundColor: [
          'rgb(255, 99, 132)',
          'rgb(75, 192, 192)',
          'rgb(255, 205, 86)',
          'rgb(201, 203, 207)',
          'rgb(54, 162, 235)'
        ]
      }]
    },
    options: {}
  };

  

  _editMode = false;
  currentModel: any = {
    id: 0,
    country: null,
    state: null,
    category: null,
    subCategory: null,
    place: null,
    point: null,
    comments: '',
    collectedDate: null
  };

  currentCountry: any = null;
  currentState: any = null;
  currentCategory: any = null;
  currentSubCategory: any = null;
  currentPlace: any = null;
  currentPoint: any = null;

  _data: any[] = [];
  _countries: any[] = [];
  _states: any[] = [];
  _categories: any[] = [];
  _subCategories: any[] = [];
  _places: any[] = [];
  _points: any[] = [];

  constructor(private _documentsService: DocumentsService) {}

  ngOnInit(): void {
    this.getAllData();
    this.createChart();
    this.createLineChart();
    this.createPolarChart();

    //this.createDonutChart();
  }

  getAllData() {
    this._data = this.getFakeData();
    this._countries = this.getFakeCountries();
    this._categories = this.getFakeCategories();
  }

  save() {
    this.currentModel.country = this.currentCountry;
    this.currentModel.state = this.currentState;
    this.currentModel.category = this.currentCategory;
    this.currentModel.subCategory = this.currentSubCategory;
    this.currentModel.place = this.currentPlace;
    this.currentModel.point = this.currentPoint;
   
    const model = this.cloneModel(this.currentModel);

    if (this._editMode) {


      let indexToUpdate = this._data.findIndex(item => item.id === model.id);
      this._data[indexToUpdate] = model;

      // this._documentsService.updateDocument(this.currentDocument).subscribe({
      //   next: response => { 
      //     //this.loadAllDocuments();
      //     this.resetValues();
      //   }
      // });

    } else {

      model.id = 12;
      this._data.splice(0,0,model);
      // this._documentsService.saveDocument(this.currentDocument).subscribe({
      //   next: response => { 
      //     //this.loadAllDocuments();
      //     this.resetValues();
      //   }
      // });
    }

    this._editMode = false;
    this.currentModel = this.resetValues();

  }

  cancel() {
    console.log('canceling...');
    this.currentModel = this.resetValues();
    this._editMode = false;
  }

  cloneModel<T extends object>(source: T): T {
    return {
      ...source,
    }
  }

  resetValues(): any{

    const model = {
      id: 0,
      country: null,
      state: null,
      category: null,
      subCategory: null,
      place: null,
      point: null,
      comments: '',
      collectedDate: null
    };

    //Clear sub selections.
    this._states = [];
    this._subCategories = [];
    this._places = [];
    this._points = [];

    this.currentCountry = null;
    this.currentState = null;
    this.currentCategory = null;
    this.currentSubCategory = null;
    this.currentPlace = null;
    this.currentPoint = null;
  
    return model;
  
  }

  edit(model: any) {
    this._editMode = true;
    this.currentModel = this.cloneModel(model);

    this.currentCountry = this.currentModel.country;

    this.getFakeStates(this.currentModel.country.id);
    let state = this._states.find(i => i.id === this.currentModel.state.id);
    this.currentState = state;

    this.currentCategory = this.currentModel.category;

    this.getFakeSubCategories(this.currentModel.category.id);
    let subCategory = this._subCategories.find(i => i.id === this.currentModel.subCategory.id);
    this.currentSubCategory = subCategory;

    this.getFakePlaces(this.currentModel.subCategory.id);
    let place = this._places.find(i => i.id === this.currentModel.place.id);
    this.currentPlace = place;

    this.getFakePoints(this.currentModel.subCategory.id);
    let point = this._points.find(i => i.id === this.currentModel.point.id);
    this.currentPoint = point;


    console.log('editing...', this.currentModel, this.currentModel.country);

    
  }


  countrySelected() {
    console.log('country was selected');
    this._states = this.getFakeStates(this.currentCountry.id);
  }

  categorySelected() {
    this._subCategories = this.getFakeSubCategories(this.currentCategory.id);
  }

  subCategorySelected() {
    this._places = this.getFakePlaces(this.currentSubCategory.id);
    this._points = this.getFakePoints(this.currentSubCategory.id);
  }




  //TODO: Fake Implementations

  getFakeData(): any[] {
    this._data.push({
      id:1,
      country: { id: 1, displayName: 'Mexico'},
      state: { id: 1, displayName: 'Baja California'},
      category: { id: 1, displayName: 'Water'},
      subCategory: { id: 1, displayName: 'Beaches'},
      place: { id: 1, displayName: 'El Faro'},
      point: { id: 1, displayName: 'Punto 1'},
      collectedDate: '2020-02-03',
      comments: 'Sample comments'
    });

    return this._data;

  }

  getFakeCountries(): any[] {
    this._countries.push({
      id: 1,
      displayName: 'Mexico'
    });
    this._countries.push({
      id: 2,
      displayName: 'USA'
    });

    return this._countries;
  } 

  getFakeStates(countryId: number): any[] {
    this._states = [];
    this._states.push({
      id: 1,
      displayName: 'Baja California'
    });
    this._states.push({
      id: 2,
      displayName: 'Sonora'
    });
    this._states.push({
      id: 3,
      displayName: 'CDMX'
    });

    return this._states;
  }

  getFakeCategories() {
    this._categories.push({
      id: 1,
      displayName: 'Water'
    });
    this._categories.push({
      id: 2,
      displayName: 'Air'
    });

    return this._categories;

  }

  getFakeSubCategories(categoryId: number): any[] {
    this._subCategories = [];
    this._subCategories.push({
      id: 1,
      displayName: 'Beaches'
    });
    this._subCategories.push({
      id: 2,
      displayName: 'Lakes'
    });
    this._subCategories.push({
      id: 3,
      displayName: 'Rivers'
    });

    return this._subCategories;
  }

  getFakePlaces(subCategoryId: number): any[] {
    this._places = [];
    this._places.push({
      id: 1,
      displayName: 'Plasyas de rosarito'
    });
    this._places.push({
      id: 2,
      displayName: 'Playas de tijuana'
    });
    this._places.push({
      id: 3,
      displayName: 'Stero Beach'
    });

    return this._places;
  }

  getFakePoints(subCategoryId: number): any[] {
    this._points = [];
    this._points.push({
      id: 1,
      displayName: 'Punto de referencia no 1'
    });
    this._points.push({
      id: 2,
      displayName: 'Punto de referencia no 2'
    });
    this._points.push({
      id: 3,
      displayName: 'Punto de referencia no 3'
    });

    return this._points;
  }

  createChart(){
  
    this.chart = new Chart("MyChart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['Ene.02.2024', 'Ene.08.2024', 'Ene.15.2024','Ene.22.2024',
								 'Ene.29.2024', ], 
	       datasets: [
          {
            label: "Coliformes Totales",
            data: ['2400','2400', '2400', '2400', '1100'],
            backgroundColor: 'blue'
          },
          {
            label: "Coliformes Fecales",
            data: ['2400', '2400', '2400', '2400', '1100'],
            backgroundColor: 'limegreen'
          },
          {
            label: "Enterococos",
            data: ['110', '460', '399', '12997', '211'],
            backgroundColor: 'pink'
          }  
        ]
      },
      options: {
        aspectRatio:2.5
      }
      
    });
  }  

  createAreaChart() {

  }

  createDonutChart() {
    this.chartDonut = {
      datasets: [{
          data: [10, 20, 30]
      }],
  
      // These labels appear in the legend and in the tooltips when hovering different arcs
      labels: [
          'Red',
          'Yellow',
          'Blue'
      ]
    };
  }

  createLineChart(){
  
    this.chartLine = new Chart("MyChartLine", {
      type: 'line', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['2022-05-10', '2022-05-11', '2022-05-12','2022-05-13',
								 '2022-05-14', '2022-05-15', '2022-05-16','2022-05-17', ], 
	       datasets: [
          {
            label: "pH",
            data: ['467','576', '572', '79', '92',
								 '574', '573', '576'],
            backgroundColor: 'blue'
          },
          {
            label: "e-Coli",
            data: ['542', '542', '536', '327', '17',
									 '0.00', '538', '541'],
            backgroundColor: 'limegreen'
          }  
        ]
      },
      options: {
        aspectRatio:2.5
      }
      
    });
  }

  createPolarChart(){
  
    this.chartLine = new Chart("MyChartPolar", {
      type: 'polarArea',
      data: {
          labels: ["Enero", "Febrero", "Marzo", 
                   "Abril", "Mayo"],
          datasets: [{
              data: [110, 197, 86, 20, 187],
              backgroundColor: ["#FF6384", 
                      "#36A2EB", "#FFCE56", 
                      "#4CAF50", "#9C27B0"],
          }]
      },
      options: {
          responsive: true,
          maintainAspectRatio: false,
      }      
    });
  }

  onReport() {
    this._currentOperation = "report";
  }

  onNew() {
    this._currentOperation = "catalog";
  }

  onSummary() {
    this._currentOperation = "summary";
    this.createChart();
  }


}

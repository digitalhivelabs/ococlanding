import { Component, OnInit } from '@angular/core';
import { ParametersService } from '../../_services/parameters.service';

@Component({
  selector: 'app-parameters',
  templateUrl: './parameters.component.html',
  styleUrl: './parameters.component.css'
})
export class ParametersComponent implements OnInit {

  _currentOperation = "catalog";

  _editMode = false;
  currentModel: any = {
    id: 0,
    name: '',
    description: '',
    minValue: 0,
    maxValue: 0,
    validDays: 0,
    location: null,
  };

  currentLocation: any = null;

  _data: any[] = [];
  _locations: any[] = [];

  
  constructor(private _parametersService: ParametersService) {}

  ngOnInit(): void {
    this.getAllData();
  }
  
  getAllData() {
    this._data = this.getFakeData();
    this._locations = this.getFakeLocations();
  }

  onReport() {
    this._currentOperation = "report";
  }

  onNew() {
    this._currentOperation = "catalog";
  }



  /* *********************/

  getFakeData(): any[] {
    this._data.push({
      id: 1,
      name: 'Oxigeno',
      description: 'Determina la cantidad de oxigeno que se encuentra por cm cubico en el agua',
      minValue: 10,
      maxValue: 80,
      validDays: 5,
      location: { id: 1, displayName: 'Playas de Tijuana'}
    });

    return this._data;

  }

  getFakeLocations(): any[] {
    this._locations.push({
      id: 1,
      displayName: 'Playas de Tijuana'
    });
    this._locations.push({
      id: 2,
      displayName: 'Payas de rosarito'
    });
    this._locations.push({
      id: 3,
      displayName: 'Ensenada'
    });

    return this._locations;
  } 

  save() {
    this.currentModel.location = this.currentLocation;
   
    const model = this.cloneModel(this.currentModel);

    if (this._editMode) {


      let indexToUpdate = this._data.findIndex(item => item.id === model.id);
      this._data[indexToUpdate] = model;

  //     this._parametersService.update(this.currentModel).subscribe({
  //       next: response => { 
  //         this.loadAllParameters();
  //         this.resetValues();
  //       }
  //     });

    } else {

      model.id = 12;
      this._data.splice(0,0,model);

  //     this._parametersService.save(this.currentModel).subscribe({
  //       next: response => { 
  //         this.loadAllParameters();
  //         this.resetValues();
  //       }
  //     });

    }

    this._editMode = false;
    this.currentModel = this.resetValues();

  }

  cancel() {
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
      name: '',
      description: '',
      minValue: 0,
      maxValue: 0,
      validDays: 0,
      location: null,
    };


    this.currentLocation = null;
  
    return model;
  
  }


  edit(model: any) {
    this._editMode = true;
    this.currentModel = this.cloneModel(model);

    this.currentLocation = this.currentModel.location;
    
  }
  

}




import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';

@Injectable({
  providedIn: 'root'
})
export class ParametersService {

  baseUrl = '';

  constructor(private http: HttpClient, private _shared: SharedService) { 
    this.baseUrl = this._shared.getEnviromentVariables()["parameters"];
  }

  getAll() {
    return this.http.get<Document>(this.baseUrl + 'parameters');
  }

  save(model: any) {
    
    return this.http.post<Document>(this.baseUrl + 'parameters', model);

  }

  update(model: any) {
    
    return this.http.put<Document>(this.baseUrl + 'parameters/' + model.id, model);

  }

}

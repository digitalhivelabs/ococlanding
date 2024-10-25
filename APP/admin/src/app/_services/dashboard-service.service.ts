import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';

@Injectable({
  providedIn: 'root'
})
export class DashboardServiceService {

  baseUrl = '';

  constructor(private http: HttpClient, private _shared: SharedService) { 
    this.baseUrl = this._shared.getEnviromentVariables()["dashboard"];
  }

  getDashboardInfo() {
    return this.http.get<any>(this.baseUrl);
  }

}

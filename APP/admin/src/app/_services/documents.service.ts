import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DocumentsService {
  baseUrl = '';

  constructor(private http: HttpClient, private _shared: SharedService) { 
    
    this.baseUrl = this._shared.getEnviromentVariables()["documents"];
  }

  getAllDocuments() {
    return this.http.get<Document>(this.baseUrl);
  }

  saveDocument(model: any) {
    
    return this.http.post<Document>(this.baseUrl + 'upload', model);

  }

  updateDocument(model: any) {
    
    return this.http.put<Document>(this.baseUrl, model);

  }


}

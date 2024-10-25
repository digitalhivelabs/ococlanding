import { Component, OnInit } from '@angular/core';
import { DocumentsService } from '../../_services/documents.service';

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrl: './documents.component.css'
})
export class DocumentsComponent implements OnInit {
  _currentOperation = "catalog";
  
  models: any;
  editModel = false;
  currentModel: any = {
    title: '',
    docType: '',
    abstrac: '',
    author: ''
  };


  constructor(private _documentsService: DocumentsService) {}
  
  ngOnInit(): void {
    this.loadAllDocuments();
  }

  loadAllDocuments() {

    console.log('loading documents...');

    this._documentsService.getAllDocuments().subscribe({
      next: response => { 
        console.log(response);
        this.models = response 
      }
    });
  }

  edit(doc: any) {
    doc.editMode = true;
    this.currentModel = doc;
  }

  update(doc: any) {
    doc.editMode = false;
  }

  cancelUpdate(doc: any) 
  {
    if (doc) doc.editMode = false;
    this.resetValues();
  }

  resetValues() {
    //console.log('reseting value...');
    this.currentModel = {
      title: '',
      docType: '',
      abstrac: '',
      author: ''
    };
  }

  save() {
    //console.log(this.currentDocument);
    if (this.currentModel.editMode) {
      this.currentModel.editMode = false;
      this._documentsService.updateDocument(this.currentModel).subscribe({
        next: response => { 
          this.loadAllDocuments();
          this.resetValues();
        }
      });
    } else {
      this._documentsService.saveDocument(this.currentModel).subscribe({
        next: response => { 
          this.loadAllDocuments();
          this.resetValues();
        }
      });
    }
  }

  onReport() {
    this._currentOperation = "report";
  }

  onNew() {
    this._currentOperation = "catalog";
  }



}


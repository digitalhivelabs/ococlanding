import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-frm-under-construction',
  templateUrl: './frm-under-construction.component.html',
  styleUrl: './frm-under-construction.component.css'
})
export class FrmUnderConstructionComponent {
  
  formName:any;

  constructor(private route:ActivatedRoute) {
    this.formName = this.route.snapshot.paramMap.get('formname');    

    this.route.paramMap.subscribe( paramMap => {
      this.formName = paramMap.get('formname');
    });
  }
  
}

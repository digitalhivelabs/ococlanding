import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-history',
  templateUrl: './history.page.html',
  styleUrls: ['./history.page.scss'],
})
export class HistoryPage implements OnInit {

  data: any[] = [];

  constructor() { }

  ngOnInit() {
    this.loadData();
  }

  private loadData(){
    this.data.push({"collectedDate": "2023.jan.23", "message": "+2 months", "stillValid":false});
    this.data.push({"collectedDate": "2023.feb.10", "message": "+2 months", "stillValid":true});
    this.data.push({"collectedDate": "2023.apr.22", "message": "+2 months", "stillValid":false});
    this.data.push({"collectedDate": "2023.jun.05", "message": "+2 months", "stillValid":true});
    this.data.push({"collectedDate": "2023.aug.10", "message": "+2 months", "stillValid":true});
  }

  getColor(value:boolean) {

    const successColor = 'success'; 
    const dangerColor = 'danger';
    
    var selectedColor = successColor;
    
    if (!value) selectedColor = dangerColor;

    return selectedColor;

  }


}

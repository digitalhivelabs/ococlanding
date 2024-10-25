import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent{
  showWelcome = true;
  _dataFiltered: any[] | undefined;
  _allData: any;

  onCloseWelcome() {
    this.showWelcome = false;
  }

  onFilterApplied(data: any) {
    this._dataFiltered = data;
  }


}

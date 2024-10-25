import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-details',
  templateUrl: './details.page.html',
  styleUrls: ['./details.page.scss'],
})
export class DetailsPage implements OnInit {

  data: any[] = [];

  constructor() { }

  ngOnInit() {
    this.data.push({"parameter":"Temperature","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Salinity","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Dissolved Oxygen","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"pH","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Turbidity","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Nutrients","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Chlorophyll-a","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Conductivity","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"TSS","value": this.getRandomIntInclusive(0,100)});//Total Suspended Solids
    this.data.push({"parameter":"Heavy Metals","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Oil and Grease","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Pathogens","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"Organic Compounds","value": this.getRandomIntInclusive(0,100)});
    this.data.push({"parameter":"B. Fauna & Flora","value": this.getRandomIntInclusive(0,100)});//Benthic Fauna and Flora
    this.data.push({"parameter":"Marine Debris","value": this.getRandomIntInclusive(0,100)});
  }

  private getRandomIntInclusive(min:number, max: number) : number
  {
    const minCeiled = Math.ceil(min);
    const maxFloored = Math.floor(max);
    return Math.floor(Math.random() * (maxFloored - minCeiled + 1) + minCeiled); // The maximum is inclusive and the minimum is inclusive
  }

  getStyle(value: number)
  {
    const successColor = '#43f94a';
    const warningColor = '#ffe047'
    const dangerColor = '#fb297b';
    
    var selectedColor = successColor;
    
    if (value < 70) selectedColor = warningColor;
    if (value < 50) selectedColor = dangerColor;


    return {'--clr' : selectedColor, '--i': value};
  }

  getClass(value:number) {
    var className = '';

    if (value < 50) className = "less";

    return className;
  }

}

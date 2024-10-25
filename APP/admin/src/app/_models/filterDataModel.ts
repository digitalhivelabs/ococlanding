import { filter } from "rxjs";

export class filterDataModel {
    
    constructor(year: string, laboratory: string, location: string, parameter: string) {
        this.year = year;        
        this.laboratory = laboratory;
        this.location = location;
        this.parameter = parameter;
    }
    
    year: string;
    
    laboratory: string;
    
    location: string;
    
    parameter: string;
}


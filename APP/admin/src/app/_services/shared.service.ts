import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }

  getEnviromentVariables() {

    //DEV Enviroment Variables.
    let apiUrls: ApiUrl = {};
    //apiUrls["account"] = "http://localhost:3000/";
    //apiUrls["documents"] = "http://localhost:3000/";
    //apiUrls["parameters"] = "http://localhost:3000/";

    //PROD Enviroment Variables.
    // apiUrls["account"] = "https://xpesdcompany-002-site3.ctempurl.com/api/Acount/";
    // apiUrls["base"] = "https://xpesdcompany-002-site3.ctempurl.com/api/";
    // apiUrls["users"] = "https://xpesdcompany-002-site3.ctempurl.com/api/Users/";
    // apiUrls["documents"] = "https://xpesdcompany-002-site3.ctempurl.com/api/Document/";
    // apiUrls["dashboard"] = "https://xpesdcompany-002-site3.ctempurl.com/api/Spesimens/dashboard";

    //https://onecoastonecommunity.org/ococ_api/api/Spesimens/dashboard
    apiUrls["account"] = "https://onecoastonecommunity.org/ococ_api/api/Acount/";
    apiUrls["base"] = "https://onecoastonecommunity.org/ococ_api/api/";
    apiUrls["users"] = "https://onecoastonecommunity.org/ococ_api/api/Users/";
    apiUrls["documents"] = "https://onecoastonecommunity.org/ococ_api/api/Document/";
    apiUrls["dashboard"] = "https://onecoastonecommunity.org/ococ_api/api/Spesimens/dashboard";


    return apiUrls;

  }
}

interface ApiUrl {
  [key: string]: string;
}

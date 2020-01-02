import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModel } from "src/app/shared/models/printing-editions/printingEditionModel";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {

  constructor(private http: HttpClient) { }

  get(printingEditionFilterState:PrintingEditionFilterModel):Observable<PrintingEditionModel>{
    return this.http.post<PrintingEditionModel>( environment.baseUrl + 'printingEdition/get',printingEditionFilterState)
  }

  create(printingEditionModel:PrintingEditionModel){
    return this.http.post( environment.baseUrl + 'printingEdition/create',printingEditionModel)
  }
}

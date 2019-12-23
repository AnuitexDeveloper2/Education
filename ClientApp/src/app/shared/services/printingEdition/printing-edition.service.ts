import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModel } from "src/app/shared/models/printing-editions/printingEditionModel";

@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {

  constructor(private http: HttpClient) { }

  get(printingEditionFilterState:PrintingEditionFilterModel):Observable<PrintingEditionModel>{
    return this.http.post<PrintingEditionModel>('https://localhost:44309/api/printingEdition/get',printingEditionFilterState)
  }

  create(printingEditionModel){
    return this.http.post('https://localhost:44309/api/printingEdition/get',printingEditionModel)
  }
}

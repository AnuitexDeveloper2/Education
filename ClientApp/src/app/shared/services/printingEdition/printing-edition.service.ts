import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModel } from "src/app/shared/models/printing-editions/printingEditionModel";
import { environment } from "src/environments/environment";
import { PrintingEditionModelItem } from '../../models/printing-editions/PrintingEditionModelItem';
import { BaseModel } from '../../models/Base/BaseModel';
import { AuthorModelItem } from '../../models/author/AuthorModelItem';

@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {

  constructor(private http: HttpClient) { }

  get(printingEditionFilterState:PrintingEditionFilterModel):Observable<PrintingEditionModel>{
    return this.http.post<PrintingEditionModel>( environment.baseUrl + 'printingEdition/get',printingEditionFilterState)
  }

  create(author:PrintingEditionModelItem) {
    debugger;
    return this.http.post( environment.baseUrl +`printingEdition/create/`,author,{withCredentials: true});
  }

  remove(id:number){
    return this.http.get(`https://localhost:44309/api/printingEdition/remove/?id=${id}`)
  }
}

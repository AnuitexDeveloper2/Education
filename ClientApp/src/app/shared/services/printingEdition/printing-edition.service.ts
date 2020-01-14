import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, BehaviorSubject } from "rxjs";
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

  printingEdition: PrintingEditionModelItem
  private dataSource = new BehaviorSubject(this.printingEdition);
  currentData = this.dataSource.asObservable();

  constructor(private http: HttpClient) { }

  changeMessage(data: PrintingEditionModelItem) {
    this.dataSource.next(data)
  }

  get(printingEditionFilterState:PrintingEditionFilterModel):Observable<PrintingEditionModel>{
    return this.http.post<PrintingEditionModel>( environment.baseUrl + 'printingEdition/get',printingEditionFilterState)
  }

  create(author:PrintingEditionModelItem) {
    debugger;
    return this.http.post( environment.baseUrl +`printingEdition/create/`,author,{withCredentials: true});
  }

  remove(id:number){
    return this.http.get(environment.baseUrl + `printingEdition/remove/?id=${id}`)
  }

    update(printingEdition: PrintingEditionModelItem) {
      return this.http.post(environment.baseUrl + 'printingEdition/update',printingEdition,{withCredentials: true});
    }
      
  }      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
 
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
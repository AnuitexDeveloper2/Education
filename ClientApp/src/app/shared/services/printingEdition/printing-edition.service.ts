import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModel } from 'src/app/shared/models/printing-editions/printingEditionModel';
import { environment } from 'src/environments/environment';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';

@Injectable({
  providedIn: 'root'
})
export class PrintingEditionService {

  printingEdition: PrintingEditionModelItem;

  constructor(private http: HttpClient) { }

  get(printingEditionFilterState: PrintingEditionFilterModel): Observable<PrintingEditionModel> {
    return this.http.post<PrintingEditionModel>( environment.baseUrl + 'printingEdition/get', printingEditionFilterState);
  }

  create(author: PrintingEditionModelItem) {
    return this.http.post( environment.baseUrl + `printingEdition/create/`, author);
  }

  remove(id: number) {
    return this.http.get(environment.baseUrl + `printingEdition/remove/?id=${id}`);
  }

    update(printingEdition: PrintingEditionModelItem) {
      return this.http.post(environment.baseUrl + 'printingEdition/update', printingEdition);
    }

  }

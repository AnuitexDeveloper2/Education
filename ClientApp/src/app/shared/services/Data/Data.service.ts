import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { PrintingEditionModelItem } from '../../models/printing-editions/PrintingEditionModelItem';
import { PrintingEditionSortType } from '../../enums/PrintingEditionSortType';

@Injectable()
export class DataService {

  printingEdition: PrintingEditionModelItem
  private dataSource = new BehaviorSubject(this.printingEdition);
  currentData = this.dataSource.asObservable();

  constructor() { }

  changeMessage(data: PrintingEditionModelItem) {
    this.dataSource.next(data)
  }

}
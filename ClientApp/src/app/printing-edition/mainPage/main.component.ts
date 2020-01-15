import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { Options } from 'ng5-slider';
import { Filter } from 'src/app/shared/constants/Filter';
import { PageEvent, MatSort } from '@angular/material';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { enumSelector, ListEnum } from 'src/app/Extention/EnumExtention';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { SortType } from 'src/app/shared/enums/SortType';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from "@angular/router";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  private filter: PrintingEditionFilterModel;
  mainForm: FormGroup;
  private count: number;
  private items: Array<PrintingEditionModelItem>;
  private type: string[];
  private minValue: number = Filter.zero;
  private maxValue: number = Filter.twoThousend;
  private options: Options;
  private stringEnums: string[];
  private currencyList: string[];
  private sortType: string[];
   @Output() SendValue = new EventEmitter<PrintingEditionModelItem>();
 
  constructor(private service: PrintingEditionService, private formBuilder: FormBuilder, public router: Router ) {
    this.mainForm = formBuilder.group({
      currency: [''],
      sortBy: ['']
    })
    this.SendValue = new EventEmitter<PrintingEditionModelItem>();
    this.filter = new PrintingEditionFilterModel();
    this.stringEnums = Array<string>();
    this.type = enumSelector(ProductType);
    this.currencyList = enumSelector(CurrencyType);
    this.sortType = enumSelector(SortType);
    this.options = {
      floor: Filter.zero,
      ceil: Filter.twoThousend
    };
  }

  ngOnInit() {
    this.filter.minPrice = Filter.zero,
    this.filter.maxPrice = Filter.oneThousand,
    this.filter.pageNumber = Filter.one;
    this.filter.pageSize = Filter.six;
    this.filter.currencyType = CurrencyType.USD;
    this.filter.typeProduct = [ Filter.zero,Filter.one,Filter.two];
    this.getBooks();
    this.filter.typeProduct = new Array<ProductType>();
  }

  getBooks() {
    return this.service.get(this.filter).subscribe(data=> {
      this.count = data.count;
      this.items = data.items;
    })
  }

  movePage(event: PageEvent) {
    this.filter.pageSize = event.pageSize;
    this.filter.pageNumber = event.pageIndex + Filter.one;
    this.getBooks();
  }

  applyFilter(filterValue: string) {
    debugger;
    this.filter.searchString = filterValue;
    this.getBooks();
  }

  priceFilter(minValue: number, maxValue: number) {
    debugger; 
    this.filter.minPrice = minValue;
    this.filter.maxPrice = maxValue;
    this.getBooks();
  }

  sort(value: string) {
    debugger;
    let test = parseInt(CurrencyType[this.mainForm.get('currency').value]);
    let test1 = parseInt(SortType[this.mainForm.get('sortBy').value]);
    this.filter.currencyType = parseInt(CurrencyType[this.mainForm.get('currency').value])
    this.filter.sortType = SortType.desc;
    this.getBooks();
  }

  filterBook(name: string) {
    this.filter.typeProduct.push(ProductType[name]);
    this.test(name);
    this.getBooks();
  }

  details(book:PrintingEditionModelItem){
      this.service.printingEdition = book;
      debugger;
      this.router.navigateByUrl('books/details')
  }

  private test  (name: string): number {
    let lenght = this.stringEnums.length;
    for (let index = 0; index < lenght ; index++) {
      const element = this.stringEnums[index];
      if (element == name) {
        this.stringEnums.splice(index,1);
        this.filter.typeProduct.splice(index,1);
        this.filter.typeProduct.pop();
        return index;
      }
    }
    
      this.stringEnums.push(name)
    return -1;
  }

 
}

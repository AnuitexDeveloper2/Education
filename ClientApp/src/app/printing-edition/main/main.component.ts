import { Component, OnInit } from '@angular/core';
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { Category } from 'src/app/shared/constants/category';
import { Options } from 'ng5-slider';
import { Filter } from 'src/app/shared/constants/Filter';
import { PageEvent } from '@angular/material';
import { ProductType } from 'src/app/shared/enums/ProductType';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  private filter: PrintingEditionFilterModel;
  private count: number;
  private items: Array<PrintingEditionModelItem>;
  private type: string[];
  private minValue: number = Filter.oneHundred;
  private maxValue: number = Filter.fourHundred;
  private options: Options;
  private Test: string[]
 
  constructor(private service: PrintingEditionService) {
    this.filter = new PrintingEditionFilterModel();
    this.Test = Array<string>();
    this.type = [ Category.Book,Category.Journal,Category.Newspaper ];
    this.options = {
      floor: Filter.zero,
      ceil: Filter.twoThousend
    };
  }

  ngOnInit() {
    this.filter.pageNumber = Filter.one;
    this.filter.pageSize = Filter.six;
    this.filter.TypeProduct = [ Filter.zero,Filter.one,Filter.two];
    this.getBooks();
    this.filter.TypeProduct = new Array<ProductType>();
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
    this.filter.searchString = filterValue;
    this.getBooks();
  }

  priceFilter(minValue: number, maxValue: number) {

  }

  filterBook(name: string) {
    debugger;
    if( name == Category.Book)
    {
      this.filter.TypeProduct.push(ProductType.Book);
    }
    
    if( name == Category.Journal){
      this.filter.TypeProduct.push(ProductType.Journal);
    }

    if (name == Category.Newspaper) {
      this.filter.TypeProduct.push(ProductType.Newspaper);
    }
    
    this.test(name);

    this.getBooks();
  }

  private test  (name: string): number {
    debugger;
    
    
    let lenght = this.Test.length;
    for (let index = 0; index < lenght ; index++) {
      const element = this.Test[index];
      if (element == name) {
        this.Test.splice(index,1);
        this.filter.TypeProduct.splice(index,1);
        this.filter.TypeProduct.pop();
        return index;
      }
    }
    
      this.Test.push(name)
    return -1;
  }

 
}

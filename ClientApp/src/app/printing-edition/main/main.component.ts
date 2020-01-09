import { Component, OnInit } from '@angular/core';
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { Category } from 'src/app/shared/constants/category';
import { Options } from 'ng5-slider';
import { Filter } from 'src/app/shared/constants/Filter';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  filter: PrintingEditionFilterModel;
  count: number;
  items: Array<PrintingEditionModelItem>;
  type: string[];
  minValue: number = Filter.oneHundred;
  maxValue: number = Filter.fourHundred;
  options: Options;
 
  constructor(private service: PrintingEditionService) {
    this.filter = new PrintingEditionFilterModel();
    this.type =    this.type = [Category.Book,Category.Journal,Category.Newspaper];
    this.options = {
      floor: Filter.zero,
      ceil: Filter.twoThousend
    };
  }

  ngOnInit() {
    this.filter.pageNumber = Filter.one;
    this.filter.pageSize = Filter.ten;
    this.filter.TypeProduct = [0,1,2];
    this.getBooks();
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
}

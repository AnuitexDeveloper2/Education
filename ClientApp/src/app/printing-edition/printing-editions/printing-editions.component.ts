import { Component, OnInit, Type } from '@angular/core';
import { PrintingEditionService } from "src/app/shared/services/printingEdition/printing-edition.service";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { Filter } from 'src/app/shared/constants/Filter';
import { RemoveComponent } from 'src/app/printing-edition/remove/remove.component';
import { PrintingEditionSortType } from 'src/app/shared/enums/PrintingEditionSortType';
import { Direction } from 'src/app/shared/constants/direction';
import { SortType } from 'src/app/shared/enums/SortType';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { enumSelector } from 'src/app/Extention/EnumExtention';

@Component({
  selector: 'app-printing-editions',
  templateUrl: './printing-editions.component.html',
  styleUrls: ['./printing-editions.component.css'],
  providers: [PrintingEditionService]
})
export class PrintingEditionsComponent implements OnInit {

  
  filter: PrintingEditionFilterModel;
  count: number;
  items: Array<PrintingEditionModelItem>;
  displayedColumns: string[];
  dataSource = new MatTableDataSource();
  type: string[];
  stringEnums: string[];
  

  constructor(private service: PrintingEditionService, private dialog: MatDialog ) {

   this.displayedColumns = [ ColumnName.id, ColumnName.Name, ColumnName.Description, ColumnName.Category, ColumnName.Authors, ColumnName.Price, ColumnName.Edit ];
   this.filter = new PrintingEditionFilterModel();
   this.type = enumSelector(ProductType);
   this.dataSource
   this.stringEnums = new Array<string>();
   }

  ngOnInit() {
    this.filter.minPrice = Filter.zero,
    this.filter.maxPrice = Filter.oneThousand,
    this.filter.TypeProduct = [0,1,2]
    this.filter.pageNumber = Filter.one;
    this.filter.pageSize = Filter.ten;
    this.getBooks();
    this.filter.TypeProduct = new Array<ProductType>();
  }

  getBooks() {
    return this.service.get(this.filter).subscribe(data => {
      this.count = data.count;
      this.items = data.items;
    })
  }

  create(printingEdition: PrintingEditionModelItem){
    const dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(() => this.getBooks());
  }

  remove(printingEdition: PrintingEditionModelItem){
    const dialogRef = this.dialog.open(RemoveComponent,{data:printingEdition}).afterClosed().subscribe(() => this.getBooks());
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

  edit(printingEdition: PrintingEditionModelItem) {
    const dialogRef = this.dialog.open(CreateComponent,{data:printingEdition}).afterClosed().subscribe(() => this.getBooks());
  }

  sort(event: MatSort) {
    this.filter.printingEditionSortType = PrintingEditionSortType[event.active];
    this.filter.sortType = SortType[event.direction];
    this.getBooks();
  }

  filterBook(name: string) {
    this.filter.TypeProduct.push(ProductType[name])
    this.test(name);
    this.getBooks();
  }

  private test  (name: string): number {
    let lenght = this.stringEnums.length;
    for (let index = 0; index < lenght ; index++) {
      const element = this.stringEnums[index];
      if (element == name) {
        this.stringEnums.splice(index,1);
        this.filter.TypeProduct.splice(index,1);
        this.filter.TypeProduct.pop();
        return index;
      }
    }
    
      this.stringEnums.push(name)
    return -1;
  }
}

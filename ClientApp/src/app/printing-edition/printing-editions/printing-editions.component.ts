import { Component, OnInit, Type } from '@angular/core';
import { PrintingEditionService } from "src/app/shared/services/printingEdition/printing-edition.service";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { Filter } from 'src/app/shared/constants/Filter';
import { RemoveComponent } from 'src/app/printing-edition/remove/remove.component';
import { Category } from 'src/app/shared/constants/category';
import { PrintingEditionSortType } from 'src/app/shared/enums/PrintingEditionSortType';
import { Direction } from 'src/app/shared/constants/direction';
import { SortType } from 'src/app/shared/enums/SortType';
import { ProductType } from 'src/app/shared/enums/ProductType';

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

  constructor(private service: PrintingEditionService, private dialog: MatDialog ) {

   this.displayedColumns = [ ColumnName.id, ColumnName.Name, ColumnName.Description, ColumnName.Category, ColumnName.Authors, ColumnName.Price, ColumnName.Edit ];
   this.filter = new PrintingEditionFilterModel();
   this.type = [Category.Book,Category.Journal,Category.Newspaper];
   this.dataSource
   }

  ngOnInit() {
    this.filter.TypeProduct = [0,1,2]
    this.filter.pageNumber = Filter.one;
    this.filter.pageSize = Filter.ten;
    this.getBooks();
  }

  getBooks(){
    return this.service.get(this.filter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
    })
  }

  create(){
    const dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(() => this.getBooks());
  }

  remove(printingEdition: PrintingEditionModelItem){
    debugger;
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
    if (event.active == ColumnName.id) {
      this.filter.printingEditionSortType = PrintingEditionSortType.Id;
    }

    if (event.active == ColumnName.Name) {
      this.filter.printingEditionSortType = PrintingEditionSortType.Title; 
    }

    if (event.active == ColumnName.Price) {
      this.filter.printingEditionSortType = PrintingEditionSortType.Price;
    }

    if (event.direction == Direction.Asc) {
      this.filter.sortType = SortType.Asc
    }

    if (event.direction == Direction.Desc) {
      this.filter.sortType = SortType.Desc
    }
    this.getBooks();
  }

  filterBook(name: string) {
    debugger;
    this.filter.TypeProduct = new Array<ProductType>();
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

    this.getBooks();
  }

}

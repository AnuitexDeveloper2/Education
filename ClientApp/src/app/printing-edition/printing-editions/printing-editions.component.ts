import { Component, OnInit } from '@angular/core';
import { PrintingEditionService } from "src/app/shared/services/printingEdition/printing-edition.service";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';
import { ColumnName } from 'src/app/shared/constants/column-name';
import { Filter } from 'src/app/shared/constants/Filter';
import { RemoveComponent } from 'src/app/printing-edition/remove/remove.component';
import { PrintingEditionModel } from 'src/app/shared/models/printing-editions/printingEditionModel';


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
  public dataSource = new MatTableDataSource();

  constructor(private service: PrintingEditionService, private dialog: MatDialog ) {

   this.displayedColumns = [ ColumnName.id, ColumnName.Name, ColumnName.Description, ColumnName.Category, ColumnName.Authors, ColumnName.Price, ColumnName.Edit ]
   this.filter = new PrintingEditionFilterModel();
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
    const dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe();
  }

  remove(printingEdition:PrintingEditionModelItem){
    const dialogRef = this.dialog.open(RemoveComponent,{data:printingEdition})
  }

}

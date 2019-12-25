import { Component, OnInit } from '@angular/core';
import { PrintingEditionService } from "src/app/shared/services/printingEdition/printing-edition.service";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import {PageEvent, MatSort, MatTableDataSource, MatDialog} from '@angular/material';
import { CreateComponent } from 'src/app/printing-edition/create/create.component';


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

   this.displayedColumns = ['id','name','description','category','authors','price','edit']
   this.filter = new PrintingEditionFilterModel();
   }

  ngOnInit() {
    this.filter.TypeProduct = [0,1,2]
    this.filter.pageNumber = 1;
    this.filter.pageSize = 10;
    this.getBooks();
  }

  getBooks(){
    return this.service.get(this.filter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
    })
  }

  create(){
    const dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(()=>this.getBooks())
  }

}

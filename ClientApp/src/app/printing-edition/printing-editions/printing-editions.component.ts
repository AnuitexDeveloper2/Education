import { Component, OnInit } from '@angular/core';
import { PrintingEditionService } from "src/app/shared/services/printingEdition/printing-edition.service";
import { PrintingEditionFilterModel } from 'src/app/shared/models/printing-editions/PrintingEditionFilterModel';
import { PrintingeditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';


@Component({
  selector: 'app-printing-editions',
  templateUrl: './printing-editions.component.html',
  styleUrls: ['./printing-editions.component.css'],
  providers: [PrintingEditionService]
})
export class PrintingEditionsComponent implements OnInit {


  filter: PrintingEditionFilterModel;
  count: number;
  items: Array<PrintingeditionModelItem>;
  displayedColumns: string[];

  constructor(private service:PrintingEditionService ) {

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
    debugger;
     this.service.get(this.filter).subscribe(data=>{
      this.count = data.count;
      this.items = data.items;
    });
  }

}

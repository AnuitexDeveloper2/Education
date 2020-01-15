import { Component, OnInit } from '@angular/core';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { Filter } from 'src/app/shared/constants/Filter';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
 
  amountList: number[];
  printingEdition: PrintingEditionModelItem;
  constructor(private service: PrintingEditionService) {
    this.printingEdition = new PrintingEditionModelItem();
    this.amountList =[Filter.one,2,3,4];
   }
  
  
  ngOnInit() {
     this.printingEdition = this.service.printingEdition;
  }
}

import { Component,Inject} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css']
})
export class RemoveComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: PrintingEditionModelItem, private printingEditionService:PrintingEditionService) { }
  
  remove(){
    debugger;
    this.printingEditionService.remove(this.data.id).subscribe
  }
}

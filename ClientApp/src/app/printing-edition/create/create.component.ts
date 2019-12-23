import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { PrintingEditionModel } from 'src/app/shared/models/printing-editions/printingEditionModel';
import { PrintingEditionModelItem } from "src/app/shared/models/printing-editions/PrintingEditionModelItem";
import { FormControl, FormControlDirective } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers:[PrintingEditionService]
})
export class CreateComponent {

  title = new FormControl();
  price = new FormControl();
  description = new FormControl();
  typeProduct = new FormControl();
  currency = new FormControl();

  constructor(@Inject(MAT_DIALOG_DATA) public data: string, private authorService:PrintingEditionService) { }
  
  save(){
    let printingEdition= new  PrintingEditionModelItem();
    this.authorService.create(printingEdition).subscribe();
  }

}

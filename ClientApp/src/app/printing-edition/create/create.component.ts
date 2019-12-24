import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { PrintingEditionModel } from 'src/app/shared/models/printing-editions/printingEditionModel';
import { PrintingEditionModelItem } from "src/app/shared/models/printing-editions/PrintingEditionModelItem";
import { FormControl, FormControlDirective } from '@angular/forms';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';

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
  authors = new FormControl();
  items = new Array<AuthorModelItem>();
  constructor(@Inject(MAT_DIALOG_DATA) public data: string, private service: PrintingEditionService,private authorService: AuthorService) { }
  
  authorsList = this.authorService.getAll().subscribe();
  save(){
    let printingEdition= new  PrintingEditionModelItem();
    this.service.create(printingEdition).subscribe((data:AuthorModel)=>
        this.items = data.items);
  }

}

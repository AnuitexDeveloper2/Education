import { Component, Inject,Input } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers:[PrintingEditionService]
})
export class CreateComponent {
    printingEdition: FormGroup;
    items = new Array<AuthorModelItem>();
    //regex = new RegExp("^[0-9]+$");


  constructor( private service: PrintingEditionService,private authorService: AuthorService,private formBuilder: FormBuilder) {
      this.printingEdition = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required, Validators.pattern('^[0-9]+$')]

    })
   }
  
  authorsList = this.authorService.getAll().subscribe((data:AuthorModel)=>
  this.items = data.items)
   
  categoryList = enumSelector(ProductType);

  currencyList = enumSelector(CurrencyType);
  save(){
    debugger;
    let model = new PrintingEditionModelItem();
    model.price = parseInt(this.printingEdition.get('price').value, 10);
    model.description = this.printingEdition.get('description').value;
    model.title = this.printingEdition.get('title').value;
    debugger
    this.service.create(model).subscribe();
  }

}
  export function enumSelector(definition) {
    let enumValues:Array<string>= [];
    for(let value in definition) {
        if(value.length>1) {
            enumValues.push(value);
        }
    }
    return enumValues;
}

import { Component, Inject,Input } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { Constants } from 'src/app/shared/constants/constants';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers:[PrintingEditionService]
})
export class CreateComponent {
    printingEdition: FormGroup;
    items = new Array<AuthorModelItem>();
    model: PrintingEditionModelItem;

  constructor( private service: PrintingEditionService,private authorService: AuthorService,private formBuilder: FormBuilder) {
      this.printingEdition = this.formBuilder.group({
      authors: [ Constants.emptyString,Validators.required ],
      title: [ Constants.emptyString, Validators.required ],
      description: [ Constants.emptyString, Validators.required ],
      currency: [ Constants.emptyString,Validators.required ],
      type: [ Constants.emptyString,Validators.required ],
      price: [ Constants.emptyString, Validators.pattern('^[0-9]+$') ]
    })
    this.model = new PrintingEditionModelItem();
   }
  
  authorsList = this.authorService.getAll().subscribe((data:AuthorModel)=>
  this.items = data.items)
   
  categoryList = enumSelector(ProductType);
  currencyList = enumSelector(CurrencyType);

  save(){
    debugger;
    this.model.price = this.printingEdition.get('price').value;
    this.model.authors.items = this.printingEdition.get('authors').value;
    this.model.currency = parseInt(CurrencyType[this.printingEdition.get('currency').value]);
    this.model.type = parseInt(ProductType[this.printingEdition.get('type').value]);
    this.model.description = this.printingEdition.get('description').value;
    this.model.title = this.printingEdition.get('title').value;
    this.service.create(this.model).subscribe();
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
 



    

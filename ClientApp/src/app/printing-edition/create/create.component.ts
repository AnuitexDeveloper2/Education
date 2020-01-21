import { Component, Inject,Input } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { Constants } from 'src/app/shared/constants/constants';
import { enumSelector } from "src/app/Extention/EnumExtention";

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers:[PrintingEditionService]
})
export class CreateComponent {
    printingEditionForm: FormGroup;
    items = new Array<AuthorModelItem>();
    model: PrintingEditionModelItem;

  constructor(@Inject(MAT_DIALOG_DATA) public data: PrintingEditionModelItem, private service: PrintingEditionService,private authorService: AuthorService,private formBuilder: FormBuilder) {
      this.printingEditionForm = this.formBuilder.group({
      authors: [ Constants.EmptyString,Validators.required ],
      title: [ Constants.EmptyString, Validators.required ],
      description: [ Constants.EmptyString, Validators.required ],
      currency: [ Constants.EmptyString,Validators.required ],
      type: [ Constants.EmptyString,Validators.required ],
      price: [ Constants.EmptyString, [Validators.required, Validators.pattern('^[0-9]+$')]]
    })
    this.model = new PrintingEditionModelItem();
   }
  
  authorsList = this.authorService.getAll().subscribe((data:AuthorModel)=>
  this.items = data.items)
   
  categoryList = enumSelector(ProductType);
  currencyList = enumSelector(CurrencyType);

  save() {
    debugger;
    this.model.price = this.printingEditionForm.get('price').value;
    this.model.authors = this.Map(this.printingEditionForm.get('authors').value);
    this.model.currency = parseInt(CurrencyType[this.printingEditionForm.get('currency').value]);
    this.model.type = parseInt(ProductType[this.printingEditionForm.get('type').value]);
    this.model.description = this.printingEditionForm.get('description').value;
    this.model.title = this.printingEditionForm.get('title').value;
    
    if(this.data != null) {
      this.model.id = this.data.id
      this.service.update(this.model).subscribe();
    }

    if (this.data == null) {
      this.service.create(this.model).subscribe();
    }
  }
 
  private Map(authorsName: Array<AuthorModelItem>) {
    let authorModel = new AuthorModel();
    authorModel.items = new Array<AuthorModelItem>();
    authorsName.forEach(element => {
      authorModel.items.push(element);     
   });
    
    return authorModel;
  }
}
  
 



    

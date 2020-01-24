import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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
    printingEdition: PrintingEditionModelItem;
    authorsList = this.authorService.getAll().subscribe((data:AuthorModel)=>
    this.items = data.items)
    categoryList = enumSelector(ProductType);
    currencyList = enumSelector(CurrencyType);

  constructor(@Inject(MAT_DIALOG_DATA) public data: PrintingEditionModelItem, private service: PrintingEditionService,private authorService: AuthorService,private formBuilder: FormBuilder) {
      this.printingEditionForm = this.formBuilder.group({
      authors: [ Constants.EmptyString,Validators.required ],
      title: [ Constants.EmptyString, Validators.required ],
      description: [ Constants.EmptyString, Validators.required ],
      currency: [ Constants.EmptyString,Validators.required ],
      type: [ Constants.EmptyString,Validators.required ],
      price: [ Constants.EmptyString, [Validators.required, Validators.pattern('^[0-9]+$')]]
    });
    this.printingEdition = new PrintingEditionModelItem();
  }

  save() {
    this.printingEdition = this.parseForm(this.printingEditionForm);

    if(this.data != null) {
      this.printingEdition.id = this.data.id
      this.service.update(this.printingEdition).subscribe();
    }

    if (this.data == null) {
      this.service.create(this.printingEdition).subscribe();
    }
  }
 
  private parseForm(data: FormGroup): PrintingEditionModelItem {
    let model = new PrintingEditionModelItem;
    model.price = this.printingEditionForm.get('price').value;
    model.authors = this.Map(this.printingEditionForm.get('authors').value);
    model.currency = parseInt(CurrencyType[this.printingEditionForm.get('currency').value]);
    model.type = parseInt(ProductType[this.printingEditionForm.get('type').value]);
    model.description = this.printingEditionForm.get('description').value;
    model.title = this.printingEditionForm.get('title').value;
    return model;
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
  
 
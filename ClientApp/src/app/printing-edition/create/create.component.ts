import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { PrintingEditionService } from 'src/app/shared/services/printingEdition/printing-edition.service';
import { PrintingEditionModel } from 'src/app/shared/models/printing-editions/printingEditionModel';
import { PrintingEditionModelItem } from "src/app/shared/models/printing-editions/PrintingEditionModelItem";
import { FormControl, FormControlDirective, FormGroup } from '@angular/forms';
import { AuthorService } from 'src/app/shared/services/author/author.service';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { AuthorModule } from 'src/app/author/author.module';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { PrintingEditionSortType } from 'src/app/shared/enums/PrintingEditionSortType';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers:[PrintingEditionService]
})
export class CreateComponent {

  printingEdition = new FormGroup({
    title: new FormControl,
    price: new FormControl,
    description: new FormControl,
    typeProduct: new FormControl,
    currency: new FormControl,
    authors: new FormControl,
  })
    items = new Array<AuthorModelItem>();
    
  constructor(@Inject(MAT_DIALOG_DATA) public data: string, private service: PrintingEditionService,private authorService: AuthorService) { }
  
  authorsList  =  this.authorService.getAll().subscribe((data:AuthorModel)=>
  this.items = data.items)
   
  categoryList = enumSelector(ProductType);

  currencyList = enumSelector(CurrencyType);
  save(){
    debugger;
    this.service.create(this.printingEdition.value).subscribe((data:AuthorModel)=>
        this.items = data.items);
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

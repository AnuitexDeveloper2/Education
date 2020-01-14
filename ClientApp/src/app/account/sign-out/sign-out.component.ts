import { Component } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Constants } from 'src/app/shared/constants/constants';
import { AccountService } from 'src/app/shared/services/account/account.service';
import { enumSelector } from 'src/app/Extention/EnumExtention';
import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { IDropdownSettings } from 'ng-multiselect-dropdown';


@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html',
  styleUrls: ['./sign-out.component.css'],
  providers: [AccountService]
})
export class SignOutComponent  {
  dropdownList: string[];
  selectedItems = [];
  dropdownSettings = {};
  ngOnInit() {
    this.dropdownList = enumSelector(ProductType); 
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true,
      defaultOpen: true,
      limitSelection: 2
    };
    
  }
  

}

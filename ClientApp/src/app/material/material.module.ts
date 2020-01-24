import { NgModule } from '@angular/core';

import {  MatButtonModule,
  MatPaginatorModule,
  MatTableModule,
  MatDialogModule,
  MatInputModule,
  MatSortModule,
  MatSlideToggleModule,
  MatSelectModule,
  MatFormFieldModule,
  MatTooltipModule,
  MatCheckboxModule,
  MatIconModule,
  MatSliderModule,
  MatGridListModule,
  MatMenuModule,
  MatRadioModule 
} from "@angular/material";

import { Ng5SliderModule } from 'ng5-slider';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { ModalModule } from "ng2-modal";

const MaterialComponent =[
 ModalModule,
 MatMenuModule,
 MatRadioModule,
 NgMultiSelectDropDownModule,
 Ng5SliderModule,
 MatSliderModule,
 MatGridListModule, 
 MatIconModule,
 MatCheckboxModule,
 MatPaginatorModule,
 MatTableModule,
 MatDialogModule,
 MatInputModule,
 MatSortModule,
 MatSlideToggleModule,
 MatSelectModule,
 MatFormFieldModule,
 MatTooltipModule,
 MatButtonModule
]


@NgModule({
  imports:[MaterialComponent],
  exports:[MaterialComponent]
})
export class MaterialModule { }

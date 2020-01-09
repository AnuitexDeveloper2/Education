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
  MatGridListModule
} from "@angular/material";

import { Ng5SliderModule } from 'ng5-slider';

const MaterialComponent =[
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

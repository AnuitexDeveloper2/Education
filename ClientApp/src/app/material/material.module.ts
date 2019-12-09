import { NgModule } from '@angular/core';
import { MatPaginatorModule } from '@angular/material';

const MaterialComponent =[
MatPaginatorModule
]


@NgModule({
  imports:[MaterialComponent],
  exports:[MaterialComponent]
})
export class MaterialModule { }

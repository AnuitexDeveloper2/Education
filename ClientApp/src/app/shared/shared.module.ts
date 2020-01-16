import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { ErrorComponent } from './components/error/error.component';
import { RemoveComponent } from './components/remove/remove.component';
import { MaterialModule } from '../material/material.module';


@NgModule({
  declarations: [ ErrorComponent, RemoveComponent],
  imports: [
    CommonModule,
    SharedRoutingModule,
    MaterialModule
  ]
})
export class SharedModule { }
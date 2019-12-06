import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {AccountModule} from '../app/account/account.module';
import { AdministratorModule } from './administrator/administrator.module';
import { AuthorModule } from './author/author.module';
import { OrderModule } from './order/order.module';
import { PrintingEditionModule } from './printing-edition/printing-edition.module';
import { SharedModule } from './shared/shared.module';
import { UserModule } from './user/user.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AccountModule,
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    AdministratorModule,
    AuthorModule,
    OrderModule,
    PrintingEditionModule,
    SharedModule,
    UserModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

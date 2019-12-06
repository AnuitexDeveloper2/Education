import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountModule} from '../app/account/account.module';
import { AdministratorModule } from './administrator/administrator.module';
import { AuthorModule } from './author/author.module';
import { OrderModule } from './order/order.module';
import { PrintingEditionModule } from './printing-edition/printing-edition.module';
import { SharedModule } from './shared/shared.module';
import { UserModule } from './user/user.module';
import { MaterialModule } from './material/material.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AlertsModule } from 'angular-alert-module';
import { AccountService } from './account/account.service';
import { AccountComponent } from './account/account/account.component';





@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AccountComponent,
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
    MaterialModule,
    NgbModule,   
    AlertsModule.forRoot(), 
      ],
  providers: [AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }

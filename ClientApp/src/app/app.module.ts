import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/header/header.component';
import { Router } from '@angular/router';
import { AccountModule } from './account/account.module';
import { CookieService } from 'ngx-cookie-service';
import { HttpClientModule } from '@angular/common/http';
import { UserModule } from "./user/user.module";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    AccountModule,
  ],
  
  providers: [
    CookieService,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(router:Router){}
}

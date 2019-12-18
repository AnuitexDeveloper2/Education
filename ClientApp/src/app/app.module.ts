import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/header/header.component';
import { Router } from '@angular/router';
import { AccountModule } from './account/account.module';
import { CookieService } from 'ngx-cookie-service';
import { HttpClientModule } from '@angular/common/http';
import { MatSelectModule  } from "@angular/material";
import { UserModule } from "./user/user.module";
import { MaterialModule } from "./material/material.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule  } from "@angular/platform-browser/animations";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationInterceptor } from "./shared/AuthenticationInterceptor";
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
  ],
  imports: [
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    UserModule,
    AccountModule,
    MatFormFieldModule,
    MatSelectModule 
  ],
  providers:[{
    provide:HTTP_INTERCEPTORS,
    useClass: AuthenticationInterceptor,
    multi:true,
  }],

   bootstrap: [AppComponent]
})
export class AppModule { 
  constructor(router:Router){}
}

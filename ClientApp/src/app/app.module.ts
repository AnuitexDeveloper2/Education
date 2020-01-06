import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AppComponent } from 'src/app/app.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { Router } from '@angular/router';
import { AccountModule } from 'src/app/account/account.module';
import { CookieService } from 'ngx-cookie-service';
import { HttpClientModule } from '@angular/common/http';
import { MatSelectModule  } from "@angular/material";
import { UserModule } from "src/app/user/user.module";
import { MaterialModule } from "src/app/material/material.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule  } from "@angular/platform-browser/animations";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthenticationInterceptor } from "./shared/AuthenticationInterceptor";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalModule } from "ng2-modal";
import { FooterComponent } from './shared/components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
      ],
  imports: [
    NgbModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    UserModule,
    AccountModule,
    MatSelectModule,
    ModalModule,
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

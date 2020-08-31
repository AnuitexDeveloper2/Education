import { BrowserModule, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AppComponent } from 'src/app/app.component';
import { Router } from '@angular/router';
import { BrowserAnimationsModule  } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './shared/components/header/header.component';
import { AccountModule } from 'src/app/account/account.module';
import { CookieService } from 'ngx-cookie-service';
import { UserModule } from 'src/app/user/user.module';
import { MaterialModule } from 'src/app/material/material.module';
import { FooterComponent } from 'src/app/shared/components/footer/footer.component';
import { OrderModule } from 'src/app/order/order.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CartModule } from 'src/app/cart/cart.module';
import { TokenInterceptorService } from 'src/app/shared/services/TokenInterceptor/token-interceptor.service';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
      ],
  imports: [
    NgbModule,
    MaterialModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    UserModule,
    AccountModule,
    OrderModule,
    SharedModule,
    CartModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptorService,
    multi: true,
  },
   CookieService,
   AuthenticationService, ],
   bootstrap: [AppComponent]
})
export class AppModule {
     constructor(router: Router) {}
}

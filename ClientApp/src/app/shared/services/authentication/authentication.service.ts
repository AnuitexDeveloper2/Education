import {Injectable} from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private cookieService: CookieService) { }

  getJwtToken(): string {
    let token = this.cookieService.get('AccessToken');
    return token;
  }
}

import {Injectable} from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationServiceService {

  constructor(private cookieService: CookieService) { }

  getJwtToken() : string {
    let token = this.cookieService.get('AccessToken');
    return token;
  }
}

import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()

export class AccontService {
    constructor(private http: HttpClient) { }

    

  ForgotPassword(email: string) {
      return this.http.get(`https://localhost:44309/api/account/forgotPassword?email=${email}`);
  }
}
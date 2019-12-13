import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

email:string;

  constructor(private http:HttpClient) { }

  get(){
    return this.http.get('https://localhost:44309/api/author/get?email={email}')
  }
}

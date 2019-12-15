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

  save(name:string) {
    return this.http.post(`https://localhost:44309/api/author/create/?name=${name}`,name,{withCredentials: true})
  }

  
  
}

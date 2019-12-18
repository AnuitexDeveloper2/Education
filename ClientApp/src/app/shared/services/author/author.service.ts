import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { BaseFilterModel } from 'src/app/shared/models/Base/BaseFilterModel';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

email:string;

  constructor(private http:HttpClient) { }

  get(authorFilterModel:BaseFilterModel):Observable<AuthorModel>{
    return this.http.post<AuthorModel>('https://localhost:44309/api/author/get',authorFilterModel)
  }

  save(name:string) {
    return this.http.post(`https://localhost:44309/api/author/create/?name=${name}`,{withCredentials: true});
  }

  
  
}

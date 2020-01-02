import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { BaseFilterModel } from 'src/app/shared/models/Base/BaseFilterModel';
import { AuthorModule } from 'src/app/author/author.module';
import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

email:string;

  constructor(private http:HttpClient) { }

  get(authorFilterModel:BaseFilterModel):Observable<AuthorModel>{
    return this.http.post<AuthorModel>( environment.baseUrl +'author/get',authorFilterModel)
  }

  save(author:AuthorModelItem) {
    return this.http.post( environment.baseUrl +`author/create/`,author,{withCredentials: true});
  }

  edit(id:number,name:string){
    return this.http.get(environment.baseUrl + `author/update/?id=${id}&name=${name}`)
  }

  remove(id:number){
    return this.http.get( environment.baseUrl + `author/remove/?id=${id}`)
  }

  getAll():Observable<AuthorModule>{
    debugger;
    return this.http.get(environment.baseUrl + 'author/getAll')
  }


  
  
}

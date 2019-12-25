import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { BaseFilterModel } from 'src/app/shared/models/Base/BaseFilterModel';
import { AuthorModule } from 'src/app/author/author.module';

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

  edit(id:number,name:string){
    return this.http.get(`https://localhost:44309/api/author/update/?id=${id}&name=${name}`)
  }

  remove(id:number){
    return this.http.get(`https://localhost:44309/api/author/remove/?id=${id}`)
  }

  getAll():Observable<AuthorModule>{
    debugger;
    return this.http.get('https://localhost:44309/api/author/getAll')
  }


  
  
}

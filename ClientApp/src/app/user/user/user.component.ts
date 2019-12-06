import { Component, OnInit } from '@angular/core';
import {UserService} from '../user.service'

@Component({
  selector: 'my-app',
  template: `<div class="panel">
      <div><input [(ngModel)]="name" placeholder = "Модель" />
          <button (click)="addItem(name)">Добавить</button>
      </div>
      <table>
          <tr *ngFor="let item of items">
              <td>{{item}}</td>
          </tr>
      </table>
  </div>`,
  providers: [UserService]
})
export class UserComponent implements OnInit {

  items: string[] = [];
  constructor(private userService: UserService){}
    
  ngOnInit(){

  }

}

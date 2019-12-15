import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/services/user.service'

export interface PeriodicElement {
  name: string;
 
  weight: number;
  symbol: string;
}
const ELEMENT_DATA: PeriodicElement[] = [
 
];

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrls: ['./get-users.component.css'],
  providers:[UserService]
})

export class GetUsersComponent implements OnInit {
  constructor(private userService:UserService) { }
  displayedColumns: string[] = [ 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;
  ngOnInit() {
  }

}

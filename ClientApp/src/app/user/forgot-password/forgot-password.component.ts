import { Component, OnInit } from '@angular/core';
import { UserService } from "../../shared/services/user.service";

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
  providers:[UserService]
})
export class ForgotPasswordComponent implements OnInit {

  email:string;
  constructor(private userService: UserService) { }
 forgot(){
   debugger;
   this.userService.forgotPassword(this.email).subscribe
 }

  ngOnInit() {
  }

}

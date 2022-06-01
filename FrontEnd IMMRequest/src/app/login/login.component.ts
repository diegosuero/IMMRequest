import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { Login } from "./../models/Login";
import { LoginService } from "./../services/login.service";
import { disableDebugTools } from '@angular/platform-browser';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private serivceLogin: LoginService,
    private router: Router) {
   }
   Mail = "";
   Password = "";
   

    
  ngOnInit() {
  }

  addLogin(): void {
    const login = new Login(
      this.Mail,this.Password
    );
    console.log(login);
    this.serivceLogin.postLogin(login).subscribe(
      (data: string) => this.result(data),
      (error: any) => alert(error.error)
    );
  }
  private result(data): void {
    localStorage.setItem("token", data);
    this.router.navigate(["/menuAdmins"]);
  }

  onKeyMail(event: any) {
    this.Mail = event.target.value ;
  }
  onKeyPassword(event: any) {
    this.Password = event.target.value ;
  }

}

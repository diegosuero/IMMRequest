import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'IMMRequest-app';


  isLogged(): boolean{
    return localStorage.getItem('token')!== null;
  }
  isNotLogged(): boolean{
    return localStorage.getItem('token')== null;
  }
}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-admins',
  templateUrl: './menu-admins.component.html',
  styleUrls: ['./menu-admins.component.css']
})
export class MenuAdminsComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }
  public logOff(): void{
    localStorage.removeItem('token');
    this.router.navigate([""])
  }
}

import { Component, OnInit } from '@angular/core';
import { AdminModel } from "./../models/AdminModel";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError, delay } from 'rxjs/operators';
import { AdministradoresService } from '../services/administradores.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
@Component({
  selector: 'app-administradores',
  templateUrl: './administradores.component.html',
  styleUrls: ['./administradores.component.css']
})
export class AdministradoresComponent implements OnInit {

  displayedColumns: string[] = ['id', 'nombre', 'email', 'password'];
  dataSource = [];
  constructor(private serviceAdmin: AdministradoresService, private router: Router) {}
  admin: AdminModel = new AdminModel(null,"","","");
  showAdd = false;
  display = false;
  Nombre = "";
  Mail = "";
  Password = "";
  id;
  
  ngOnInit() {
    this.cargarAdmins();
  }

  private cargarAdmins():void{
    this.serviceAdmin.getAdministradores().subscribe(
      ((data: Array<AdminModel>) => this.result(data)),
      ((error: any) => alert(error.error))
    );
    this.display=false;
  }

  private result(data: Array<AdminModel>): void {
    this.dataSource = data;
    
  }

private addAdmin():void{
 
  const admin = new AdminModel(null,this.Nombre,this.Mail,this.Password);
  this.serviceAdmin.postAdministradores(admin).subscribe(
    (data: string) => this.tellAdminAdded(data),
    (error: any) => alert(error.error)
  );
}

private tellAdminAdded(data){
  this.showAdd= false;
  alert("Id del nuevo Administrador: "+data);
  this.cargarAdmins();
}

private deleteAdministrador(id:Int32List):void{
  this.serviceAdmin.deleteAdministradores(id).subscribe(
    (data: string) => alert("Administrador eliminado correctamente"),
    (error: any) => this.cargarAdmins()
  );
  this.cargarAdmins();
}

private modificarAdmin():void{
  var administrador: AdminModel= new AdminModel(this.id,this.Nombre,this.Mail,this.Password);
  this.serviceAdmin.putAdministradores(this.id,administrador).subscribe(
    (data: any) => alert("Administrador modificado correctamente"),
    (error: any) => this.mostrarError(error)
  );
  
}

private mostrarError(error : any){
  this.cargarAdmins();
  alert(error.error);
}

private showModifier(element : any){
  this.admin=element;
  this.display = true;
  this.Nombre=element.nombre;
  this.Password=element.contrasena;
  this.Mail=element.email;
  this.id=element.id;
}

private changeShowAdd():void{
  this.showAdd = !this.showAdd;
}
}

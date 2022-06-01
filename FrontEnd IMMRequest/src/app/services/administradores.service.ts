import { Component, OnInit } from '@angular/core';
import { AdminModel } from "./../models/AdminModel";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdministradoresService {

  private WEB_API_URL: string = environment.apiUrl;
  private auth = localStorage.getItem("token");
  constructor(private _httpService: HttpClient) {}

  getAdministradores(): Observable<Array<AdminModel>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<Array<AdminModel>>(
      this.WEB_API_URL + "Administrador",
      httpOptions
    );
  }

  postAdministradores(admin: AdminModel): Observable<string> {
    const myHeaders = new HttpHeaders().set("auth",localStorage.getItem('token'));

    myHeaders.append("Accept", "application/text");

    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Administrador",
      admin,
      httpOptions
    );

  }

  putAdministradores(id:Int32Array ,admin: AdminModel): Observable<any> {
    const myHeaders = new HttpHeaders().set("auth",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    console.log(myHeaders);
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.put<string>(
      this.WEB_API_URL + "Administrador/"+id,
      admin,
      httpOptions
    );

    
  }

  deleteAdministradores(id: Int32List): Observable<string> {
    const myHeaders = new HttpHeaders().set("auth",localStorage.getItem('token'));

    myHeaders.append("Accept", "application/text");
    console.log(myHeaders);
    const httpOptions = {
      headers: myHeaders,
    };
     return this._httpService.delete<string>(
      this.WEB_API_URL + "Administrador/"+id ,
      httpOptions
    );
    }

}

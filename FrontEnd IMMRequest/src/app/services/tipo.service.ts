
import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';
import { Tipo } from '../models/Tipo';
import { TipoModel } from '../models/TipoModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TipoService {
  private WEB_API_URL: string = environment.apiUrl;
  constructor(private _httpService: HttpClient) { }
  tipo : Tipo;

  public postTipo(Tipo: TipoModel): Observable<string> {
    const myHeaders = new HttpHeaders().set("auth",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Tipo",
      Tipo,
      httpOptions
    );
  }

  public putTipo(Tipo: TipoModel): Observable<string> {
    const myHeaders = new HttpHeaders().set("auth",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.put<string>(
      this.WEB_API_URL + "Tipo",
      Tipo,
      httpOptions
    );
  }
}

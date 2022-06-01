import { Injectable } from '@angular/core';
import { Tema } from "./../models/tema";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TemaService {

  private WEB_API_URL: string = environment.apiUrl;
  constructor(private _httpService: HttpClient) {}
  public getTemas(): Observable<Array<Tema>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<Array<Tema>>(
      this.WEB_API_URL + "Tema",
      httpOptions
    );
  }

  public getTema(id: Int32Array): Observable<Tema> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<Tema>(
      this.WEB_API_URL + "Tema/" + id,
      httpOptions
    );
  }
}

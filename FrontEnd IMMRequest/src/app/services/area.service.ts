
import { Injectable } from '@angular/core';
import { Area } from "./../models/area";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AreaService {
  private WEB_API_URL: string = environment.apiUrl;
  constructor(private _httpService: HttpClient) {}

  public getAreas(): Observable<Array<Area>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<Array<Area>>(
      this.WEB_API_URL + "Area",
      httpOptions
    );
  }
}

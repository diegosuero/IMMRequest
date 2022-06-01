import { SolicitudModel } from "./../models/SolicitudModel";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';
import { Solicitud } from '../models/Solicitud';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {
  private WEB_API_URL: string = environment.apiUrl;
  constructor(private _httpService: HttpClient) { }

  public getSolicitudes(): Observable<Array<SolicitudModel>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<Array<SolicitudModel>>(
      this.WEB_API_URL + "Solicitud",
      httpOptions
    );
  }

  public getSolicitud(id: number): Observable<SolicitudModel> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };

    return this._httpService.get<SolicitudModel>(
      this.WEB_API_URL + "Solicitud/" + id,
      httpOptions
    );
  }

  public postSolicitud(Solicitud: SolicitudModel): Observable<string> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/text");
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Solicitud",
      Solicitud,
      httpOptions
    );
  }

  public putSolicitud(id: Int32List , Solicitud: Solicitud): Observable<string> {
    const myHeaders = new HttpHeaders().set("auth",localStorage.getItem('token'));
    myHeaders.append("Accept", "application/text");
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.put<string>(
      this.WEB_API_URL + "Solicitud/"+id,
      Solicitud,
      httpOptions
    );
  }
}

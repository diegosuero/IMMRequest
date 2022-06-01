import { SolicitudModel } from "./../models/SolicitudModel";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImportadorService {

  constructor(private _httpService: HttpClient) { }
  private WEB_API_URL: string = environment.apiUrl;

  public postImportador(path : string ,  aImportar : string, nombreImportador: string ): Observable<string> {
    const myHeaders = new HttpHeaders().set("path",path);
    myHeaders.append("Accept", "application/json");
    myHeaders.append("nombreImportador", nombreImportador);
    myHeaders.append("aImportar", aImportar);
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.post<string>(
      this.WEB_API_URL + "Importador",
      httpOptions
    );
  }

  public getImportadores(): Observable<Array<string>> {
    const myHeaders = new HttpHeaders();
    myHeaders.append("Accept", "application/json");
    const httpOptions = {
      headers: myHeaders,
    };
    return this._httpService.get<Array<string>>(
      this.WEB_API_URL + "Importador",
      httpOptions
    );
  }
}

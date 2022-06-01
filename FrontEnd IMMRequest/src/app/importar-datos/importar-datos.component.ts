import { Component, OnInit } from '@angular/core';
import { ImportadorService } from '../services/importador.service';

@Component({
  selector: 'app-importar-datos',
  templateUrl: './importar-datos.component.html',
  styleUrls: ['./importar-datos.component.css']
})
export class ImportarDatosComponent implements OnInit {

  private importadorService : ImportadorService;

  constructor(importadorService : ImportadorService) {
    this.importadorService = importadorService;
   }

  ruta : string="";
  Importador: string="";
  aImportar: string="";
  importadores : string[] = [];
  ngOnInit() {
    this.importadorService.getImportadores().subscribe(
      ((data: Array<string>) => this.importadores=data),
      ((error: any) => alert(error.error))
    );
  }





  public importar():void{
    this.importadorService.postImportador(this.ruta,this.aImportar,this.Importador).subscribe(
      ((data: string) => alert(data)),
      ((error: any) => alert(error.error))
    );
    this.ruta="";
    this.Importador="";
    this.aImportar="";
  }

}

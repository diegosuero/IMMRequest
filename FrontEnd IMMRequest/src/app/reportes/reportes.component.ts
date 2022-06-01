import { Component, OnInit } from '@angular/core';
import { SolicitudService } from '../services/solicitud.service';
import { SolicitudModel } from '../models/SolicitudModel';
import { DatePipe } from '@angular/common';
import { Solicitud } from '../models/Solicitud';
import { concat } from 'rxjs';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent implements OnInit {

  constructor(private serviceSolicitud: SolicitudService) { }

  ngOnInit() {
    this.serviceSolicitud.getSolicitudes().subscribe(
      ((data: Array<SolicitudModel>) => this.result(data)),
      ((error: any) => alert(error.message))
    );
  }
  private result(data: Array<SolicitudModel>): void {
    this.dataSource = data;
  }
  displayedColumns: string[] = ['id', 'email'];
  dataSource = [];
  listFilter = '';
  onoff = false;
  from:Date;
  to:Date;
  showreporte : boolean =false;

  onoffChange(): void {
    this.onoff = !this.onoff;
  }

  crearReporte():string[]{
    var ret : string[]=[];
    if(this.onoff){
      var solicitudesDelCliente = this.dataSource.filter((item: any) =>item.mail==this.listFilter);
      var solicitudesEntreFechas :Array<Solicitud> =[];
      var estados: string[]=[];
      solicitudesDelCliente.forEach(element => {
        if(Date.parse(element.fechaIngreso)>= this.from.getTime() && Date.parse(element.fechaIngreso)<= this.to.getTime()){
          if(!estados.includes(element.estado)){
            estados.push(element.estado);
            
          }
          solicitudesEntreFechas.push(element);
        }
      });
      estados.forEach(element => {
        ret.push(element+"("+this.cantidadSolicitudes(solicitudesEntreFechas,element)+") = ["+ this.numeroSolicitudes(solicitudesEntreFechas,element)+"]")
      })
    }else{
      var solicitudes = this.dataSource;
     
      var tipos: string[]=[];
      var solicitudesEntreFechas :Array<Solicitud> =[];
      solicitudes.forEach(element => {
        if(Date.parse(element.fechaIngreso)>= this.from.getTime() && Date.parse(element.fechaIngreso)<= this.to.getTime()){
          if(!tipos.includes(element.tipo.nombre)){
            tipos.push(element.tipo.nombre);
          }
          solicitudesEntreFechas.push(element);
        }
      });
      
      tipos.forEach(element => {
        ret.push(element+"("+this.cantidadSolicitudesPorTipo(solicitudesEntreFechas,element)+")");
      })
    }
    return this.ordenarLista(ret);
  }

  cantidadSolicitudes(solicitudes : Array<Solicitud>,estado:string):number{
    var ret : number=0; 
    solicitudes.forEach(element => {
        if(element.estado==estado){
          ret=ret+1;
        }
      });
      return ret;
  }

  cantidadSolicitudesPorTipo(solicitudes : Array<Solicitud>,tipo:string):number{
    var ret : number=0; 
    solicitudes.forEach(element => {
        if(element.tipo.nombre==tipo){
          ret=ret+1;
        }
      });
      return ret;
  }

  numeroSolicitudes(solicitudes : Array<Solicitud>,estado:string):string[]{
    var ret : string[]=[]; 
    solicitudes.forEach(element => {
        if(element.estado==estado){
          ret.push(element.id.toString())
        }
      }); 
      return ret;
  }

  ordenarLista(lista:Array<string>):string[]{
    var ret : string[]=[];
    var list : Array<String[]>  = [];
    lista.forEach(element => {
      var split : string[]= element.split('(');
      list.push(split); 
    });
    var sorted = list.sort(function(a, b) { 
      return a[1].charAt(0) > b[1].charAt(0) ? -1 : 1;
    });

    sorted.forEach(element => {
      ret.push(element[0]+"("+element[1]);
    });
    return ret;
  }
}

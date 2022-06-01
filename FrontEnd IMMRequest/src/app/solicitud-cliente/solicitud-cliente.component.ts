import { SolicitudModel } from "./../models/SolicitudModel";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { SolicitudService } from '../services/solicitud.service';
import {MatAccordion} from '@angular/material/expansion';
import { AreaService } from '../services/area.service';
import { TemaService } from '../services/tema.service';
import { Area } from '../models/Area';
import { Tema } from '../models/Tema';
import { Tipo } from '../models/Tipo';
import { CampoAdicional } from '../models/CampoAdicional';
import { CampoAicionalTexto } from '../models/CampoAicionalTexto';

@Component({
  selector: 'app-solicitud-cliente',
  templateUrl: './solicitud-cliente.component.html',
  styleUrls: ['./solicitud-cliente.component.css']
})
export class SolicitudClienteComponent implements OnInit {

  constructor(private serviveSolicitud: SolicitudService,private areaService :AreaService,private TemaService :TemaService) { }
  panelOpenState = false;
  ngOnInit() {
    this.areaService.getAreas().subscribe(
      ((data: Array<Area>) => this.resultArea(data)),
      ((error: any) => alert(error.error))
    );
  }
  dataSource = [];
  nroSolicitud=0;
  solicitud : SolicitudModel= new SolicitudModel("null","null");
  showSolicitud:boolean=false;
  nombreCliente:string="";
  mailCliente:string="";
  telefonoCliente="";
  detalleCliente="";
  seleccionotipo:boolean=false;

  dataSourceAreas=[];
  selectedArea :Area = new Area(null,null,null);
  selectedTema :Tema = new Tema(null,null,[]);
  selectedTipo :Tipo;
  listTema:Tema[]=[];
  listTipo:Tipo[]=[];
  camposAdicionales : Array<CampoAdicional>=[];

  public getSolicitudes():void{
    this.serviveSolicitud.getSolicitudes().subscribe(
      ((data: Array<SolicitudModel>) => this.result(data)),
      ((error: any) => alert(error.error))
    );
  }

  public resultArea(data:Array<Area>):void{
    this.dataSourceAreas = data;
  }

  public showCrear():boolean{
    return this.selectedTipo!==null;
  }

  public resultSolicitudById(data:SolicitudModel):void{
    this.solicitud=data;
    this.showSolicitud=true;
    console.log(this.solicitud);
  }

  public getSolicitud():void{
    this.serviveSolicitud.getSolicitud(this.nroSolicitud).subscribe(
      ((data: SolicitudModel) => this.resultSolicitudById(data)),
      ((error: any) => this.mostrarError(error))
    );
  }

  
  public mostrarError(error:any){
    alert(error.error);
    this.showSolicitud=false;
  }
  public result(data: Array<SolicitudModel>): void {
    this.dataSource = data;
    console.log(this.dataSource);

  }
  onKeySolicitud(event: any) {
    this.nroSolicitud = event.target.value ;
  }

  solicitudSeleccionada():boolean{
    return this.solicitud.nombre!=null;
  }

  public getTemas(area :Area):Tema[]{
    return area.temas;
  }

  public temaSeleccionado():void{
    console.log(this.selectedTema);
    this.TemaService.getTema(this.selectedTema.id).subscribe(
      ((data: Tema) => this.resultTema(data)),
      ((error: any) => alert(error.error))
    );
  }

  public getTipos():Tipo[]{
    this.TemaService.getTema(this.selectedTema.id).subscribe(
      ((data: Tema) => this.resultTema(data)),
      ((error: any) => alert(error.error))
    );
    return this.selectedTema.tipos;
  }
  public resultTema(data: Tema): void {
    this.listTipo = data.tipos;
  }

  public resultSolicitud(data :string):void{
    this.camposAdicionales=[];
    this.seleccionotipo=false;
    this.detalleCliente="";
    this.nombreCliente="";
    this.mailCliente="";
    this.telefonoCliente="";
    this.areaService.getAreas().subscribe(
      ((data: Array<Area>) => this.resultArea(data)),
      ((error: any) => alert(error.error))
    );
    this.selectedTema=null;
    this.selectedTipo=null;
    alert("Su numero de solicitud es " + data);
  }

  public crearSolicitud():void{
    var solicitud : SolicitudModel = new SolicitudModel(this.mailCliente,this.telefonoCliente);
    solicitud.nombre=this.nombreCliente;
    solicitud.detalle=this.detalleCliente;
    solicitud.area=this.selectedArea.nombre;
    solicitud.tema=this.selectedTema.nombre;
    solicitud.tipo=this.selectedTipo.nombre;
    solicitud.camposAdicionales=this.camposAdicionales;
    this.serviveSolicitud.postSolicitud(solicitud).subscribe(
      ((data: string) => this.resultSolicitud(data)),
      ((error: any) => alert(error.error))
    );;
    
  }

}

import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import { Area } from '../models/Area';
import { Tipo } from '../models/Tipo';
import { Tema } from '../models/Tema';
import { CampoAdicional } from '../models/CampoAdicional';
import { CampoAdicionalBoolean } from '../models/CampoAdicionalBoolean';
import { CampoAdicionalFecha } from '../models/CampoAdicionalFecha';
import { AreaService } from '../services/area.service';
import { TemaService } from '../services/tema.service';
import { TipoService } from '../services/tipo.service';
import { CampoAdicionalEntero } from '../models/CampoAdicionalEntero';
import { CampoAicionalTexto } from '../models/CampoAicionalTexto';
import { TipoModel } from '../models/TipoModel';


@Component({
  selector: 'app-administrar-tipos',
  templateUrl: './administrar-tipos.component.html',
  styleUrls: ['./administrar-tipos.component.css']
})
export class AdministrarTiposComponent implements OnInit {

  constructor(private areaService :AreaService,private TemaService :TemaService,private TipoService :TipoService) { }

  dataSource = [];

  selectedArea :Area = new Area(null,null,null);
  selectedTema :Tema = new Tema(null,null,[]);
  selectedTipo :Tipo;
  listTema:Tema[]=[];
  listTipo:Tipo[]=[];
  panelOpenState : Boolean;

  nombreTipo:string;
  nombreCampo:string;
  tipoActivo = true;
  camposAdicionales:CampoAdicional[] = [];

  cotaSuperior:Date;
  cotaInferior:Date;

  cotaInferiorEntero:Int32Array;
  cotaSuperiorEntero:Int32Array;

  listaValoresTexto:string[] = [];
  valortexto:string="";
  displayedColumns: string[] = ['Valor'];
  
  ngOnInit() {
    this.areaService.getAreas().subscribe(
      ((data: Array<Area>) => this.result(data)),
      ((error: any) => alert(error.error))
    );
  }

  public agregarCampoAdicionalBooleano():void{
    var campo = new CampoAdicionalBoolean(null,this.nombreCampo,"bool",false);
    this.camposAdicionales.push(campo);
    this.nombreCampo="";

  }

  public result(data: Array<Area>): void {
    this.dataSource = data;
    console.log(this.dataSource);

  }

  public agregarCampoAdicionalFecha():void{
    var campo = new CampoAdicionalFecha(null,this.nombreCampo,"fecha",this.cotaInferior,this.cotaSuperior);
    this.camposAdicionales.push(campo);
    this.nombreCampo="";
  }

  public agregarCampoAdicionalEntero():void{
    var campo = new CampoAdicionalEntero(null,this.nombreCampo,"entero",this.cotaInferiorEntero,this.cotaSuperiorEntero);
    this.camposAdicionales.push(campo);
    this.nombreCampo="";
  }

  public agregarCampoAdicionalTexto():void{
    var campo = new CampoAicionalTexto(null,this.nombreCampo,"fecha",this.listaValoresTexto,null);
    this.camposAdicionales.push(campo);
    this.listaValoresTexto=[];
    this.nombreCampo="";
  }
  public areaChanged():void{
    console.log(this.nombreTipo);
  }

  public agregarValor():void{
    this.listaValoresTexto.push(this.valortexto);
    this.valortexto="";
    console.log(this.listaValoresTexto);
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

  public agregarTipo():void{
    var Tipo: TipoModel= new TipoModel(this.selectedArea.nombre,this.selectedTema.nombre,this.nombreTipo,[],this.tipoActivo);
    console.log(Tipo);
    this.TipoService.postTipo(Tipo).subscribe(
      ((data: string) => alert(data)),
      ((error: any) => alert(error.error))
    );
    
  }
  public modifyTipo():void{
    var tipo : TipoModel = new TipoModel(this.selectedArea.nombre,this.selectedTema.nombre,this.selectedTipo.nombre,[],this.tipoActivo);
    console.log(tipo);
    this.TipoService.putTipo(tipo).subscribe(
      ((data: string) => alert(data)),
      ((error: any) => alert(error.error))
    );

  }

  public tipoSeleccionado():void{
    this.tipoActivo=this.selectedTipo.activo;
    console.log(this.selectedTipo.activo);
  }

  
  

  


}

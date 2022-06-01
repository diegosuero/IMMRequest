import { Component, OnInit } from '@angular/core';
import { SolicitudService } from '../services/solicitud.service';
import { SolicitudModel } from '../models/SolicitudModel';
import { Solicitud } from '../models/Solicitud';

@Component({
  selector: 'app-solicitud-administradores',
  templateUrl: './solicitud-administradores.component.html',
  styleUrls: ['./solicitud-administradores.component.css']
})
export class SolicitudAdministradoresComponent implements OnInit {

  constructor(private serviceSolicitud: SolicitudService) {

   }
   displayedColumns: string[] = ['id', 'email','nombre','estado','descripcion'];
   dataSource = [];
   display:boolean=false;
   selectedSol :SolicitudModel;
   selectedId :Int32Array;
   selectedEstado:string;
   descripcionNueva:string;
   estados:string[]=['Creada','En revisión','Aceptada','Denegada','Finalizada'];
  ngOnInit() {
    this.serviceSolicitud.getSolicitudes().subscribe(
      ((data: Array<SolicitudModel>) => this.result(data)),
      ((error: any) => alert(error.error))
    );
  }

  private result(data: Array<SolicitudModel>): void {
    this.dataSource = data;
  }

  public selectedSolicitud(selectedSol : SolicitudModel):void{
    this.selectedSol=selectedSol;
    this.display=true;
  }
  public modificarSolicitud():void{
    this.display=false;
    var solicitud : Solicitud= new Solicitud("das","dsa");
    solicitud.descripcion=this.descripcionNueva;
    solicitud.estado=this.selectedEstado;
    solicitud.camposAdicionales=[];
    this.serviceSolicitud.putSolicitud(this.selectedSol.id,solicitud).subscribe(
      ((data: string) => this.mostrarID(data)),
      ((error: any) => alert(error.error))
    );
  }
  private mostrarID(string:string):void{
    alert(string);
    this.serviceSolicitud.getSolicitudes().subscribe(
      ((data: Array<SolicitudModel>) => this.result(data)),
      ((error: any) => alert(error.error))
    );

  }

}

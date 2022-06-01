import { Area } from './Area';
import { Tema } from './Tema';
import { Tipo } from './Tipo';
import { CampoAdicional } from './CampoAdicional';

export class SolicitudModel {
    id : Int32Array;
    nombre: string;
    mail: string;
    detalle: string;
    descripcion: string;
    estado: string;
    telefono: string;
    area :string;
    tema : string;
    tipo : string;
    camposAdicionales:Array<CampoAdicional>;
    fechaIngreso:Date;
  
    constructor(mail:string, telefono:string){
        this.mail = mail;
        this.telefono = telefono;
    }
  }
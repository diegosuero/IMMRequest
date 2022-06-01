import { Area } from './Area';
import { Tema } from './Tema';
import { Tipo } from './Tipo';
import { CampoAdicional } from './CampoAdicional';

export class Solicitud {
    id : Int32Array;
    nombre: string;
    mail: string;
    detalle: string;
    descripcion: string;
    estado: string;
    telefono: string;
    area :Area;
    tema : Tema;
    tipo : Tipo;
    camposAdicionales:Array<CampoAdicional>;
    fechaIngreso:Date;
  
    constructor(mail:string, telefono:string){
        this.mail = mail;
        this.telefono = telefono;
        this.descripcion = "";
        this.camposAdicionales=[];
    }
  }
import { CampoAdicional } from './CampoAdicional';

export class Tipo {
    id : Int32Array;
    nombre: string;
    activo: boolean;
    campos: Array<CampoAdicional>;
   
  
    constructor(id:Int32Array, nombre:string,campos: Array<CampoAdicional>,activo: boolean){
        this.activo = activo;
        this.nombre = nombre;
        this.id = id;
        this.campos = campos;
    }
  }
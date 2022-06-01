import { Tema } from './Tema';
import { CampoAdicional } from './CampoAdicional';
export class CampoAdicionalFecha implements CampoAdicional {
    id : Int32Array;
    nombre: string;
    tipo :string;
    cotaInferior : Date;
    cotaSuperior : Date;
    constructor(id:Int32Array, nombre:string,tipo :string,cotaInferior : Date,cotaSuperior : Date){
      this.id =id;
      this.nombre =nombre;
      this.tipo =tipo;
      this.cotaInferior =cotaInferior;
      this.cotaSuperior =cotaSuperior;
    };
  }
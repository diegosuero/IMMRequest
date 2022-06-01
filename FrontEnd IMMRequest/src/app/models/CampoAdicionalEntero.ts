import { Tema } from './Tema';
import { CampoAdicional } from './CampoAdicional';
export class CampoAdicionalEntero implements CampoAdicional{
    id : Int32Array;
    nombre: string;
    tipo :string;
    cotaInferior:Int32Array;
    cotaSuperior:Int32Array;
    constructor(id:Int32Array, nombre:string,tipo :string,cotaInferior:Int32Array,cotaSuperior:Int32Array){
      this.id=id;
      this.nombre=nombre;
      this.tipo=tipo;
      this.cotaInferior=cotaInferior;
      this.cotaSuperior=cotaSuperior;
    };
  }
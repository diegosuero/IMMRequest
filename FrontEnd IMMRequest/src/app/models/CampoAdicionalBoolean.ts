import { Tema } from './Tema';
import { CampoAdicional } from './CampoAdicional';
export class CampoAdicionalBoolean implements CampoAdicional {
    id : Int32Array;
    nombre: string;
    tipo :string;
    valor : boolean;
    constructor(id:Int32Array, nombre:string,tipo :string,valor : boolean){
      this.id = id;
      this.nombre = nombre;
      this.tipo = tipo;
      this.valor = valor;
    };
  }
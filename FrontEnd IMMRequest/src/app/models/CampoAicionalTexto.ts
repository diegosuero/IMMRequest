import { Tema } from './Tema';
import { CampoAdicional } from './CampoAdicional';
export class CampoAicionalTexto implements CampoAdicional {
    id : Int32Array;
    nombre: string;
    tipo :string;
    valores :string[];
    valor:string;
    constructor(id:Int32Array, nombre:string,tipo :string,valores :string[],valor:string){
      this.id=id;
      this.nombre=nombre;
      this.tipo=tipo;
      this.valores=valores;
      this.valor=valor;
    };
  }
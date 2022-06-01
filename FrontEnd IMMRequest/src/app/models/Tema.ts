import { Tipo } from './Tipo';

export class Tema {
    id : Int32Array;
    nombre: string;
    tipos : Array<Tipo>;
  
    constructor(id:Int32Array, nombre:string,tipos : Array<Tipo>){
        this.nombre = nombre;
        this.id = id;
        this.tipos = tipos;
    }
  }
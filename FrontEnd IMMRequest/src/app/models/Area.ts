import { Tema } from './Tema';
export class Area {
    id : Int32Array;
    nombre: string;
    temas :Array<Tema>;
   
  
    constructor(id:Int32Array, nombre:string,temas :Array<Tema>){
        this.nombre = nombre;
        this.id = id;
        this.temas = temas;
    }
  }
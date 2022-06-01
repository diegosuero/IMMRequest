export class AdminModel {
    id : Int32Array;
    nombre: string;
    contrrasena: string;
    email: string;
   
  
    constructor(id:Int32Array, nombre:string,email:string,contrasena:string){
        this.email = email;
        this.nombre = nombre;
        this.id = id;
        this.contrrasena = contrasena;
    }
  }
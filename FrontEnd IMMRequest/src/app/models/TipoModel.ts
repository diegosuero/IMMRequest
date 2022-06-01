import { CampoAdicional } from './CampoAdicional';

export class TipoModel {
    id : Int32Array;
    area: string;
    tema: string;
    tipo: string;
    activo: boolean;
    camposAdicionales: Array<CampoAdicional>;
  
    constructor(area:string, tema:string,tipo: string,campos: Array<CampoAdicional>,activo: boolean){
        this.area = area;
        this.tema = tema;
        this.tipo = tipo;
        this.camposAdicionales = campos;
        this.activo = activo;
    }
  }
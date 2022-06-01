import { Pipe, PipeTransform } from '@angular/core';
import { SolicitudModel } from '../models/SolicitudModel';

@Pipe({
  name: 'entreFechas'
})
export class EntreFechasPipe implements PipeTransform {

  transform(list: Array<SolicitudModel>, from:Date,to:Date): Array<SolicitudModel> {
    return list.filter(
      x => x.fechaIngreso>=from && x.fechaIngreso<= to
    );
  }

}

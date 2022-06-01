import { Pipe, PipeTransform } from '@angular/core';
import { Tipo } from '../models/Tipo';

@Pipe({
  name: 'tipoActivos'
})
export class TipoActivosPipe implements PipeTransform {

  transform(list: Array<Tipo>): Array<Tipo> {
    return list.filter(
      x => x.activo==true
    );
  }

}

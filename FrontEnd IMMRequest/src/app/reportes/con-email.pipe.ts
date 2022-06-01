import { Pipe, PipeTransform } from '@angular/core';
import { SolicitudModel } from '../models/SolicitudModel';

@Pipe({
  name: 'conEmail'
})
export class ConEmailPipe implements PipeTransform {

  transform(list: Array<SolicitudModel>, email:string): Array<SolicitudModel> {
    return list.filter(
      x => x.mail.toLocaleLowerCase()
      .includes(email.toLocaleLowerCase()
    ));
  }

}

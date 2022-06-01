import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'solicitudDate'
})
export class SolicitudDatePipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    return null;
  }

}

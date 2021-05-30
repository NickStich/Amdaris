import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'typePipe'
})
export class TypePipePipe implements PipeTransform {

  transform(type: number): string {
    if (type === 2) {
      return 'Supplier';
    }
    if (type === 1) {
      return 'Customer';
    }
  }

}

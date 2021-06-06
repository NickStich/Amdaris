import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'thirdPartyPersonType'
})
export class ThirdPartyPersonTypePipe implements PipeTransform {

  transform(type: number): string {
    if (type === 2) {
      return 'Supplier';
    }
    if (type === 1) {
      return 'Customer';
    }
  }

}

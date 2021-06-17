import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'thirdPartyPersonName'
})
export class ThirdPartyPersonNamePipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    return null;
  }

}

import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'numberABS'
})
export class NumberABSPipe implements PipeTransform {

  transform(num: number, ...args: any[]): any {
    if (num < 0) {
      return num * -1;
    }
    return num;
  }
}

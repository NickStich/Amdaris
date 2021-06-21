import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'vatType'
})
export class VatTypePipe implements PipeTransform {

  transform(vatType: number): string {
    switch (vatType) {
      case 0:
        return 'Collected';
        break;
      case 1:
        return 'Deducted';
        break;
      case 2:
        return 'ToPay';
        break;
      case 3:
        return 'ToReceive';
        break;
      default:
        return 'Unknown';
        break;
    }
  }
}

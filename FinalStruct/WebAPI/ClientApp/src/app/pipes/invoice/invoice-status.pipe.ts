import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'invoiceStatus'
})
export class InvoiceStatusPipe implements PipeTransform {

  transform(status: number): string {
    switch (status) {
      case 0:
        return 'DRAFT';
        break;
      case 1:
        return 'SENT';
        break;
      case 2:
        return 'VIEWED';
        break;
      case 3:
        return 'PAID';
        break;
      case 4:
        return 'CANCELED';
        break;
      default:
        return 'Invalide Invoice status';
        break;
    }
  }
}

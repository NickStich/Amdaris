import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'invoiceStatus'
})
export class InvoiceStatusPipe implements PipeTransform {

  transform(status: number): string {
    switch (status) {
      case 0:
        return 'DRAFT'; // The invoice has been created, but it has not been sent to the client.
        break;
      case 1:
        return 'SENT'; // The invoice has been sent to the client.
        break;
      case 2:
        return 'VIEWED'; // The invoice has been viewed by the client.
        break;
      case 3:
        return 'PAID'; // The invoice has been paid in full.
        break;
      case 4:
        return 'CANCELED'; // The invoice has been manually marked as Canceled by the user.
        break;
      default:
        return 'Invalide Invoice status';
        break;
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/model/invoice/invoice';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';

@Component({
  selector: 'app-balance-list',
  templateUrl: './balance-list.component.html',
  styleUrls: ['./balance-list.component.css']
})
export class BalanceListComponent implements OnInit {

  invoices: Invoice[] = [];
  saleInvoices: Invoice[] = [];
  purchaseInvoices: Invoice[] = [];

  vatTotalValue: number;
  turnover: number;
  purchases: number;

  constructor(private invoiceService: InvoiceService) {
    this.turnover = 0;
    this.purchases = 0;
    this.vatTotalValue = 0;
   }

  ngOnInit(): void {
    this.invoiceService.findAll().subscribe(data => {
      this.invoices = data;
    });
  }

  populate() {
     for ( const invoice of this.invoices) {
       if (invoice.type === 1) {
         this.saleInvoices.push(invoice);
         this.turnover +=  invoice.value;
       }
       if (invoice.type === 2) {
        this.purchaseInvoices.push(invoice);
         this.purchases +=  invoice.value;
       }
     }
  }

  takeVAT(invoiceList: Invoice[]): number {
    let vat = 0;
    for ( const invoice of invoiceList) {
        vat += invoice.vatValue;
    }
    return vat;
  }

  generateBalance() {
    this.populate();
    this.vatTotalValue = this.takeVAT(this.saleInvoices) - this.takeVAT(this.purchaseInvoices);
  }
}

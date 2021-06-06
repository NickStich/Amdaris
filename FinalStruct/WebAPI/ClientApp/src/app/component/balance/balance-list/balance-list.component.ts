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

  turnover: number;
  purchases: number;

  constructor(private invoiceService: InvoiceService) {
    this.turnover = 0;
    this.purchases = 0;
   }

  ngOnInit(): void {
    this.invoiceService.findAll().subscribe(data => {
      this.invoices = data;
    });
  }

  elaborate() {
     for ( const invoice of this.invoices){
       if (invoice.type === 1){
         this.turnover += this.turnover + invoice.value;
       }
       if (invoice.type === 2){
         this.purchases += this.purchases + invoice.value;
       }
     }
  }
}

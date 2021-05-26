import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/model/invoice/invoice';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  invoices: Invoice[] = [];

  constructor(private invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.invoiceService.findAll().subscribe(data => {
      this.invoices = data;
    });
  }

}

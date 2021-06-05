import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/model/invoice/invoice';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { MatDialog } from '@angular/material/dialog';
import { InvoiceViewComponent } from '../invoice-view/invoice-view.component';

@Component({
  selector: 'app-invoices',
  templateUrl: './invoices.component.html',
  styleUrls: ['./invoices.component.css']
})
export class InvoicesComponent implements OnInit {

  invoices: Invoice[] = [];
  purchaseInvoices: Invoice[] = [];
  saleInvoices: Invoice[] = [];
  tempInvoice: Invoice[] = [];

  constructor(private invoiceService: InvoiceService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.invoiceService.findAll().subscribe(data => {
      this.invoices = data;
      this.tempInvoice = data;
    });
  }
  refreshPage() {
    window.location.reload();
  }

  displayPurchaseInvoices() {
    this.invoices = this.tempInvoice;
    for (const invoice of this.invoices) {
      if (invoice.type === 2) {
        this.purchaseInvoices.push(invoice);
      }
    }
    this.invoices = this.purchaseInvoices;
    this.purchaseInvoices = [];
  }

  displaySaleInvoices() {
    this.invoices = this.tempInvoice;
    for (const invoice of this.invoices) {
      if (invoice.type === 1) {
        this.saleInvoices.push(invoice);
      }
    }
    this.invoices = this.saleInvoices;
    this.saleInvoices = [];
  }
}



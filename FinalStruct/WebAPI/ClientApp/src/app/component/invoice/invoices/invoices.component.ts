import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/model/invoice/invoice';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ViewChild } from '@angular/core';

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

  dataSource = new MatTableDataSource<Invoice>();
  displayedColumns = ['id', 'number', 'date', 'value', 'status', 'action'];
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.invoiceService.findAll().subscribe(data => {
      this.invoices = data;
      this.tempInvoice = data;
      this.applyPaginatorAndSort(this.invoices);
    });
  }

  applyPaginatorAndSort(invoiceList: Invoice[]) {
    this.dataSource = new MatTableDataSource(invoiceList);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  refreshPage() {
    window.location.reload();
  }

  displayAllInvoices() {
    this.invoices = this.tempInvoice;
    this.applyPaginatorAndSort(this.invoices);
  }

  displayPurchaseInvoices() {
    this.invoices = this.tempInvoice;
    for (const invoice of this.invoices) {
      if (invoice.type === 2) {
        this.purchaseInvoices.push(invoice);
      }
    }
    this.applyPaginatorAndSort(this.purchaseInvoices);
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
    this.applyPaginatorAndSort(this.saleInvoices);
    this.invoices = this.saleInvoices;
    this.saleInvoices = [];
  }

  deleteClick(invoiceId) {
    this.invoiceService.delete(invoiceId).subscribe();
    this.refreshPage();
  }

  applyFilter(event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}



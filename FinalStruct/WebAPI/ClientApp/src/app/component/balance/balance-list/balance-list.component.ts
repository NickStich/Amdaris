import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/model/invoice/invoice';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-balance-list',
  templateUrl: './balance-list.component.html',
  styleUrls: ['./balance-list.component.css']
})
export class BalanceListComponent implements OnInit {

  panelOpenStateDate = false;
  panelOpenStateTPP = false;
  invoices: Invoice[] = [];
  reloadedInvoices: Invoice[] = [];
  saleInvoices: Invoice[] = [];
  purchaseInvoices: Invoice[] = [];
  tppType = [1, 2];
  selectedValue = 0;
  tppByType: ThirdPartyPerson[] = [];
  changeText: boolean;

  // filtering
  fromDate: Date;
  toDate: Date;
  personType = '';
  personName = '';

  vatTotalValue: number;
  vatTypeDisplay: number;
  turnover: number;
  purchases: number;
  profitOrLoss = 0;

  constructor(private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService) {
    this.turnover = 0;
    this.purchases = 0;
    this.vatTotalValue = 0;
    this.changeText = false;
    this.fromDate = new Date();
    this.toDate = new Date();
  }

  ngOnInit(): void {
    this.invoiceService.findAll().subscribe(data => {
      this.invoices = data;
      this.reloadedInvoices = data;
    });
  }

  filterByPeriod(start: Date, finish: Date) {
    let outputInvoices: Invoice[] = [];
    if (!start && !finish) {
      outputInvoices = this.invoices;
    } else if (!finish) {
      outputInvoices = this.invoices.filter((item) =>
        new Date(item.date) >= new Date(start));
    } else if (!start) {
      outputInvoices = this.invoices.filter((item) =>
        new Date(item.date) <= new Date(finish));
    } else {
      outputInvoices = this.invoices.filter((item) =>
        new Date(item.date) >= new Date(start) && new Date(item.date) <= new Date(finish));
    }
    this.invoices = outputInvoices;
  }

  filterByThirdPartyPerson(tppId) {
    const outputInvoices: Invoice[] = [];
    if (tppId) {
      this.invoices.forEach((invoice, index) => {
        if (invoice.thirdPartyPersonId !== tppId) {
          this.invoices.splice(index, 1);
        }
      });
    }
  }

  selectedTPPId(event: any) {
    this.selectedValue = event.target.value;
  }

  populate() {
    for (const invoice of this.invoices) {
      if (invoice.type === 1) {
        this.saleInvoices.push(invoice);
        this.turnover += invoice.value;
      }
      if (invoice.type === 2) {
        this.purchaseInvoices.push(invoice);
        this.purchases += invoice.value;
      }
    }
  }

  takeVAT(invoiceList: Invoice[]): number {
    let vat = 0;
    for (const invoice of invoiceList) {
      vat += invoice.vatValue;
    }
    return vat;
  }

  generateBalance(start, finish, tppId) {
    this.filterByPeriod(start, finish);
    this.filterByThirdPartyPerson(tppId);
    this.populate();
    this.vatTotalValue = this.takeVAT(this.saleInvoices) - this.takeVAT(this.purchaseInvoices);
    this.vatTypeDisplay = (this.vatTotalValue > 0) ? 2 : 3;
    this.profitOrLoss = (this.turnover - this.purchases);
    this.invoices = [];
  }

  getTTPByType(theId: number) {
    const id = theId;
    this.tppService.getByType(id).subscribe(data => {
      this.tppByType = data;
    });
  }

  clearFilters() {
    this.invoices = this.reloadedInvoices;
    this.purchaseInvoices = [];
    this.saleInvoices = [];
    this.turnover = 0;
    this.purchases = 0;
    this.profitOrLoss = 0;
    this.panelOpenStateDate = false;
    this.panelOpenStateTPP = false;
    this.vatTotalValue = 0;
    this.vatTypeDisplay = undefined;
    this.fromDate = undefined;
    this.toDate = new Date();
    this.personType = '';
    this.personName = '';
  }
}

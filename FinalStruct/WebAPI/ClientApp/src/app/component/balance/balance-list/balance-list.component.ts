import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
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

  panelOpenState = false;
  invoices: Invoice[] = [];
  saleInvoices: Invoice[] = [];
  purchaseInvoices: Invoice[] = [];
  tppType = [1, 2];
  selectedValue = 0;
  tppByType: ThirdPartyPerson[] = [];
  changeText: boolean;

  // filtering
  fromDate: Date;
  toDate: Date;
  dateNow = Date.now();

  vatTotalValue: number;
  vatTypeDisplay: number;
  turnover: number;
  purchases: number;

  constructor(private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService) {
    this.turnover = 0;
    this.purchases = 0;
    this.vatTotalValue = 0;
    this.changeText = false;
  }

  ngOnInit(): void {
    this.invoiceService.findAll().subscribe(data => {
      this.invoices = data;
    });
  }

  filterByPeriod(start: Date, finish: Date) {
    console.log(start);
    console.log(finish);
    let outputInvoices: Invoice[] = [];
    if (!start && !finish) {
      console.log('all');
      outputInvoices = this.invoices;
    } else if (!finish) {
      console.log('no finish');
      outputInvoices = this.invoices.filter((item) =>
        new Date(item.date) >= new Date(start));
    } else if (!start) {
      console.log('no start');
      outputInvoices = this.invoices.filter((item) =>
        new Date(item.date) <= new Date(finish));
    } else {
      console.log('nothing');
      outputInvoices = this.invoices.filter((item) =>
        new Date(item.date) >= new Date(start) && new Date(item.date) <= new Date(finish));
    }
    console.log(outputInvoices);
    this.invoices = outputInvoices;
  }

  filterByThirdPartyPerson(tppId) {
    console.log('init length=' + this.invoices.length);
    console.log('id=' + tppId);
    const outputInvoices: Invoice[] = [];
    if (tppId) {
      this.invoices.forEach((invoice, index) => {
        if (invoice.thirdPartyPersonId !== tppId) {
          this.invoices.splice(index, 1);
        }
      });
    }
    console.log('length=' + this.invoices.length);
  }

  selectedTPPId(event: any) {
    console.log(this.tppByType.length);
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
    console.log(tppId);
    this.filterByThirdPartyPerson(tppId);
    this.populate();
    this.vatTotalValue = this.takeVAT(this.saleInvoices) - this.takeVAT(this.purchaseInvoices);
    this.vatTypeDisplay = (this.vatTotalValue > 0) ? 2 : 3;
    this.invoices = [];
  }

  getTTPByType(theId: number) {
    const id = theId;
    console.log(id);
    this.tppService.getByType(id).subscribe(data => {
      this.tppByType = data;
    });
  }

  clearFilters() {
    location.reload();
  }

  showMyIcons(event) {
    event.target.classList.remove('hidden');
  }

  hideMyIcons(event) {
    event.target.classList.add('hidden');
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from 'src/app/model/invoice/invoice';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-invoice-form',
  templateUrl: './invoice-form.component.html',
  styleUrls: ['./invoice-form.component.css']
})
export class InvoiceFormComponent implements OnInit {

  private fieldArray: Array<any> = [];
  private newAttribute: any = {};
  private invoice: Invoice;

  thirdPartyPersons: ThirdPartyPerson[] = [];
  tppByName: ThirdPartyPerson;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService) {
      this.invoice = new Invoice();
     }

// list manipulation methods
  ngOnInit() {
    this.tppService.findAll().subscribe(data => {
      this.thirdPartyPersons = data;
    });
  }
  addFieldValue() {
      this.fieldArray.push(this.newAttribute);
      this.newAttribute = {};
  }
  deleteFieldValue(index) {
      this.fieldArray.splice(index, 1);
  }

  onSubmit() {
    this.invoiceService.save(this.invoice).subscribe(result => this.gotoInvoiceList());
  }

  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }
}

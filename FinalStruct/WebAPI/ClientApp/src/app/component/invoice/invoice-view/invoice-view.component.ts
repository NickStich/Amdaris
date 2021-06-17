import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from 'src/app/model/invoice/invoice';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-invoice-view',
  templateUrl: './invoice-view.component.html',
  styleUrls: ['./invoice-view.component.css']
})
export class InvoiceViewComponent implements OnInit {

  invoice: Invoice;
  id: number;
  tpPersons: ThirdPartyPerson[] = [];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService) {
    this.invoice = new Invoice();
  }

  ngOnInit(): void {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.invoiceService.getJsonById(this.id).subscribe(data => {
      this.invoice = data;
    });
    this.tppService.findAll().subscribe(t => this.tpPersons = t);
  }

  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }

  gotoInvoiceEdit(id: number) {
    this.router.navigate(['invs/Edit/' + id]);
  }

  getThirdPartyPersonNameById(id): string {
    let tppName = '';
    for (let i = 0; i < this.tpPersons.length; i++) {
      if (id === this.tpPersons[i].id) {
        tppName = this.tpPersons[i].name;
      }
    }
    return tppName;
  }


}

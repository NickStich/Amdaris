import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from 'src/app/model/invoice/invoice';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';

@Component({
  selector: 'app-invoice-edit',
  templateUrl: './invoice-edit.component.html',
  styleUrls: ['./invoice-edit.component.css']
})
export class InvoiceEditComponent implements OnInit {

  invoice: Invoice;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService) {
      this.invoice = new Invoice();
    }

  ngOnInit() {
    let id: number;
    id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.invoiceService.getById(id).subscribe(data => {
      this.invoice = data;
    });
  }

  check() {
    console.log(this.invoice.number);
  }

  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }

}

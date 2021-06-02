import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from 'src/app/model/invoice/invoice';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';

@Component({
  selector: 'app-invoice-view',
  templateUrl: './invoice-view.component.html',
  styleUrls: ['./invoice-view.component.css']
})
export class InvoiceViewComponent implements OnInit {

  invoice: Invoice;
  id: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService) {
      this.invoice = new Invoice();
     }

  ngOnInit(): void {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.invoiceService.getById(this.id).subscribe(data => {
      this.invoice = data;
    });
  }

  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';

import { Invoice } from 'src/app/model/invoice/invoice';
import { Position } from 'src/app/model/position/position';
import { Product } from 'src/app/model/product/product';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { InvoiceService } from 'src/app/service/invoiceService/invoice.service';
import { PositionService } from 'src/app/service/positionService/position.service';
import { ProductService } from 'src/app/service/productService/product.service';
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
  private position: Position;
  private product: Product;
  private date: Date;
  // input values
  positionsForm: FormGroup;
  positions: FormArray;
  productName: string;
  productPrice: number;
  quantity: number;
  thirdPartyPersons: ThirdPartyPerson[] = [];
  thirdPartyPerson: ThirdPartyPerson;
  index = 1;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService,
    private positionService: PositionService,
    private productService: ProductService,
    private formBuilder: FormBuilder) {
    this.invoice = new Invoice();
    this.position = new Position();
    this.product = new Product();
  }

  ngOnInit() {
    this.tppService.findAll().subscribe(data => {
      this.thirdPartyPersons = data;
    });
  }

  onSubmit() {
    console.log(this.invoice.thirdPartyPersonId);
    console.log(this.invoice.date);
    this.product.name = this.productName;
    this.product.price = this.productPrice;
    this.position.product = this.product;
    this.position.quantity = this.quantity;
    this.invoice.positions = [this.position];
    this.invoiceService.save(this.invoice).subscribe(result => this.gotoInvoiceList());
  }
  gotoInvoiceList() {
    this.router.navigate(['invs']);
  }

  // list manipulation methods
  addFieldValue() {
    this.fieldArray.push(this.newAttribute);
    this.newAttribute = {};
  }
  deleteFieldValue(index) {
    this.fieldArray.splice(index, 1);
  }
}

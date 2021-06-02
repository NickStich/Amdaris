import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';

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
  private date: Date;
  // input values
  // productName = '';
  // productPrice = 0;
  // quantity = 0;
  thirdPartyPersons: ThirdPartyPerson[] = [];
  products: Product[] = [];
  thirdPartyPerson: ThirdPartyPerson;

  private position: Position;
  // private product: Product;
  positions: Position[] = [];
  invoiceForm: FormGroup;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private invoiceService: InvoiceService,
    private tppService: ThirdPartyPersonService,
    private positionService: PositionService,
    private productService: ProductService,
    private formBuilder: FormBuilder) {
    this.invoice = new Invoice();
    // this.position = new Position();
    // this.product = new Product();
  }

  ngOnInit() {
    this.tppService.findAll().subscribe(data => {
      this.thirdPartyPersons = data;
    });
    this.productService.findAll().subscribe(data => {
      this.products = data;
    });
    this.invoiceForm = this.formBuilder.group({
      positions: this.formBuilder.array([this.createItem(), this.createItem()]),
    });

    this.invoiceForm.setValue({
      thirdPartyPersonId: 0,
      date: '',
      number: '',
      positions: [
        {
          product: {
            name: '',
            price: 0,
          },
          quantity: 0,
        }
      ],
    });
  }

  get invoicePositions() {
    return this.invoiceForm.get('positions') as FormArray;
  }

  createItem(): FormGroup {
    return this.formBuilder.group({
      product: this.formBuilder.group({
        name: '',
        price: 0,
      }),
      quantity: 0,
    });
  }

  addItem(): void {
    // this.positions = this.invoiceForm.get('positions') as FormArray;
    // this.positions.push(this.createItem());

    this.invoicePositions.push(this.createItem());
  }

  onSubmit() {
    this.invoice = this.invoiceForm.value;
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
